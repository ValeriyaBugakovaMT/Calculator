using System.Runtime.Serialization;

namespace CalculatorTest
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        [DataRow("","", "0")]
        [DataRow("", "1", "1")]
        [DataRow("1", "", "1")]
        [DataRow("error", "1","1")]
        [DataRow("1", "error","1")]
        public void TestCalculatorWrongNumbers(string firstNumber, string secondNumber, string result)
        {
            Calculator.Logic.Calculator calculator = new Calculator.Logic.Calculator
                (firstNumber, secondNumber, "Plus");
            Assert.AreEqual(result, calculator.Calculate().ToString());
        }

        [TestMethod]
        [DataRow("")]
        [DataRow("error")]
        public void TestCalculatorWrongOperatorForFirstNumber(string operatorString)
        {
            Calculator.Logic.Calculator calculator = new Calculator.Logic.Calculator
                ("1", "0", operatorString);
            Assert.AreEqual(1, calculator.Calculate());
        }

        [TestMethod]
        [DataRow("")]
        [DataRow("error")]
        public void TestCalculatorWrongOperatorForSecondNumber(string opr)
        {
            Calculator.Logic.Calculator calculator = new Calculator.Logic.Calculator
                ("0", "1", opr);
            Assert.AreEqual(0, calculator.Calculate());
        }

        [TestMethod]
        [DataRow("1","2","Plus","3")]
        [DataRow("2","1","Minus","1")]
        [DataRow("2", "1", "Multiply", "2")]
        [DataRow("4", "2", "Divide", "2")]
        [DataRow("1.5", "1.5", "Plus", "3.0")]
        public void TestCalculatorRigthData(string firstNumber, string secondNumber, string opr, string result)
        {
            Calculator.Logic.Calculator calculator = new Calculator.Logic.Calculator
                (firstNumber, secondNumber, opr);
            Assert.AreEqual(result, calculator.Calculate().ToString());
        }
    }
}