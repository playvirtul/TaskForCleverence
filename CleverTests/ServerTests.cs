using Clever;

namespace CleverTests
{
    public class ServerTests
    {
        [Fact]
        public void AddToCount_ShouldAddValueToCount()
        {
            // arrange
            var tasks = new List<Task>();
            var result = 1000;

            // act
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    tasks.Add(
                        Task.Factory.StartNew((() => Server.GetCount())));
                }
                tasks.Add(
                    Task.Factory.StartNew(() => Server.AddToCount(1)));
            }

            Task.WaitAll(tasks.ToArray());

            // assert
            Assert.Equal(result, Server.GetCount());
        }
    }
}