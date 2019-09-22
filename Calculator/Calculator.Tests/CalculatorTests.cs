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
            
            //Assert.AreEqual(expectedTotal, actualTotal);
            Assert.AreEqual(expectedDisplay, actualDisplay);
        }

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
    }
}
