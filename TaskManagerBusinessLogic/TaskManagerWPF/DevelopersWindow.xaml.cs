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
    /// Логика взаимодействия для DevelopersWindow.xaml
    /// </summary>
    public partial class DevelopersWindow : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly DeveloperLogic developerLogic;

        public DevelopersWindow(DeveloperLogic developerLogic)
        {
            InitializeComponent();
            this.developerLogic = developerLogic;
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = developerLogic.Read(null);

                if (list != null)
                {
                    dataGridDevelopers.ItemsSource = list;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCreate_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<DeveloperWindow>();
            if (form.ShowDialog() == true)
            {
                LoadData();
            }
        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridDevelopers.SelectedItems.Count == 1)
            {
                var form = Container.Resolve<DeveloperWindow>();
                form.Id = ((DeveloperViewModel)dataGridDevelopers.SelectedItems[0]).Id;
                if (form.ShowDialog() == true)
                {
                    LoadData();
                }
            }
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridDevelopers.SelectedItems.Count == 1)
            {
                MessageBoxResult result = (MessageBoxResult)MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == MessageBoxResult.Yes)
                {
                    int id = ((DeveloperViewModel)dataGridDevelopers.SelectedItems[0]).Id;
                    try
                    {
                        developerLogic.Delete(new DeveloperBindingModel { Id = id });
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

        private void button_link_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridDevelopers.SelectedItems.Count == 1)
            {
                var form = Container.Resolve<LinkProgramLanguageWindow>();
                int id = ((DeveloperViewModel)dataGridDevelopers.SelectedItems[0]).Id;
                form.Id = id;

                if (form.ShowDialog() == true)
                {
                    LoadData();
                }
            }
        }
    }
}
