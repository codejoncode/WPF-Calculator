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
        //Enum
        public enum Flag
        {
            Add,
            Subtract,
            Divide,
            Modulo,
            Negative,
            Equals,
            Default,
            Multiply,
        };
        //Fields 
        private string _cache = "";
        private Flag _operation = Flag.Default;

        // Properties

        //My Operation is a enum  in which will help me identify which actions to take. 
        public Flag Operation { get; set; }

        //This will hold all of the data. That the operation will be held on.  
        public string Cache
        {
            get
            {
                return _cache;
            }
            set
            {
                _cache = value; 
            }
                
        }
        public double Total { get; set; }



        public MainWindow()
        {
            InitializeComponent();
            //resultLabel.Content = "123345";
        }

        private void acButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
        }

        private void sevenButton_Click(object sender, RoutedEventArgs e)
        {
            string buttonName = ((Button)sender).Name;
            ButtonHelper(buttonName);
            
        }

        /// <summary>
        /// Used to figure out what action to take on the button that is called. 
        /// </summary>
        /// <param name="buttonName">each button has a name and this is used in a switch statement</param>
        private void ButtonHelper(string buttonName)
        {
            switch (buttonName)
            {
                //MathOperations Buttons
                case "acButton":
                    //reset display
                    resultLabel.Content = "0";
                    //reset cache 
                    Cache = "";
                    break;
                case "negativeButton":
                    resultLabel.Content = $"-{resultLabel.Content}";
                    //do something with the Total
                    break;
                case "modButton":
                    //set Flag for mod operation. 
                    Operation = Flag.Modulo;
                    //place current value on cache. 
                    CacheResultLabelContent();
                    break;
                case "divideButton":
                    //set Flag for divide operation. 
                    Operation = Flag.Divide;
                    //place current value on cache.
                    CacheResultLabelContent();
                    break;
                case "multipyButton":
                    //set Flag for multiply operation.
                    Operation = Flag.Multiply;
                    //place current value on cache.
                    CacheResultLabelContent();
                    break;
                case "minusButton":
                    //set Flag for subtraction operation.
                    Operation = Flag.Subtract;
                    //place current value on cache.
                    CacheResultLabelContent();
                    break;
                case "plusButton":
                    //set Flag for addition operation.
                    Operation = Flag.Add;
                    //place current value on cache.
                    CacheResultLabelContent();
                    break;
                case "equalsButton":
                    resultLabel.Content = Total.ToString();
                    break;
                case "decimalButton":
                    //if there is not a decimal already added to the string add one.
                    if(!resultLabel.Content.ToString().Contains("."))
                    {
                        resultLabel.Content = $"{resultLabel.Content}.";
                    }
                    break;
                case "zeroButton":
                    EvalulateNumber(0);
                    break;
                case "oneButton":
                case "twoButton":
                case "threeButton":
                case "fourButton":
                case "fiveButton":
                case "sixButton":
                case "sevenButton":
                case "eightButton":
                case "nineButton":
               
            }
        }
        /// <summary>
        /// Will check the Operation type flag to see if it is set to default. If it is set to default,
        /// a comparsion is done to see how to add the number to the display. Keeps a running total as well. 
        /// For instances where the Default is not set it will change the display to the number selected. Total 
        /// is still updated. 
        /// </summary>
        /// <param name="value"></param>
        private void EvalulateNumber(int value)
        {
            if(Operation.CompareTo(Flag.Default) == 0)
            {
                //This code block hits if Operation type Flag is set to Default. 
                if (resultLabel.Content.ToString() == "0")
                {
                    //Set the display 
                    resultLabel.Content = value.ToString();
                    //set the total
                    Total = value; 

                }
                else
                {
                    //Set the display
                    resultLabel.Content = $"{resultLabel.Content}{value}";
                    //set the total

                }
            }
        }

        /// <summary>
        /// This keeps me from repeating the line of code everywhere in case I need to make a change in the future. 
        /// </summary>
        public void  CacheResultLabelContent ()
        {
            Cache = resultLabel.Content.ToString();
        }
    }
}
