using Xunit;
using task11;

namespace task11tests
{
    public class CalculatorTests
    {
        public ICalculator getTestCalc()
        {
            string calculatorCode = @"
            public class Calculator : ICalculator
            {
                public int Add(int a, int b) => a + b;
                public int Minus(int a, int b) => a - b;
                public int Mul(int a, int b) => a * b;
                public int Div(int a, int b) => a / b;
            }
        ";
            CalculatorGenerator calculatorGenerator = new CalculatorGenerator();
            ICalculator calculator = calculatorGenerator.CompileCalculator(calculatorCode);
            return calculator;
        }

        [Fact]
        public void TestAdd_ReturnsCorrectAnsw()
        {
            ICalculator calculator = getTestCalc();
            int result = calculator.Add(5, 3);
            Assert.Equal(8, result);
        }

        [Fact]
        public void TestMinus_ReturnsCorrectAnsw()
        {
            ICalculator calculator = getTestCalc();
            int result = calculator.Minus(5, 3);
            Assert.Equal(2, result);
        }

        [Fact]
        public void TestMul_ReturnsCorrectAnsw()
        {

            ICalculator calculator = getTestCalc();
            int result = calculator.Mul(5, 3);
            Assert.Equal(15, result);
        }

        [Fact]
        public void TestDiv_ReturnsCorrectAnsw()
        {
            ICalculator calculator = getTestCalc();
            int result = calculator.Div(6, 3);
            Assert.Equal(2, result);
        }

        [Fact]
        public void TestAllOperationa()
        {
            ICalculator calculator = getTestCalc();
            Assert.Equal(10, calculator.Add(7, 3));
            Assert.Equal(4, calculator.Minus(7, 3));
            Assert.Equal(21, calculator.Mul(7, 3));
            Assert.Equal(2, calculator.Div(7, 3));
        }
    }
}
