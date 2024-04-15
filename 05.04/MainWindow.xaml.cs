using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _05._04
{
    public partial class MainWindow : Window, IStudentManagementView
    {
        private readonly StudentManagementPresenter _presenter;

        public MainWindow()
        {
            InitializeComponent();
            _presenter = new StudentManagementPresenter(this);
            DataContext = _presenter;

            // Ініціалізація нульових подій
            AddStudent = null;
            UpdateStudent = null;
            DeleteStudent = null;
            AddGrade = null;
        }

        // Реалізація методів і подій інтерфейсу IStudentManagementView
        public void ShowAllStudents(IEnumerable<Student> students)
        {
            studentListBox.ItemsSource = students;
        }

        public void ShowStudentDetails(Student student)
        {
            if (student != null)
            {
                firstNameTextBox.Text = student.FirstName ?? string.Empty;
                lastNameTextBox.Text = student.LastName ?? string.Empty;
            }
        }

        public Student? SelectedStudent => studentListBox.SelectedItem as Student;

        public string GradeToAdd => gradeTextBox.Text;

        // Об'явлення подій як nullable
        public event EventHandler? AddStudent;
        public event EventHandler<StudentEventArgs>? UpdateStudent;
        public event EventHandler<int>? DeleteStudent;
        public event EventHandler<GradeEventArgs>? AddGrade;

        // Реалізація обробників подій
        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            string firstName = firstNameTextBox.Text.Trim();
            string lastName = lastNameTextBox.Text.Trim();

            if (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName))
            {
                AddStudent?.Invoke(this, EventArgs.Empty);
                firstNameTextBox.Text = string.Empty;
                lastNameTextBox.Text = string.Empty;

                MessageBox.Show("Student added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                RefreshStudents(); // Оновити список студентів у ListBox
            }
            else
            {
                MessageBox.Show("Please enter both first name and last name.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateStudent_Click(object sender, RoutedEventArgs e)
        {
            UpdateStudent?.Invoke(this, new StudentEventArgs { Student = SelectedStudent });
        }

        private void DeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedStudent != null)
            {
                DeleteStudent?.Invoke(this, SelectedStudent.StudentId);
                RefreshStudents(); // Оновити список студентів у ListBox
            }
        }

        private void AddGrade_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(GradeToAdd, out int grade) && SelectedStudent != null)
            {
                AddGrade?.Invoke(this, new GradeEventArgs { StudentId = SelectedStudent.StudentId, Grade = grade });
                RefreshStudents(); // Оновити список студентів у ListBox
            }
        }

        private void RefreshStudents()
        {
            var students = _presenter.GetAllStudents(); // Отримати оновлений список студентів
            ShowAllStudents(students); // Оновити ListBox з новим списком студентів
        }

        private void studentListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (studentListBox.SelectedItem is Student selectedStudent)
            {
                ShowStudentDetails(selectedStudent);
            }
        }
    }
}