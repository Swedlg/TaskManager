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
    /// Логика взаимодействия для TaskWindow.xaml
    /// </summary>
    public partial class TaskWindow : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly TaskLogic taskLogic;

        private readonly EmployerLogic employerLogic;

        private int? id;

        public int Id { set { id = value; LoadData(); } }

        public TaskWindow(TaskLogic taskLogic, EmployerLogic employerLogic)
        {
            InitializeComponent();
            this.taskLogic = taskLogic;
            this.employerLogic = employerLogic;

            textBox_employer_id.Text = employerLogic.Read(new EmployerBindingModel { Id = App.Employer.Id }).FirstOrDefault().FullNameOfEmployer;
        }

        private void LoadData()
        {         
            var task = taskLogic.Read(new TaskBindingModel { Id = id }).FirstOrDefault();
            textBox_task_name.Text = task.TaskName;
            datePicker_task_start_date.SelectedDate = task.TaskStartDate;
            datePicker_task_finish_date.SelectedDate = task.TaskFinishDate;
            checkBox_isDeleted.IsChecked = task.isDeleted;
        }

        private void button_save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_task_name.Text))
            {
                MessageBox.Show("Введите название задачи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (datePicker_task_start_date.SelectedDate == null)
            {
                MessageBox.Show("Введите дату начала", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (datePicker_task_finish_date == null)
            {
                MessageBox.Show("Введите дату окончания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var x = (bool)checkBox_isDeleted.IsChecked;

                taskLogic.CreateOrUpdate(new TaskBindingModel
                {
                    Id = id,
                    TaskName = textBox_task_name.Text,
                    TaskStartDate = (DateTime)datePicker_task_start_date.SelectedDate,
                    TaskFinishDate = (DateTime)datePicker_task_finish_date.SelectedDate,
                    isDeleted = (bool)checkBox_isDeleted.IsChecked,
                    EmployerId = App.Employer.Id
                });
                MessageBox.Show("Сохранение задачи прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
