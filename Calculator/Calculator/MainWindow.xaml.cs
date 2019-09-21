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

        private void CalculatorButton_Click(object sender, RoutedEventArgs e)
        {
            //Go get the button name.
            string buttonName = ((Button)sender).Name;
            //Figure out what to do next. 
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
                    //reset Total
                    Total = 0.0;
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
                    EvalulateNumber(1);
                    break;
                case "twoButton":
                    EvalulateNumber(2);
                    break;
                case "threeButton":
                    EvalulateNumber(3);
                    break;
                case "fourButton":
                    EvalulateNumber(4);
                    break;
                case "fiveButton":
                    EvalulateNumber(5);
                    break;
                case "sixButton":
                    EvalulateNumber(6);
                    break;
                case "sevenButton":
                    EvalulateNumber(7);
                    break;
                case "eightButton":
                    EvalulateNumber(8);
                    break;
                case "nineButton":
                    EvalulateNumber(9);
                    break;

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
                    //set the total on conditionals  
                    //Find out if a . is used for decimal

                    //Intitially when  0.   we want to actually keep the total at 0. 


                    bool featuresDecimal =  resultLabel.Content.ToString().Contains(".") ? true : false;
                    
                    //Features decimal
                    if (featuresDecimal)
                    {

                        Total = resultLabel.Content.ToString().Length > 2 ? Double.Parse($"{resultLabel.Content}") : 0.0;
                    }
                    
                    //No decimal.
                    else
                    {
                        Total = Int32.Parse($"{resultLabel.Content}{value}");

                    }

                }
            }
            //Add
            else if (Operation.CompareTo(Flag.Add) == 0)
            {
                //Set the display to the value 
                resultLabel.Content = value.ToString();
                //Perform math on the total based off the value coming in. Using the Cache.
                Total += value;
                //return the Operation to Default
                Operation = Flag.Default;
            }
            //Subtract
            else if (Operation.CompareTo(Flag.Subtract) == 0)
            {
                //Set the display to the value 
                resultLabel.Content = value.ToString();
                //Perform math on the total based off the value coming in. Using the Cache.
                Total -= value;
                //return the Operation to Default
                Operation = Flag.Default;
            }
            //Divide
            else if (Operation.CompareTo(Flag.Divide) == 0)
            {
                //Set the display to the value 
                resultLabel.Content = value.ToString();
                //Perform math on the total based off the value coming in. Using the Cache.
                Total /= value;
                //return the Operation to Default
                Operation = Flag.Default;
            }

            //Multiply
            else if (Operation.CompareTo(Flag.Multiply) == 0)
            {
                //Set the display to the value 
                resultLabel.Content = value.ToString();
                //Perform math on the total based off the value coming in. Using the Cache.
                Total *= value;
                //return the Operation to Default
                Operation = Flag.Default;
            }
            //Modulo
            else if (Operation.CompareTo(Flag.Modulo) == 0)
            {
                //Set the display to the value 
                resultLabel.Content = value.ToString();
                //Perform math on the total based off the value coming in. Using the Cache.
                Total %= value;
                //return the Operation to Default
                Operation = Flag.Default;
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
