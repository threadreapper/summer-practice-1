namespace task11;

using System;
using System.Reflection;
using System.Reflection.Emit;

public static class CalculatorGenerator
{
    public static dynamic GenerateCalc()
    {
        AssemblyName assemblyName = new("CalcAss");
        AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
        ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("DynamicCalcModule");
        TypeBuilder typeBuilder = moduleBuilder.DefineType("DynamicCalc.Calculator", TypeAttributes.Public | TypeAttributes.Class);

        GenerateMethod(typeBuilder, "Add", typeof(int), typeof(int), typeof(int));
        GenerateMethod(typeBuilder, "Minus", typeof(int), typeof(int), typeof(int));
        GenerateMethod(typeBuilder, "Mul", typeof(int), typeof(int), typeof(int));
        GenerateMethod(typeBuilder, "Div", typeof(int), typeof(int), typeof(int));
        
        Type calculatorType = typeBuilder.CreateType();

        return Activator.CreateInstance(calculatorType);
    }

    private static void GenerateMethod(TypeBuilder typeBuilder, string methodName, Type returnType, params Type[] parameterTypes)
    {
        MethodBuilder methodBuilder = typeBuilder.DefineMethod(methodName, MethodAttributes.Public, returnType, parameterTypes);
        ILGenerator il = methodBuilder.GetILGenerator();

        il.Emit(OpCodes.Ldarg_1);
        il.Emit(OpCodes.Ldarg_2);

        switch (methodName)
        {
            case "Add":
                il.Emit(OpCodes.Add);
                break;
            case "Minus":
                il.Emit(OpCodes.Sub);
                break;
            case "Mul":
                il.Emit(OpCodes.Mul);
                break;
            case "Div":
                il.Emit(OpCodes.Div);
                break;
        }

        il.Emit(OpCodes.Ret);
    }
}
