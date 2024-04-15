using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _05._04
{
    public class StudentManagementPresenter
    {
        private readonly IStudentManagementView _view;
        private readonly StudentService _studentService;

        public StudentManagementPresenter(IStudentManagementView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _studentService = new StudentService(); // Оновлена ініціалізація
            WireUpEvents();
            RefreshStudents();
        }

        private void WireUpEvents()
        {
            _view.AddStudent += (sender, args) => AddStudent();
        }

        private void RefreshStudents()
        {
            var students = _studentService.GetAllStudents();
            _view.ShowAllStudents(students);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _studentService.GetAllStudents();
        }

        public void AddStudent()
        {
            string? firstName = _view.SelectedStudent?.FirstName;
            string? lastName = _view.SelectedStudent?.LastName;

            if (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName))
            {
                var newStudent = new Student
                {
                    FirstName = firstName!,
                    LastName = lastName!
                };

                _studentService.AddStudent(newStudent);
                RefreshStudents();
            }
            else
            {
                MessageBox.Show("Please select a student before adding.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void UpdateStudent()
        {
            var selectedStudent = _view.SelectedStudent;
            if (selectedStudent != null)
            {
                var updatedStudent = new Student
                {
                    StudentId = selectedStudent.StudentId,
                    FirstName = selectedStudent.FirstName,
                    LastName = selectedStudent.LastName
                };

                _studentService.UpdateStudent(updatedStudent);
                RefreshStudents();
            }
        }

        public void DeleteStudent(int studentId)
        {
            _studentService.DeleteStudent(studentId);
            RefreshStudents();
        }

        public void AddGrade()
        {
            var selectedStudent = _view.SelectedStudent;
            if (selectedStudent != null && int.TryParse(_view.GradeToAdd, out int grade))
            {
                _studentService.AddGrade(selectedStudent.StudentId, grade);
                RefreshStudents();
            }
        }
    }
}