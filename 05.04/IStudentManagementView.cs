using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05._04
{
    public interface IStudentManagementView
    {
        event EventHandler AddStudent;
        event EventHandler<StudentEventArgs> UpdateStudent;
        event EventHandler<int> DeleteStudent;
        event EventHandler<GradeEventArgs> AddGrade;

        void ShowAllStudents(IEnumerable<Student> students);
        void ShowStudentDetails(Student student);

        Student? SelectedStudent { get; }
        string GradeToAdd { get; }
    }

    public class StudentEventArgs : EventArgs
    {
        public Student Student { get; set; } = new Student(); // Приклад ініціалізації
    }

    public class GradeEventArgs : EventArgs
    {
        public int StudentId { get; set; }
        public int Grade { get; set; }
    }
}
