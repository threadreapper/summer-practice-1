using System;
using System.Reflection;
using task07;

namespace task09
{
    public class AssemblyAnalyzer
    {
        public static void AnalyzeAssembly(string assemblyPath)
        {
            try
            {
                Assembly assembly = Assembly.LoadFrom(assemblyPath);
                Console.WriteLine($"\n(^_^) сборка: {assembly.FullName} (^_^)");
                Type[] types = assembly.GetTypes();

                foreach (Type type in types)
                {
                    PrintTypeInfo(type);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"сборка не загрузилась: {ex.Message} :(");
            }
        }

        private static void PrintTypeInfo(Type type)
        {
            Console.WriteLine($"\n============= класс: {type.Name} =============");
            Console.WriteLine("\nего атрибуты:");
            foreach (Attribute attr in type.GetCustomAttributes())
            {
                Console.WriteLine($"- {attr.GetType().Name}");
                if (attr is DisplayNameAttribute displayNameAttr)
                {
                    Console.WriteLine($"  DisplayName: {displayNameAttr.DisplayName}");
                }
                else if (attr is VersionAttribute versionAttr)
                {
                    Console.WriteLine($"  версия: {versionAttr.Major}.{versionAttr.Minor}");
                }
            }

            Console.WriteLine("\n__φ(．．) конструкторы: __φ(．．)");
            foreach (ConstructorInfo ctor in type.GetConstructors())
            {
                Console.WriteLine($"- {ctor.Name}");
                PrintyPrintParameters(ctor.GetParameters());
            }
            Console.WriteLine("\n__φ(．．) Свойства: __φ(．．)");
            foreach (PropertyInfo prop in type.GetProperties())
            {
                Console.WriteLine($"- {prop.Name} : {prop.PropertyType.Name}");
                var propDisplayName = prop.GetCustomAttribute<DisplayNameAttribute>();
                if (propDisplayName != null)
                {
                    Console.WriteLine($"  DisplayName: {propDisplayName.DisplayName}");
                }
            }

            Console.WriteLine("\n__φ(．．) методы: __φ(．．)");
            foreach (MethodInfo method in type.GetMethods())
            {
                Console.WriteLine($"- {method.ReturnType.Name} {method.Name}");
                PrintyPrintParameters(method.GetParameters());
                var methodDisplayName = method.GetCustomAttribute<DisplayNameAttribute>();
                if (methodDisplayName != null)
                {
                    Console.WriteLine($"  DisplayName: {methodDisplayName.DisplayName}");
                }
            }
        }

        private static void PrintyPrintParameters(ParameterInfo[] parameters)
        {
            if (parameters.Length > 0)
            {
                Console.WriteLine("\nпараметры:");
                foreach (ParameterInfo param in parameters)
                {
                    Console.WriteLine($"  {param.ParameterType.Name} {param.Name}");
                }
            }
        }
    }

    class Program
    {
        static void Main()
        {
            AssemblyAnalyzer.AnalyzeAssembly("../../../../task07/bin/Debug/net9.0/task07.dll");
        }
    }
}
