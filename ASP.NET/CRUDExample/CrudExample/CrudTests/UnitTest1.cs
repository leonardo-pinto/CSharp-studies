namespace CrudTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            MyMath myMath = new();
            int input1 = 10;
            int input2 = 5;
            int expected = 15;

            // Act
            int actual = myMath.Add(input1, input2);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}