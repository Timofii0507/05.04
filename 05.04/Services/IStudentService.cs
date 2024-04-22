using _05._04.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05._04
{
    public interface IStudentService
    {
        IEnumerable<StudentUseCase> GetAllStudents();
        StudentUseCase GetStudentById(int studentId);
        void AddStudent(String firsName, String lastname);
        void UpdateStudent(StudentUseCase student);
        void DeleteStudent(int studentId);
        void AddGrade(int studentId, int grade);
    }
}