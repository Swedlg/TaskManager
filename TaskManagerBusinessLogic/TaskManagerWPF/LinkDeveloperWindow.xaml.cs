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
    /// Логика взаимодействия для LinkDeveloperWindow.xaml
    /// </summary>
    public partial class LinkDeveloperWindow : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly StageLogic stageLogic;

        private int? id;

        public int Id { set { id = value; LoadData(); } }

        public LinkDeveloperWindow(StageLogic stageLogic, DeveloperLogic developerLogic)
        {
            InitializeComponent();
            this.stageLogic = stageLogic;

            var list = developerLogic.Read(null);
            if (list != null)
            {
                comboBox_developer.ItemsSource = list;
            }
        }

        private void LoadData()
        {
            textBox_stage.Text = stageLogic.Read(new StageBindingModel { Id = id }).FirstOrDefault().StageDescription;
        }

        private void button_link_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_stage.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBox_developer.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали разработчика", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                stageLogic.LinkDeveloper(new StageBindingModel { Id = id }, new DeveloperBindingModel { Id = (int)comboBox_developer.SelectedValue });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
