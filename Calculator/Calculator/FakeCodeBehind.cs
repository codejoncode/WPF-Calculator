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
    public class MainWindow2 : MainWindow
    {
        double lastNumber,result;

        public MainWindow2()
        {
            InitializeComponent();
            acButton.Click += AcButton_Click;
            negativeButton.Click += NegativeButton_Click;
            modButton.Click += ModButton_Click;
            equalsButton.Click += EqualsButton_Click;
            
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ModButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber / 100;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        /// <summary>
        /// Will take the number and make it negative. If the number is already negative will remove the negative.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
        }
    }
}
