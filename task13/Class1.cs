using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace task13
{
    public class StudentFileService
    {
        private readonly JsonSerializerOptions _jsonOptions = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        };

        public void SaveStudentToFile(Student student, string filePath)
        {
            string json = JsonSerializer.Serialize(student, _jsonOptions);
            File.WriteAllText(filePath, json);
        }

        public Student LoadStudentFromFile(string filePath)
        {
            string json = File.ReadAllText(filePath);
            var student = JsonSerializer.Deserialize<Student>(json, _jsonOptions) ?? throw new Exception("Файл содержит некорректные данные");
            return student;

        }
    }

    public class Subject(string name, int grade)
    {
        public string Name { get; set; } = name;
        public int Grade { get; set; } = grade;
    }

    [method: JsonConstructor] //чтоб десериализировать
    public class Student(string firstName, string lastName, DateTime birthDate, List<Subject> grades)
    {
        public string FirstName { get; set; } = firstName;
        public string LastName { get; set; } = lastName;
        public DateTime BirthDate { get; set; } = birthDate;
        public List<Subject> Grades { get; set; } = grades ?? [];

        public Student(string firstName, string lastName, string birthDate, List<Subject> grades) : this(firstName, lastName, DateTime.Parse(birthDate), grades) { } //из-за листа пришлось делать через this

        public string Serialized()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
