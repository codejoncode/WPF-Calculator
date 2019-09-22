using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;
using System.Windows;
using System.Windows.Controls;

namespace Calculator.Tests
{

    [TestClass]
    public class CalculatorTests
    {
        public static Label OutPut = new Label();
        
        /// <summary>
        /// Addition equations should return the correct answer. 
        /// </summary>
        [TestMethod]
        public void AdditionOutputNonDecimal()
        {
            CalculatorModel OperationalModel = new CalculatorModel(OutPut);
            //Arrange  6 + 7 = 
            OperationalModel.ButtonHelper("sixButton");
            //6
            Console.WriteLine($"should be 6 : {OperationalModel.ResultLabel.Content}");
            OperationalModel.ButtonHelper("plusButton");
            OperationalModel.ButtonHelper("sevenButton");

            //7
            Console.WriteLine($"should be 7 : {OperationalModel.ResultLabel.Content}");
            OperationalModel.ButtonHelper("equalsButton");
            Console.WriteLine($"should be 13 : {OperationalModel.ResultLabel.Content}");
            //Act
            var expectedTotal = 13;
            var expectedDisplay = "13";
            var actualTotal = OperationalModel.Total;
            var actualDisplay = OperationalModel.ResultLabel.Content.ToString();
            //Assert 
            
            Assert.AreEqual(expectedTotal, actualTotal);
            Assert.AreEqual(expectedDisplay, actualDisplay);
        }
        /// <summary>
        /// Subtraction should return the correct answer. 
        /// </summary>
        [TestMethod]
        public void SubtractionOutputNondecimal()
        {
            //Arrange  7-6 = 
            CalculatorModel OperationalModel = new CalculatorModel(OutPut);
            OperationalModel.ButtonHelper("sevenButton");
            Console.WriteLine($"Display should be 7 : {OperationalModel.ResultLabel.Content}");
            OperationalModel.ButtonHelper("minusButton");
            Console.WriteLine($"Total Should be 7 : {OperationalModel.Total}");
            OperationalModel.ButtonHelper("sixButton");
            Console.WriteLine($"Display should be 6 : {OperationalModel.ResultLabel.Content}");
            OperationalModel.ButtonHelper("equalsButton");
            //Act
            var expectedTotal = 1;
            var expectedDisplay = "1";
            var actualTotal = OperationalModel.Total;
            var actualDisplay = OperationalModel.ResultLabel.Content.ToString();

            //Assert
            Assert.AreEqual(expectedTotal, actualTotal);
            Assert.AreEqual(expectedDisplay, actualDisplay);
        }
        /// <summary>
        /// The user should be able to perform simple multiplciation. 8 *4 and receive the correct answer.
        /// </summary>
        [TestMethod]
        public void MultiplyOutputNondecimal()
        {
            //Arrange 8 * 4 = 
            CalculatorModel OperationalModel = new CalculatorModel(OutPut);
            OperationalModel.ButtonHelper("eightButton");
            OperationalModel.ButtonHelper("multiplyButton");
            OperationalModel.ButtonHelper("fourButton");
            OperationalModel.ButtonHelper("equalsButton");
            //Act
            var expectedTotal = 32;
            var expectedDisplay = "32";
            var actualTotal = OperationalModel.Total;
            var actualDisplay = OperationalModel.ResultLabel.Content.ToString();
            //Assert
            Assert.AreEqual(expectedTotal, actualTotal);
            Assert.AreEqual(expectedDisplay, actualDisplay);
        }
        /// <summary>
        /// The User should be able to perform simple division equations   48 / 12 
        /// 8 /12. Avoiding crashing from dividing with zero is tested in another test method.
        /// </summary>
        [TestMethod]
        public void DivideOutputNondecimal()
        {
            //Arrange  48 / 12  = 
            CalculatorModel OperationalModel = new CalculatorModel(OutPut);
            OperationalModel.ButtonHelper("fourButton");
            OperationalModel.ButtonHelper("eightButton");
            Console.WriteLine($"Should be 0 : {OperationalModel.Total}");
            Console.WriteLine($"Should be 48 : {OperationalModel.ResultLabel.Content}");
            OperationalModel.ButtonHelper("divideButton");
            Console.WriteLine($"Should be 48 : {OperationalModel.Total}");
            OperationalModel.ButtonHelper("oneButton");
            OperationalModel.ButtonHelper("twoButton");
            Console.WriteLine($"Should be 12 : {OperationalModel.ResultLabel.Content}");
            OperationalModel.ButtonHelper("equalsButton");
            //Act
            var expectedTotal = 4;
            var expectedDisplay = "4";
            var actualTotal = OperationalModel.Total;
            var actualDisplay = OperationalModel.ResultLabel.Content.ToString();
            //Assert
            Assert.AreEqual(expectedTotal, actualTotal);
            Assert.AreEqual(expectedDisplay, actualDisplay);
        }
        /// <summary>
        /// The key to this method is to make sure that if a person does something like 8 + 4 = 
        /// they get 12. But if they then enter in 2 (in order to start a new equation) it does  show
        /// 122 on the screen. 
        /// </summary>
        [TestMethod]
        public void NoRepeatAfterEqualsButtonAndNewButtonIsNonOperator()
        {
            //Arrange  32 / 4 
            CalculatorModel OperationalModel = new CalculatorModel(OutPut);
            OperationalModel.ButtonHelper("threeButton");
            OperationalModel.ButtonHelper("twoButton");
            Console.WriteLine($"Display should have 32 : {OperationalModel.ResultLabel.Content}");
            OperationalModel.ButtonHelper("divideButton");
            Console.WriteLine($"Total should have 32 : {OperationalModel.Total} ");
            OperationalModel.ButtonHelper("fourButton");
            Console.WriteLine($"Display should have 4 : {OperationalModel.ResultLabel.Content}");
            OperationalModel.ButtonHelper("equalsButton");
            //Act 
            var expectedTotal = 8;
            var expectedDisplay = "8";
            var actualTotal = OperationalModel.Total;
            var actualDisplay = OperationalModel.ResultLabel.Content.ToString();
            //Assert
            Assert.AreEqual(expectedTotal, actualTotal);
            Assert.AreEqual(expectedDisplay, actualDisplay);

            //Arrange 
            OperationalModel.ButtonHelper("fourButton");
            OperationalModel.ButtonHelper("eightButton");
            Console.WriteLine($"Should be 0 : {OperationalModel.Total}");
            Console.WriteLine($"Should be 48 : {OperationalModel.ResultLabel.Content}");
            OperationalModel.ButtonHelper("divideButton");
            Console.WriteLine($"Should be 48 : {OperationalModel.Total}");
            OperationalModel.ButtonHelper("oneButton");
            OperationalModel.ButtonHelper("twoButton");
            Console.WriteLine($"Should be 12 : {OperationalModel.ResultLabel.Content}");
            OperationalModel.ButtonHelper("equalsButton");
            //Act
            expectedTotal = 4;
            expectedDisplay = "4";
            actualTotal = OperationalModel.Total;
            actualDisplay = OperationalModel.ResultLabel.Content.ToString();
            //Assert
            Assert.AreEqual(expectedTotal, actualTotal);
            Assert.AreEqual(expectedDisplay, actualDisplay);
        }

        /// <summary>
        /// Making sure the CacheResultLabelContent method does everything I would expect 
        /// </summary>
        [TestMethod]
        public void CacheResultLabelContentTest ()
        {
            //Arrange
            CalculatorModel OperationalModel = new CalculatorModel(OutPut);
            OperationalModel.ResultLabel.Content = "45.";
            OperationalModel.Operation = CalculatorModel.Flag.Add;
            OperationalModel.Negative = true;
            OperationalModel.CacheResultLabelContent();
            //Act
            var cacheExpected = "45.";
            var totalExpected = 45.0;
            CalculatorModel.Flag lastOperationExpected = CalculatorModel.Flag.Add;
            var negativeExpected = false;

            //Assert
            Assert.AreEqual(cacheExpected, OperationalModel.Cache);
            Assert.AreEqual(totalExpected, OperationalModel.Total);
            Assert.AreEqual(lastOperationExpected, OperationalModel.LastOperation);
            Assert.AreEqual(negativeExpected, OperationalModel.Negative);
        }
        /// <summary>
        /// Making sure that the EvaluateNumber method works as expected. 
        /// It takes one  parmater and then peforms actions based off the 
        /// ResultLabel.Content.
        /// </summary>
        [TestMethod]
        public void EvalulateNumberTest()
        {
            //EvalulateNumber(int value)
            //Act
            CalculatorModel OperationalModel = new CalculatorModel(OutPut);

            //Arrange : For Flag to be default and Content to be "0"
            OperationalModel.EvalulateNumber(5);
            //Act
            var expected = "5";
            //Assert
            Assert.AreEqual(expected, OperationalModel.ResultLabel.Content.ToString());
            //Arrange : For Flag to be default and Content to have a value other than "0"
            OperationalModel.EvalulateNumber(6);
            //Act
            expected = "56";
            //Assert
            Assert.AreEqual(expected, OperationalModel.ResultLabel.Content.ToString());
            //Arrange: for when the default is set but Reset is true  
            OperationalModel.Reset = true;
            OperationalModel.EvalulateNumber(9);
            //Act
            expected = "9";
            //Assert
            Assert.AreEqual(expected, OperationalModel.ResultLabel.Content.ToString());
            //Arrange : different flag
            OperationalModel.Operation = CalculatorModel.Flag.Add;
            OperationalModel.EvalulateNumber(2);
            //Act
            expected = "2";
            //Assert
            Assert.AreEqual(expected, OperationalModel.ResultLabel.Content.ToString());
        }
    }
}
