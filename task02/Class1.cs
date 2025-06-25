using System;
using System.Linq;

namespace task02
{
    public class Student
    {
        public string Name { get; set; }
        public string Faculty { get; set; }
        public List<int> Grades { get; set; }
    }
    public class StudentService
    {
        private readonly List<Student> _students;

        public StudentService(List<Student> students) => _students = students;

        public IEnumerable<Student> GetStudentsByFaculty(string faculty)
        => _students.Where(st => string.Equals(st.Faculty, faculty, StringComparison.OrdinalIgnoreCase));

        public IEnumerable<Student> GetStudentsWithMinAverageGrade(double minAverageGrade)
        => _students.Where(st => st.Grades.Average() >= minAverageGrade);

        public IEnumerable<Student> GetStudentsOrderedByName()
        => _students.OrderBy(st => st.Name);

        public ILookup<string, Student> GroupStudentsByFaculty()
            => _students.ToLookup(st => st.Faculty);
            
        public string GetFacultyWithHighestAverageGrade()
            => _students.GroupBy(st => st.Faculty).Select(group => new
            {
                Faculty = group.Key,
                AvgGrade = group.Average(s => s.Grades.Average())
            }).OrderByDescending(g => g.AvgGrade).FirstOrDefault()?.Faculty ?? string.Empty;
    }
}
