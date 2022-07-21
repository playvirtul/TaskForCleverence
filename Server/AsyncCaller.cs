namespace Clever
{
    public class AsyncCaller
    {
        private readonly EventHandler _handler;

        public AsyncCaller(EventHandler handler)
        {
            _handler = handler;
        }

        public bool Invoke(int milliseconds, object sender, EventArgs args)
        {
            var task = Task.Factory.StartNew(() => _handler.Invoke(sender, args));

            return task.Wait(milliseconds);
        }
    }
}
