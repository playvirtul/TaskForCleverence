namespace Clever
{
    public static class Server
    {
        private static int _count;

        private static ReaderWriterLock _locker = new ReaderWriterLock();

        public static int GetCount()
        {
            _locker.AcquireReaderLock(Timeout.InfiniteTimeSpan);
            try
            {
                return _count;
            }
            finally
            {
                _locker.ReleaseReaderLock();
            }
        }

        public static void AddToCount(int value)
        {
            _locker.AcquireWriterLock(Timeout.InfiniteTimeSpan);
            try
            {
                Interlocked.Add(ref _count, value);
            }
            finally 
            { 
                _locker.ReleaseWriterLock();
            }
        }
    }
}