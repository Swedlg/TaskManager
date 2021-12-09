using System.Windows;
using System.Windows.Forms;
using TaskManagerBusinessLogic.BindingModels;
using TaskManagerBusinessLogic.BusinessLogics;
using Unity;
using MessageBox = System.Windows.Forms.MessageBox;

namespace TaskManagerWPF
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        /// <summary>
        /// Контейнер
        /// </summary>
        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly EmployerLogic employerLogic;

        public AuthorizationWindow(EmployerLogic employerLogic)
        {
            InitializeComponent();
            this.employerLogic = employerLogic;
            LoadData();
        }

        /// <summary>
        /// Загрузка данных о врачах
        /// </summary>
        private void LoadData()
        {
            var list_of_employers = employerLogic.Read(null);
            if (list_of_employers != null)
            {
                comboBox_login.ItemsSource = list_of_employers;
            }
        }

        private void button_authorization_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox_login.SelectedItem == null)
            {
                MessageBox.Show("Введите почту", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(passwordBox_password.Password))
            {
                MessageBox.Show("Введите пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var employer = employerLogic.Read(new EmployerBindingModel
            {
                EmployerLogin = comboBox_login.Text,
                EmployerPassword = passwordBox_password.Password
            });

            if (employer != null && employer.Count > 0)
            {
                var current_user = employer[0];
                App.Employer = current_user;
                var MainWindow = Container.Resolve<MainWindow>();
                MainWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Неверно введен пароль или логин", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_registration_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<RegistrationWindow>();
            if (form.ShowDialog() == true)
            {
                LoadData();
            }
        }
    }
}
