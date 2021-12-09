using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Unity;
using TaskManagerBusinessLogic.BindingModels;
using TaskManagerBusinessLogic.BusinessLogics;
using TaskManagerBusinessLogic.ViewModels;
using MessageBox = System.Windows.Forms.MessageBox;
using System.Windows.Forms;

namespace TaskManagerWPF
{
    /// <summary>
    /// Логика взаимодействия для DeveloperWindow.xaml
    /// </summary>
    public partial class DeveloperWindow : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly DeveloperLogic developerLogic;

        private int? id;

        public int Id { set { id = value; LoadData(); } }

        public DeveloperWindow(DeveloperLogic developerLogic)
        {
            InitializeComponent();
            this.developerLogic = developerLogic;
        }

        private void LoadData()
        {
            var developer = developerLogic.Read(new DeveloperBindingModel { Id = id }).FirstOrDefault();
            textBox_full_name.Text = developer.FullNameOfDeveloper;
            textBox_position.Text = developer.DeveloperPosition;
            textBox_work_experience.Text = developer.WorkExperience.ToString();
            checkBox_isDeleted.IsChecked = developer.isDeleted;
        }

        private void button_save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_full_name.Text))
            {
                MessageBox.Show("Введите ФИО разработчика", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBox_position.Text))
            {
                MessageBox.Show("Введите должность разработчика", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBox_work_experience.Text))
            {
                MessageBox.Show("Введите стаж разработчика", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                developerLogic.CreateOrUpdate(new DeveloperBindingModel
                {
                    Id = id,

                    FullNameOfDeveloper = textBox_full_name.Text,
                    DeveloperPosition = textBox_position.Text,
                    WorkExperience = Convert.ToInt32(textBox_work_experience.Text),
                    isDeleted = (bool) checkBox_isDeleted.IsChecked
                }); 
                MessageBox.Show("Сохранение разработчика прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
