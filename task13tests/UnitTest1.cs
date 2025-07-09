using System;
using System.IO;
using Xunit;
using task13;
using System.Text.Json;

namespace task13tests
{
    public class SerialzationTests
    {
        [Fact]
        public void StudentSerialization_ReturnsCorrectJson()
        {
            Student student = CreateTestStudent();
            string studentJson = JsonSerializer.Serialize(student);
            string expectedJson = @"{""FirstName"":""\u0442\u0438\u043C\u043E\u0444\u0435\u0439"",""LastName"":""\u043F\u043E\u0434\u0443\u0448\u043A\u0438\u043D"",""BirthDate"":""1420-04-20T00:00:00"",""Grades"":[{""Name"":""math"",""Grade"":3},{""Name"":""coding practice"",""Grade"":4}]}";
            Assert.Equal(expectedJson, studentJson);
        }

        [Fact]
        public void StudentDeserialization_ReturnsCorrectStudent()
        {
            Student student = CreateTestStudent();
            string studentJson = JsonSerializer.Serialize(student);
            Student deserializedStudent = JsonSerializer.Deserialize<Student>(studentJson);
            Assert.Equal(student.FirstName, deserializedStudent.FirstName);
            Assert.Equal(student.LastName, deserializedStudent.LastName);
            Assert.Equal(student.BirthDate, deserializedStudent.BirthDate);
            Assert.Equal(student.Grades.Count, deserializedStudent.Grades.Count); // из-за того что проверка идет по ссылке надо каждое поле проверять отдельно????
            foreach (var grade in student.Grades)
            {
                Assert.Equal(grade.Name, deserializedStudent.Grades.First(g => g.Name == grade.Name).Name);
            }
        }

        private static Student CreateTestStudent()
        {
            var math = new Subject("math", 3);
            var codingPractice = new Subject("coding practice", 4);
            var studentGrades = new List<Subject> { math, codingPractice };
            return new Student("тимофей", "подушкин", "1420-04-20", studentGrades);
        }
    }
    public class StudentFileServiceTests : IDisposable
    {
        private readonly string _testFilePath = "testStudent.json";
        private readonly StudentFileService _service = new();

        public void Dispose()
        {
            if (File.Exists(_testFilePath))
            {
                File.Delete(_testFilePath);
            }
        }
        
        [Fact]
        public void LoadStudentFromFile_ReturnsCorrectStudent()
        {
            var expectedStudent = CreateTestStudent();
            _service.SaveStudentToFile(expectedStudent, _testFilePath);

            var loadedStudent = _service.LoadStudentFromFile(_testFilePath);

            Assert.Equal(expectedStudent.FirstName, loadedStudent.FirstName);
            Assert.Equal(expectedStudent.LastName, loadedStudent.LastName);
            Assert.Equal(expectedStudent.BirthDate, loadedStudent.BirthDate);
            Assert.Equal(expectedStudent.Grades.Count, loadedStudent.Grades.Count);
        }

        [Fact]
        public void SaveAndLoad_ReturnsEquivalentStudent()
        {
            var originalStudent = CreateTestStudent();

            _service.SaveStudentToFile(originalStudent, _testFilePath);
            var loadedStudent = _service.LoadStudentFromFile(_testFilePath);

            Assert.Equal(originalStudent.FirstName, loadedStudent.FirstName);
            Assert.Equal(originalStudent.LastName, loadedStudent.LastName);
            Assert.Equal(originalStudent.BirthDate, loadedStudent.BirthDate);
            Assert.Equal(originalStudent.Grades.Count, loadedStudent.Grades.Count);
            for (int i = 0; i < originalStudent.Grades.Count; i++)
            {
                Assert.Equal(originalStudent.Grades[i].Name, loadedStudent.Grades[i].Name);
                Assert.Equal(originalStudent.Grades[i].Grade, loadedStudent.Grades[i].Grade);
            }
        }

        [Fact]
        public void SaveStudentToFile_WithNullGrades_WorksCorrectly()
        {
            var student = new Student("null", "grades", "2000-01-01", null);
            _service.SaveStudentToFile(student, _testFilePath);
            var loadedStudent = _service.LoadStudentFromFile(_testFilePath);
            Assert.NotNull(loadedStudent.Grades);
            Assert.Empty(loadedStudent.Grades);
        }

        private static Student CreateTestStudent()
        {
            var math = new Subject("math", 3);
            var codingPractice = new Subject("coding practice", 4);
            var studentGrades = new List<Subject> { math, codingPractice };
            return new Student("тимофей", "подушкин", "1420-04-20", studentGrades);
        }
    }
}
