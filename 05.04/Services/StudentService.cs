using _05._04.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05._04
{
    public class StudentService : IStudentService
    {
        public List<StudentUseCase> _students = new List<StudentUseCase>();

        public IEnumerable<StudentUseCase> GetAllStudents()
        {
            return _students;
        }

        public StudentUseCase GetStudentById(int studentId)
        {
            return _students.FirstOrDefault(s => s.Id == studentId);
        }

        public void AddStudent(String firsName, String lastname)
        {
            var student = new StudentUseCase(0, firsName, lastname, 0);
            student.Id = _students.Any() ? _students.Max(s => s.Id) + 1 : 1;
            _students.Add(student);
        }

        public void UpdateStudent(StudentUseCase student)
        {
            var existingStudent = _students.FirstOrDefault(s => s.Id == student.Id);
            if (existingStudent != null)
            {
                existingStudent.FirstName = student.FirstName;
                existingStudent.LastName = student.LastName;
                existingStudent.Grades = student.Grades;
            }
        }

        public void DeleteStudent(int studentId)
        {
            var studentToRemove = _students.FirstOrDefault(s => s.Id == studentId);
            if (studentToRemove != null)
            {
                _students.Remove(studentToRemove);
            }
        }

        public void AddGrade(int studentId, int grade)
        {
            var student = _students.FirstOrDefault(s => s.Id == studentId);
            if (student != null)
            {
                student.Grades = grade;
            }
        }
    }
}