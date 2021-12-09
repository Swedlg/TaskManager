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
    /// Логика взаимодействия для ProgramLanguageWindow.xaml
    /// </summary>
    public partial class ProgramLanguageWindow : Window
    {

        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly ProgramLanguageLogic programLanguageLogic;

        private int? id;

        public int Id { set { id = value; LoadData(); } }

        public ProgramLanguageWindow(ProgramLanguageLogic programLanguageLogic)
        {
            InitializeComponent();
            this.programLanguageLogic = programLanguageLogic;
        }

        private void LoadData()
        {
            var programLanguage = programLanguageLogic.Read(new ProgramLanguageBindingModel { Id = id }).FirstOrDefault();
            textBox_language_name.Text = programLanguage.LanguageName;
            textBox_language_description.Text = programLanguage.LanguageDescription;
        }

        private void button_save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_language_description.Text))
            {
                MessageBox.Show("Введите описнаие языка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBox_language_name.Text))
            {
                MessageBox.Show("Введите название языка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }       
            try
            {
                programLanguageLogic.CreateOrUpdate(new ProgramLanguageBindingModel
                {
                    Id = id,
                    LanguageDescription = textBox_language_description.Text,
                    LanguageName = textBox_language_name.Text
                });
                MessageBox.Show("Сохранение языка программирования прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
