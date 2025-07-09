using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace task13;

public class Subject //добавлил public, так как иначе в 19 строке ошибка "Inconsistent accessibility: property type 'List<Subject>' is less accessible than property 'Student.Grades'"
{
    public string Name { get; set; }
    public int Grade { get; set; }
}

public class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public List<Subject> Grades { get; set; }
}

public class Class1
{

}
