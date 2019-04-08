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
using System.Windows.Forms.DataVisualization.Charting;

namespace _6Sem_Lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ModelDataView dataView = null;
        public static RoutedCommand AddModelCommand = new RoutedCommand("AddModel", typeof(_6Sem_Lab2.MainWindow));
        public static RoutedCommand DrawCommand = new RoutedCommand("Draw", typeof(_6Sem_Lab2.MainWindow));

        public MainWindow()
        {
            InitializeComponent();
            dataView = new ModelDataView(FindResource("key_ObsModelData") as ObservableModelData);
            boundsStack.DataContext = dataView;
        }

        private void CommandNew_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void CommandOpen_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void CommandSave_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void CommandDelete_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            dataView.modelDatas.Remove_At(modelsList.SelectedIndex);
        }

        private void CommandSave_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (dataView != null)
            {
                e.CanExecute = dataView.modelDatas.HasChanged;
            }
        }

        private void isItemSelected_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (modelsList != null)
            {
                e.CanExecute = (modelsList.SelectedIndex != -1);
            }
        }

        private void CommandAddModel_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (TryFindResource("key_DummyModel") is ModelData dummy_model_ref)
                dataView.modelDatas.Add_ModelData(new ModelData(dummy_model_ref.NodeCount, dummy_model_ref.Parameter));
        }

        private void CommandDraw_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            dataView.Draw(chart, dataView.modelDatas[modelsList.SelectedIndex], dataView.modelDatas.Farthest(modelsList.SelectedIndex));
        }

        private void CommandAddModel_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (pInput == null || nodeCountInput == null)
            {
                e.CanExecute = false;
                return;
            }
            pInput.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            nodeCountInput.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            ModelData dummy_model_ref = FindResource("key_DummyModel") as ModelData;
            foreach (FrameworkElement child in newModelStack.Children)
            {
                if (Validation.GetHasError(child))
                {
                    e.CanExecute = false;
                    return;
                }
            }
            e.CanExecute = true;
        }

        private void addDefaults_Click(object sender, RoutedEventArgs e) => dataView.modelDatas.AddDefaults();
    }
}
