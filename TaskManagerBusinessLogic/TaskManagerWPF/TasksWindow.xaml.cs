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
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace TaskManagerWPF
{
    /// <summary>
    /// Логика взаимодействия для TasksWindow.xaml
    /// </summary>
    public partial class TasksWindow : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly TaskLogic taskLogic;

        public TasksWindow(TaskLogic taskLogic)
        {
            InitializeComponent();
            this.taskLogic = taskLogic;
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = taskLogic.Read(new TaskBindingModel { EmployerId = App.Employer.Id });

                if (list != null)
                {
                    dataGridTasks.ItemsSource = list;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCreate_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<TaskWindow>();
            if (form.ShowDialog() == true)
            {
                LoadData();
            }
        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridTasks.SelectedItems.Count == 1)
            {
                var form = Container.Resolve<TaskWindow>();
                form.Id = ((TaskViewModel)dataGridTasks.SelectedItems[0]).Id;
                if (form.ShowDialog() == true)
                {
                    LoadData();
                }
            }
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridTasks.SelectedItems.Count == 1)
            {
                MessageBoxResult result = (MessageBoxResult)MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == MessageBoxResult.Yes)
                {
                    int id = ((TaskViewModel)dataGridTasks.SelectedItems[0]).Id;
                    try
                    {
                        taskLogic.Delete(new TaskBindingModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
    }
}
