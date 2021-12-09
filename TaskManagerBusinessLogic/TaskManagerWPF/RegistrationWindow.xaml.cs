using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Forms;
using TaskManagerBusinessLogic.BindingModels;
using TaskManagerBusinessLogic.BusinessLogics;
using Unity;
using MessageBox = System.Windows.Forms.MessageBox;

namespace TaskManagerWPF
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly EmployerLogic employerLogic;

        public RegistrationWindow(EmployerLogic employerLogic)
        {
            InitializeComponent();
            this.employerLogic = employerLogic;
        }

        private void button_registration_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_login.Text))
            {
                MessageBox.Show("Заполните поле \"Почта\"", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!Regex.IsMatch(textBox_login.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                MessageBox.Show("Почта введена некорректно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrEmpty(passwordBox_password.Password))
            {
                MessageBox.Show("Заполните поле \"пароль\"", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrEmpty(passwordBox_password_repeat.Password))
            {
                MessageBox.Show("Заполните поле \"Повторите пароль\"", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrEmpty(textBox_full_name.Text))
            {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (passwordBox_password.Password != passwordBox_password_repeat.Password)
            {
                MessageBox.Show("Пароль в обоих полях должен быть одинаковым", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else
            {
                try
                {
                    employerLogic.CreateOrUpdate(new EmployerBindingModel
                    {
                        EmployerLogin = textBox_login.Text,
                        EmployerPassword = passwordBox_password.Password,
                        FullNameOfEmployer = textBox_full_name.Text,
                        isDeleted = false
                    });
                    MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = true;
                    Close();
                }
                catch (Exception ex)
                {                  
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
