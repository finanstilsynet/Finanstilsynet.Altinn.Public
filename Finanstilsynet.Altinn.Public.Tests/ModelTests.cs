using System;
using Xunit;

namespace Finanstilsynet.Altinn.Tests
{
    public class ModelTests
    {
        public class A
        {
            public B B;
        }

        public class B
        {
            public C C;
        }

        public class C
        {
            public int Value;
        }

        [Fact]
        public void GetValue_WhenOk_GetsValue()
        {
            A a = new()
            {
                B = new()
                {
                    C = new()
                    {
                        Value = 42
                    }
                }
            };

            Assert.Equal(a.B.C.Value, Model.GetValue(() => a.B.C.Value));
        }

        [Fact]
        public void GetValue_WhenMissingFirst_ReturnsDefault()
        {
            A a = null;
            Assert.Equal(42, Model.GetValue(() => a.B.C.Value, 42));
        }

        [Fact]
        public void GetValue_WhenMissingLastClass_ReturnsDefault()
        {
            A a = new()
            {
                B = new()
                {
                    C = null
                }
            };

            var actual = Model.GetValue(() => a.B.C, new C() {Value = 42});
            Assert.Equal(42, actual.Value);
        }

        [Fact]
        public void GetValue_MissingWithoutDefault_ReturnsNull()
        {
            A a = new A();
            Assert.Null(Model.GetValue(() => a.B.C));
        }

        [Fact]
        public void SetValue_WhenOK_SetsValue()
        {
            A a = new A();
            int expected = 10;
            Model.SetValue(() => a.B.C.Value, expected);
            Assert.Equal(expected, a.B.C.Value);
        }

        [Fact]
        public void SetValue_WhenFirstIsNull_Throws()
        {
            A a = null;
            Assert.Throws<ArgumentNullException>(() =>
                Model.SetValue(() => a.B.C.Value, 5));
        }

        [Fact]
        public void SetValue_WhenMiddleExist_DoesntOverride()
        {
            A a = new A();
            B old = new B();
            a.B = old;
            Model.SetValue(() => a.B.C.Value, 5);
            Assert.Same(old, a.B);
        }

        [Fact]
        public void SetValue_WhenNotMemberExpression_Throws()
        {
            Assert.Throws<InvalidOperationException>(() =>
                Model.SetValue(() => 1, 2));
        }
    } 
}
