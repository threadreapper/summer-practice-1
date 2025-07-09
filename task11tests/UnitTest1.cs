using Xunit;
using task11;

namespace task11tests
{
    public class CalculatorTests
    {
        [Fact]
        public void TestAdd_ReturnsCorrectAnsw()
        {
            dynamic calculator = CalculatorGenerator.GenerateCalc();
            int result = calculator.Add(5, 3);
            Assert.Equal(8, result);
        }

        [Fact]
        public void TestMinus_ReturnsCorrectAnsw()
        {
            dynamic calculator = CalculatorGenerator.GenerateCalc();
            int result = calculator.Minus(5, 3);
            Assert.Equal(2, result);
        }

        [Fact]
        public void TestMul_ReturnsCorrectAnsw()
        {
            dynamic calculator = CalculatorGenerator.GenerateCalc();
            int result = calculator.Mul(5, 3);
            Assert.Equal(15, result);
        }

        [Fact]
        public void TestDiv_ReturnsCorrectAnsw()
        {
            dynamic calculator = CalculatorGenerator.GenerateCalc();
            int result = calculator.Div(6, 3);
            Assert.Equal(2, result);
        }

        [Fact]
        public void TestAllOperationa()
        {
            dynamic calculator = CalculatorGenerator.GenerateCalc();

            Assert.Equal(10, calculator.Add(7, 3));
            Assert.Equal(4, calculator.Minus(7, 3));
            Assert.Equal(21, calculator.Mul(7, 3));
            Assert.Equal(2, calculator.Div(7, 3));
        }
    }
}
