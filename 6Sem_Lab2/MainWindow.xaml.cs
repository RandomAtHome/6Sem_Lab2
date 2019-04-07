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
        ObservableModelData modelDatas = null;
        public MainWindow()
        {
            InitializeComponent();
            modelDatas = FindResource("key_ObsModelData") as ObservableModelData;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            pInput.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            nodeCountInput.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            ModelData dummy_model_ref = FindResource("key_DummyModel") as ModelData;
            foreach (FrameworkElement child in newModelStack.Children)
            {
                if (Validation.GetHasError(child))
                {
                    return;
                }
            }
            modelDatas.Add_ModelData(new ModelData(dummy_model_ref.NodeCount, dummy_model_ref.Parameter));
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
            modelDatas.Remove_At(modelsList.SelectedIndex);
        }

        private void CommandSave_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (modelDatas != null)
            {
                e.CanExecute = modelDatas.HasChanged;
            }
        }

        private void CommandDelete_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (modelsList != null)
            {
                e.CanExecute = (modelsList.SelectedIndex != -1);
            }
        }
    }
}
