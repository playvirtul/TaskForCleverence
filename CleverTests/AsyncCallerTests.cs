using Clever;

namespace CleverTests
{
    public class AsyncCallerTests
    {
        [Fact]
        public void Invoke_ShouldReturnTrue()
        {
            // arrange
            var handler = new EventHandler((sender, args) => Thread.Sleep(1000));
            var caller = new AsyncCaller(handler);

            // act
            var result = caller.Invoke(1500, null, EventArgs.Empty);

            // assert
            Assert.True(result);
        }

        [Fact]
        public void Invoke_ShouldReturnFalse()
        {
            // arrange
            var handler = new EventHandler((sender, args) => Thread.Sleep(1000));
            var caller = new AsyncCaller(handler);

            // act
            var result = caller.Invoke(500, null, EventArgs.Empty);

            // assert
            Assert.False(result);
        }
    }
}
