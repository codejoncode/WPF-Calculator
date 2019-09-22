using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Calculator
{
    public class CalculatorModel
    {
        //Enum
        public enum Flag
        {
            Add,
            Subtract,
            Divide,
            Modulo,
            Equals,
            Default,
            Multiply,
        };
        //Fields 
        private string _cache = "";
        


        // Properties

        public bool Negative { get; set; }
        //My Operation is a enum  in which will help me identify which actions to take. 
        public Flag Operation { get; set; }
        public Flag LastOperation { get; set; }

        public Label ResultLabel { get; set; }

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

        //Constructor
        public CalculatorModel (Label  resultLabel)
        {
            ResultLabel = resultLabel;
            ResultLabel.Content = "0";
            Operation = Flag.Default;
            LastOperation = Flag.Default;
            
        }

        public void PerformCalculations ()
        {
            //Add
            double value = Double.Parse(ResultLabel.Content.ToString());
            if (LastOperation.CompareTo(Flag.Add) == 0)
            { 
                //Perform math on the total based off the value coming in. Using the Cache.
                Total += value;
                Console.WriteLine(Total);
                //return the Operation to Default
                Operation = Flag.Default;
                //Show the total on display
                ResultLabel.Content = Total.ToString();
            }
            //Subtract
            else if (LastOperation.CompareTo(Flag.Subtract) == 0)
            { 
                //Perform math on the total based off the value coming in. Using the Cache.
                Total -= value;
                //return the Operation to Default
                Operation = Flag.Default;
                //Show the total on display
                ResultLabel.Content = Total.ToString();
            }
            //Divide
            else if (LastOperation.CompareTo(Flag.Divide) == 0)
            {  
                //Perform math on the total based off the value coming in. Using the Cache.
                Total /= value;
                //return the Operation to Default
                Operation = Flag.Default;
                //Show the total on display
                ResultLabel.Content = Total.ToString();
            }

            //Multiply
            else if (LastOperation.CompareTo(Flag.Multiply) == 0)
            { 
                //Perform math on the total based off the value coming in. Using the Cache.
                Total *= value;
                //return the Operation to Default
                Operation = Flag.Default;
                //Show the total on display
                ResultLabel.Content = Total.ToString();
            }
            //Modulo
            else if (LastOperation.CompareTo(Flag.Modulo) == 0)
            { 
                //Perform math on the total based off the value coming in. Using the Cache.
                Total %= value;
                //return the Operation to Default
                Operation = Flag.Default;
                //Show the total on display
                ResultLabel.Content = Total.ToString();
            }
        }

        /// <summary>
        /// Used to figure out what action to take on the button that is called. 
        /// </summary>
        /// <param name="buttonName">each button has a name and this is used in a switch statement</param>
        public void ButtonHelper(string buttonName)
        {
            switch (buttonName)
            {
                //MathOperations Buttons
                case "acButton":
                    //reset display
                    ResultLabel.Content = "0";
                    //reset cache 
                    Cache = "";
                    //reset Total
                    Total = 0.0;
                    break;
                case "negativeButton":
                    ResultLabel.Content = "-";
                    //Set negative true
                    Negative = true;
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
                case "multiplyButton":
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
                    PerformCalculations();
                    break;
                case "decimalButton":
                    //if there is not a decimal already added to the string add one.
                    if (!ResultLabel.Content.ToString().Contains("."))
                    {
                        ResultLabel.Content = $"{ResultLabel.Content}.";
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
        public void EvalulateNumber(int value)
        {
            if (Operation.CompareTo(Flag.Default) == 0)
            {
                //This code block hits if Operation type Flag is set to Default. 
                if (ResultLabel.Content.ToString() == "0")
                {
                    //Set the display 
                    ResultLabel.Content = value.ToString();
                    
                    
                }
                else
                {
                    //Set the display
                    ResultLabel.Content = $"{ResultLabel.Content}{value}";
                    //set the total on conditionals  
                    //Find out if a . is used for decimal

                    //Intitially when  0.   we want to actually keep the total at 0. 
                    //bool featuresDecimal = ResultLabel.Content.ToString().Contains(".") ? true : false;

                    ////Features decimal
                    //if (featuresDecimal)
                    //{

                    //    Total = ResultLabel.Content.ToString().Length > 2 ? Double.Parse($"{ResultLabel.Content}") : 0.0;
                    //}
                    ////No decimal.
                    //else
                    //{
                    //    Total = Int32.Parse($"{ResultLabel.Content}{value}");
                    //}
                }
            }
            ////Add
            //else if (Operation.CompareTo(Flag.Add) == 0)
            //{
            //    //Set the display to the value 
            //    ResultLabel.Content = value.ToString();

            //    //return the Operation to Default
            //    LastOperation = Operation;
            //    Operation = Flag.Default;
            //}
            ////Subtract
            //else if (Operation.CompareTo(Flag.Subtract) == 0)
            //{
            //    //Set the display to the value 
            //    ResultLabel.Content = value.ToString();

            //    //return the Operation to Default
            //    LastOperation = Operation;
            //    Operation = Flag.Default;
            //}
            ////Divide
            //else if (Operation.CompareTo(Flag.Divide) == 0)
            //{
            //    //Set the display to the value 
            //    ResultLabel.Content = value.ToString();

            //    //return the Operation to Default
            //    LastOperation = Operation;
            //    Operation = Flag.Default;
            //}

            ////Multiply
            //else if (Operation.CompareTo(Flag.Multiply) == 0)
            //{
            //    //Set the display to the value 
            //    ResultLabel.Content = value.ToString();

            //    //return the Operation to Default
            //    LastOperation = Operation;
            //    Operation = Flag.Default;
            //}
            ////Modulo
            //else if (Operation.CompareTo(Flag.Modulo) == 0)
            //{
            //    //Set the display to the value 
            //    ResultLabel.Content = value.ToString();

            //    //return the Operation to Default
            //    LastOperation = Operation;
            //    Operation = Flag.Default;
            //}
            //Negative
            else if (Negative)
            {
                //Set the display to the value   i.e.   -8
                ResultLabel.Content = $"{ResultLabel.Content}{value}";
                Negative = false;

            }
            else
            {
                //Set the display to the value 
                ResultLabel.Content = value.ToString();
                //return the Operation to Default
                Operation = Flag.Default;
            }
        }

        /// <summary>
        /// This keeps me from repeating the line of code everywhere in case I need to make a change in the future. 
        /// </summary>
        public void CacheResultLabelContent()
        {
            Cache = ResultLabel.Content.ToString();
            Total = Double.Parse(Cache);
            LastOperation = Operation;
            Negative = false;
        }

        /// <summary>
        /// Resetting the cache getting ready for the next result. 
        /// </summary>
        public void ResetCache()
        {
            Cache = "";
        }
    }
}
