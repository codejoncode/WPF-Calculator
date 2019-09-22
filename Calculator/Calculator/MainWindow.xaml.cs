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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Fields
        private CalculatorModel _operationalModel;

        //Properties
        public CalculatorModel OperationalModel
        {
            get
            {
                return _operationalModel;
            }      
        }

        public MainWindow()
        {
            InitializeComponent();
            //resultLabel.Content = "123345";
            _operationalModel = new CalculatorModel(resultLabel);
        }

        private void CalculatorButton_Click(object sender, RoutedEventArgs e)
        {
            //Go get the button name.
            string buttonName = ((Button)sender).Name;
            //Figure out what to do next. 
            OperationalModel.ButtonHelper(buttonName); 
        }  
    }
}
