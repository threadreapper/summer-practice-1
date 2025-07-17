using System;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Reflection;
namespace task11
{
    public interface ICalculator
    {
        int Add(int a, int b);
        int Minus(int a, int b);
        int Mul(int a, int b);
        int Div(int a, int b);
    }

    public class CalculatorGenerator
    {
        public ICalculator CompileCalculator(string code)
        {
            CSharpCodeProvider provider = new();
            CompilerParameters compilerParams = new()
            {
                GenerateInMemory = true,
                ReferencedAssemblies = { "System.dll" }
            };

            compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            CompilerResults results = provider.CompileAssemblyFromSource(compilerParams, code);

            if (results.Errors.HasErrors) throw new Exception("Ошибка компиляции калькулятора!");

            Type calculatorType = results.CompiledAssembly.GetType("Calculator");
            return (ICalculator)Activator.CreateInstance(calculatorType);
        }
    }
}
