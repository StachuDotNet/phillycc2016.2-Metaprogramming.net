using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace ObjectComparator
{
    public static class PropertyComparer<T>
    {
        // We cache the IL generation by generating the Func<> during the constructor.
        // This way, we don't have to generate the IL every time we want to compare.

        private static readonly Func<T, T, List<string>> getDeltas;

        static PropertyComparer()
        {
            var dyn = new DynamicMethod(":getDeltas", typeof(List<string>), new[] { typeof(T), typeof(T) }, typeof(T));
            var il = dyn.GetILGenerator();

            // create a new list of strings
            il.Emit(OpCodes.Newobj, typeof(List<string>)
                .GetConstructor(Type.EmptyTypes));

            // access the 'Add' method of the generic List<>
            var add = typeof(List<string>).GetMethod("Add");

            foreach (var prop in typeof(T).GetProperties())
            {
                if (!prop.CanRead) continue;
                Label next = il.DefineLabel();
                switch (Type.GetTypeCode(prop.PropertyType))
                {
                    case TypeCode.Boolean:
                    case TypeCode.Byte:
                    case TypeCode.Char:
                    case TypeCode.Double:
                    case TypeCode.Int16:
                    case TypeCode.Int32:
                    case TypeCode.Int64:
                    case TypeCode.SByte:
                    case TypeCode.Single:
                    case TypeCode.UInt16:
                    case TypeCode.UInt32:
                    case TypeCode.UInt64:
                        // generates something like 'return x.prop == y.prop;'
                        il.Emit(OpCodes.Ldarg_0);                                   // x
                        il.EmitCall(OpCodes.Callvirt, prop.GetGetMethod(), null);   // .prop
                        il.Emit(OpCodes.Ldarg_1);                                   // y
                        il.EmitCall(OpCodes.Callvirt, prop.GetGetMethod(), null);   // .prop
                        il.Emit(OpCodes.Ceq);                                       // ==

                        break;

                    default:
                        var pp = new Type[] { prop.PropertyType, prop.PropertyType };
                        var eq = prop.PropertyType.GetMethod("op_Equality", BindingFlags.Public | BindingFlags.Static, null, pp, null);

                        // Try to get the '==' comparater

                        if (eq != null)
                        {
                            il.Emit(OpCodes.Ldarg_0);                                   // x
                            il.EmitCall(OpCodes.Callvirt, prop.GetGetMethod(), null);   // .prop
                            il.Emit(OpCodes.Ldarg_1);                                   // y
                            il.EmitCall(OpCodes.Callvirt, prop.GetGetMethod(), null);   // .prop
                            il.EmitCall(OpCodes.Call, eq, null);                        // ==
                        }
                        else
                        {
                            il.EmitCall(OpCodes.Call,
                                typeof(EqualityComparer<>)
                                    .MakeGenericType(prop.PropertyType)
                                    .GetProperty("Default")
                                    .GetGetMethod(),
                                null); // .Equals()

                            il.Emit(OpCodes.Ldarg_0);                                   // x
                            il.EmitCall(OpCodes.Callvirt, prop.GetGetMethod(), null);   // .prop
                            il.Emit(OpCodes.Ldarg_1);                                   // y
                            il.EmitCall(OpCodes.Callvirt, prop.GetGetMethod(), null);   // .prop
                            il.EmitCall(OpCodes.Callvirt, typeof(EqualityComparer<>).MakeGenericType(prop.PropertyType).GetMethod("Equals", pp), null);
                        }
                        break;
                }

                // add the result to the List<string>

                il.Emit(OpCodes.Brtrue_S, next);
                il.Emit(OpCodes.Dup);
                il.Emit(OpCodes.Ldstr, prop.Name);
                il.EmitCall(OpCodes.Callvirt, add, null);
                il.MarkLabel(next);
            }

            il.Emit(OpCodes.Ret); // return
            getDeltas = (Func<T, T, List<string>>)dyn.CreateDelegate(typeof(Func<T, T, List<string>>));
        }

        public static List<string> GetDeltas(T x, T y)
        {
            return getDeltas(x, y);
        }
    }
}
