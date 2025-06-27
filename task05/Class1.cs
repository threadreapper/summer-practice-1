namespace task05;

using System;
using System.Reflection;
using System.Collections.Generic;

public class ClassAnalyzer(Type type)
{
    private readonly Type _type = type;

    public IEnumerable<string> GetPublicMethods()
    {
        foreach (var method in _type.GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance))
        {
            yield return method.Name;
        }
    }
    public IEnumerable<string> GetAllFields()
    {
        foreach (var field in _type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance))
        {
            yield return field.Name;
        }
    }
    public IEnumerable<string> GetMethodParams(string methodname)
    {
        if (_type.GetMethod(methodname, BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static).GetParameters() != null)
        {
            foreach (var param in _type.GetMethod(methodname, BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static).GetParameters())
            {
                yield return param.Name;
            }
        }
        else throw new Exception("Нет такого метода");

    }
    public IEnumerable<string> GetProperties()
    {
        foreach (var property in _type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
        {
            yield return property.Name;
        }
    }
    public bool HasAttribute<T>() where T : Attribute
    {
        var attributes = _type.GetCustomAttributes(typeof(T), false);
        return attributes.Length > 0;
    }
}
