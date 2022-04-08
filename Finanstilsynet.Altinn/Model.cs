using System;
using System.Reflection;
using System.Linq.Expressions;

namespace Finanstilsynet.Altinn
{
    public static class Model
    {
        /// <summary>
        /// <code>SetValue(() => a.b.c.d, "foo");</code> is equivalent to
        /// <code>
        /// a?.b ??= new()
        /// a.b?.c ??= new();
        /// a.b.c.d = "foo";
        /// </code>
        /// </summary>
        public static void SetValue<T>(Expression<Func<T>> member, T value)
        {
            if (member.Body is MemberExpression b)
            {
                var o = InitMember(b);
                b.Member.SetValue(o, value);
            }
            else
            {
                throw new InvalidOperationException($"Can only assign members, eg a.b.c, not {member.Body.NodeType}");
            }
        }

        private static void SetValue(this MemberInfo m, object o, object v)
        {
            switch (m.MemberType)
            {
                case MemberTypes.Field:
                    (m as FieldInfo).SetValue(o, v);
                    break;
                case MemberTypes.Property:
                    (m as PropertyInfo).SetValue(o, v);
                    break;
                default:
                    throw new InvalidOperationException($"{m.Name} is not a Field or Property. Can only set value for Fields or Properties.");
            }
        }

        private static object GetValue(this MemberInfo m, object o)
        {
            switch (m.MemberType)
            {
                case MemberTypes.Field:
                    return (m as FieldInfo).GetValue(o);
                case MemberTypes.Property:
                    return (m as PropertyInfo).GetValue(o);
                default:
                    throw new InvalidOperationException($"{m.Name} is not a Field or Property. Can only get value for Fields or Properties.");
            }
        }

        private static object InitMember(MemberExpression e)
        {
            switch (e.Expression)
            {
                case ConstantExpression c:
                {
                    var v = e.Member.GetValue(c.Value);
                    if (v == null)
                    {
                        throw new ArgumentNullException($"Constant expression {e.Member.Name} is null");
                    }
                    return v;
                }
                case MemberExpression m:
                {
                    var p = InitMember(m);
                    if (e.Type.IsClass && e.Type != typeof(string))
                    {
                        var v = e.Member.GetValue(p);
                        if(v == null)
                        {
                            // NOTE: Error if no parameterless ctor, but this
                            // isn't the case for datamodels used in Altinn
                            v = Activator.CreateInstance(e.Type)!;
                            e.Member.SetValue(p, v);
                        }
                        return v;
                    }
                    else
                    {
                        return p;
                    }
                }
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
