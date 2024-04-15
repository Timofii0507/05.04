using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05._04
{
    public class StudentService : IStudentService
    {
        private List<Student> _students = new();

        public IEnumerable<Student> GetAllStudents()
        {
            return _students;
        }

        public Student GetStudentById(int studentId)
        {
            return _students.FirstOrDefault(s => s.StudentId == studentId);
        }

        public void AddStudent(Student student)
        {
            student.StudentId = _students.Any() ? _students.Max(s => s.StudentId) + 1 : 1;
            _students.Add(student);
        }

        public void UpdateStudent(Student student)
        {
            var existingStudent = _students.FirstOrDefault(s => s.StudentId == student.StudentId);
            if (existingStudent != null)
            {
                existingStudent.FirstName = student.FirstName;
                existingStudent.LastName = student.LastName;
                existingStudent.Grades = student.Grades;
            }
        }

        public void DeleteStudent(int studentId)
        {
            var studentToRemove = _students.FirstOrDefault(s => s.StudentId == studentId);
            if (studentToRemove != null)
            {
                _students.Remove(studentToRemove);
            }
        }

        public void AddGrade(int studentId, int grade)
        {
            var student = _students.FirstOrDefault(s => s.StudentId == studentId);
            if (student != null)
            {
                student.Grades.Add(grade);
            }
        }
    }
}