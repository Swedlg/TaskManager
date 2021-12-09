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
    /// Логика взаимодействия для LinkProgramLanguageWindow.xaml
    /// </summary>
    public partial class LinkProgramLanguageWindow : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly DeveloperLogic developerLogic;

        private int? id;

        public int Id { set { id = value; LoadData(); } }

        public LinkProgramLanguageWindow(DeveloperLogic developerLogic, ProgramLanguageLogic programLanguageLogic)
        {
            InitializeComponent();
            this.developerLogic = developerLogic;

            var list = programLanguageLogic.Read(null);
            if (list != null)
            {
                comboBox_program_language.ItemsSource = list;
            }
        }

        private void LoadData()
        {
            textBox_developer.Text = developerLogic.Read(new DeveloperBindingModel { Id = id }).FirstOrDefault().FullNameOfDeveloper;
        }

        private void button_link_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_developer.Text))
            {
                MessageBox.Show("Заполните поле разработчик", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBox_program_language.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали язык программирования", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                developerLogic.LinkProgramLanguage(new DeveloperBindingModel { Id = id }, new ProgramLanguageBindingModel { Id = (int)comboBox_program_language.SelectedValue });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
