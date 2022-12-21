namespace WebApi.Business
{
    public class ClassUnderTest
    {
        public int Sum(int x, int y) => x + y;
        public float Div(int x, int y) => y != 0 ? (float)x / y : throw new ArgumentException("Attempt to divide by zero");
    }
}