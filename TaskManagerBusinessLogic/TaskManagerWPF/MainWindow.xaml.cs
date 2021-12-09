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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Unity;

namespace TaskManagerWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_tasks_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<TasksWindow>();
            form.ShowDialog();
        }

        private void button_stages_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<StagesWindow>();
            form.ShowDialog();
        }

        private void button_developers_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<DevelopersWindow>();
            form.ShowDialog();
        }

        private void button_program_languages_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<ProgramLanguagesWindow>();
            form.ShowDialog();
        }
    }
}
