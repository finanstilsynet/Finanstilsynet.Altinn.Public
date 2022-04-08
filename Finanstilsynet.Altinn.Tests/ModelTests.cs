using System;
using Xunit;

namespace Finanstilsynet.Altinn.Tests
{
    public class ModelTests
    {
        public class A
        {
            public B b;
        }

        public class B
        {
            public C c;
        }

        public class C
        {
            public int value;
        }

        [Fact]
        public void SetValue_WhenOK_SetsValue()
        {
       
            A a = new A();
            int expected = 10;
            Model.SetValue(() => a.b.c.value, expected);
            Assert.Equal(expected, a.b.c.value);

        }

        [Fact]
        public void SetValue_WhenFirstIsNull_Throws()
        {
            A a = null;
            Assert.Throws<ArgumentNullException>(() =>
                Model.SetValue(() => a.b.c.value, 5));
        }

        [Fact]
        public void SetValue_WhenMiddleExist_DoesntOverride()
        {
            A a = new A();
            B old = new B();
            a.b = old;
            Model.SetValue(() => a.b.c.value, 5);
            Assert.Same(old, a.b);
        }

        [Fact]
        public void SetValue_WhenNotMemberExpression_Throws()
        {
            Assert.Throws<InvalidOperationException>(() =>
                Model.SetValue(() => 1, 2));
        }
    } 
}
