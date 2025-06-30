namespace task07;

using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)]
public class DisplayNameAttribute(string name) : Attribute
{
    public string DisplayName { get; } = name;
}

[AttributeUsage(AttributeTargets.Class)]
public class VersionAttribute(int major, int minor) : Attribute
{
    public int Major { get; } = major;
    public int Minor { get; } = minor;
}
[Version(1, 0)]
[DisplayName("тестовое имя класса какое-то")]
public class SampleClass()
{
    [DisplayName("какой-то там метод")]
    public void TestMethod() { }

    [DisplayName("числосвойство какое-то")]
    public int Number { get; set; }
}
public static class ReflectionHelper
{
    public static void PrintTypeInfo(Type type)
    {
        Console.WriteLine("\\(0_o)/ информация о классе \\(0_o)/");

        var displayNameAttr = type.GetCustomAttribute<DisplayNameAttribute>();
        if (displayNameAttr != null)
        {
            Console.WriteLine($"отображаемое имя: {displayNameAttr.DisplayName}");
        }

        var versionAttr = type.GetCustomAttribute<VersionAttribute>();
        if (versionAttr != null)
        {
            Console.WriteLine($"версия: {versionAttr.Major}.{versionAttr.Minor}");
        }

        Console.WriteLine("\n\\(0_o)/ свойства \\(0_o)/");
        foreach (var prop in type.GetProperties())
        {
            var propDisplayName = prop.GetCustomAttribute<DisplayNameAttribute>();
            Console.WriteLine(propDisplayName != null
                ? $"{prop.Name} (отображаемое имя: {propDisplayName.DisplayName})"
                : prop.Name);
        }

        Console.WriteLine("\n\\(0_o)/ методы \\(0_o)/");
        foreach (var method in type.GetMethods())
        {
            var methodDisplayName = method.GetCustomAttribute<DisplayNameAttribute>();
            Console.WriteLine(methodDisplayName != null
                ? $"{method.Name} (отображаемое имя: {methodDisplayName.DisplayName})"
                : method.Name);
        }
    }
}
