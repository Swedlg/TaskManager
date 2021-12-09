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
    /// Логика взаимодействия для StageWindow.xaml
    /// </summary>
    public partial class StageWindow : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly StageLogic stageLogic;

        private int? id;

        public int Id { set { id = value; LoadData(); } }

        public StageWindow(StageLogic stageLogic, TaskLogic taskLogic)
        {
            InitializeComponent();

            this.stageLogic = stageLogic;

            var list = taskLogic.Read(null);
            if (list != null)
            {
                comboBox_task_id.ItemsSource = list;
            }
        }

        private void LoadData()
        {
            var stage = stageLogic.Read(new StageBindingModel { Id = id }).FirstOrDefault();
            textBox_stage_description.Text = stage.StageDescription;
            datePicker_stage_start_date.SelectedDate = stage.StageStartDate;
            datePicker_stage_finish_date.SelectedDate = stage.StageFinishDate;
            checkBox_isDeleted.IsChecked = stage.isDeleted;
            checkBox_isComplited.IsChecked = stage.isDeleted;
            comboBox_task_id.SelectedValue = stage.TaskId;
        }

        private void button_save_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(textBox_stage_description.Text))
            {
                MessageBox.Show("Введите описание этапа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (datePicker_stage_start_date.SelectedDate == null)
            {
                MessageBox.Show("Введите дату начала", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (datePicker_stage_finish_date.SelectedDate == null)
            {
                MessageBox.Show("Введите дату окончания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBox_task_id.SelectedValue == null)
            {
                MessageBox.Show("Выберите задачу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }          
            try
            {
                stageLogic.CreateOrUpdate(new StageBindingModel
                {
                    Id = id,
                    StageDescription = textBox_stage_description.Text,
                    StageStartDate = (DateTime)datePicker_stage_start_date.SelectedDate,
                    StageFinishDate = (DateTime)datePicker_stage_finish_date.SelectedDate,
                    isDeleted = (bool) checkBox_isDeleted.IsChecked,
                    isComplited = (bool) checkBox_isComplited.IsChecked,
                    TaskId = Convert.ToInt32(comboBox_task_id.SelectedValue)
                });;
                MessageBox.Show("Сохранение этапа прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
