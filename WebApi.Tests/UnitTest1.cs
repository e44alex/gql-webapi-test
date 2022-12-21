using WebApi.Business;
using WebApi.Data.Fakers;

namespace WebApi.Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(1, 2, 3)]
        public void ClassUnderTest_Sum_ShouldReturnValidSum(int x, int y, int expected)
        {
            var classUnderTest = new ClassUnderTest();

            var result = classUnderTest.Sum(x, y);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, 2, 0.5)]
        [InlineData(2, 1, 2)]
        public void ClassUnderTest_Div_ShouldReturnValidDiv(int x, int y, float expected)
        {
            var classUnderTest = new ClassUnderTest();

            var result = classUnderTest.Div(x, y);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, 0)]
        public void ClassUnderTest_Div_ShouldThrowOnSecondArgZero(int x, int y)
        {
            var classUnderTest = new ClassUnderTest();

            var exception = Assert.Throws<ArgumentException>(() => classUnderTest.Div(x, y));
            Assert.Equal("Attempt to divide by zero", exception.Message);
        }

        [Theory]
        [InlineData(10)]
        public void DataFaker_ShouldCreateFakes(int count)
        {
            var data = DataFakers.MessageFaker.Generate(count);

            Assert.Equal(count, data.Count);
        }
    }
}