namespace task05tests;

using Xunit;
using task05;

public class TestClass
{
    public int PublicField;
    private string _privateField;
    public int Property { get; set; }
    static int SwagProperty { get; set; }

    public void Method(int woow) { }
}

[Serializable]
public class AttributedClass { }

public class ClassAnalyzerTests
{
    [Fact]
    public void GetPublicMethods_ReturnsCorrectMethods()
    {
        var analyzer = new ClassAnalyzer(typeof(TestClass));
        var methods = analyzer.GetPublicMethods();

        Assert.Contains("Method", methods);
    }

    [Fact]
    public void GetAllFields_IncludesPrivateFields()
    {
        var analyzer = new ClassAnalyzer(typeof(TestClass));
        var fields = analyzer.GetAllFields();

        Assert.Contains("_privateField", fields);
    }

    [Fact]
    public void GetMethodParams_ReturnsParams()
    {
        var analyzer = new ClassAnalyzer(typeof(TestClass));
        var param = analyzer.GetMethodParams("Method");

        Assert.Contains("woow", param);
    }

    [Fact]
    public void HasAttribute_WorksWithMethodAttributes()
    {
        var analyzer = new ClassAnalyzer(typeof(AttributedClass));
        Assert.True(analyzer.HasAttribute<SerializableAttribute>());
    }

    [Fact]
    public void GetProperties_ReturnsCorrectProperties()
    {
        var analyzer = new ClassAnalyzer(typeof(TestClass));
        Assert.Contains("SwagProperty", analyzer.GetProperties());
    }
}
