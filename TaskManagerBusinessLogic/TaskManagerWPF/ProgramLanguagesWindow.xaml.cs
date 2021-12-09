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
    /// Логика взаимодействия для ProgramLanguagesWindow.xaml
    /// </summary>
    public partial class ProgramLanguagesWindow : Window
    {

        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly ProgramLanguageLogic programLanguageLogic;

        public ProgramLanguagesWindow(ProgramLanguageLogic programLanguageLogic)
        {
            InitializeComponent();
            this.programLanguageLogic = programLanguageLogic;
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = programLanguageLogic.Read(null);

                if (list != null)
                {
                    dataGridProgramLanguages.ItemsSource = list;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCreate_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<ProgramLanguageWindow>();
            if (form.ShowDialog() == true)
            {
                LoadData();
            }
        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridProgramLanguages.SelectedItems.Count == 1)
            {
                var form = Container.Resolve<ProgramLanguageWindow>();
                form.Id = ((ProgramLanguageViewModel)dataGridProgramLanguages.SelectedItems[0]).Id;
                if (form.ShowDialog() == true)
                {
                    LoadData();
                }
            }
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridProgramLanguages.SelectedItems.Count == 1)
            {
                MessageBoxResult result = (MessageBoxResult)MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == MessageBoxResult.Yes)
                {
                    int id = ((ProgramLanguageViewModel)dataGridProgramLanguages.SelectedItems[0]).Id;
                    try
                    {
                        programLanguageLogic.Delete(new ProgramLanguageBindingModel { Id = id });
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
