namespace ClientVsServerBasedLocking.ServerBased
{
    //The server
    public class ThreadSafeNumberSeries
    {
        //not real code, just some dummy implementation
        private bool HasNext()
        {
            return false;
        }

        private int GetInt()
        {
            return 12;
        }

        private object __lockObj;

        //Server based locking put all the locking to the server
        //And remove all methods that are inherently non thread-safe.
        //So clients don't have to care about locking at all
        //Clients just call and use the thread-safe methods.
        //Benefits
        //- Reduce the number of places where issues can occur.
        //- When there is some threading issue, you only look in one place.
        public bool GetNumberAndMoveNext(out int number)
        {
            //all clients calling HasNext and GetInt must implement the locking
            //otherwise there is a chance a sync issue will occur.
            //this is called client based locking
            lock (__lockObj)
            {
                var hasNext = HasNext();
                number = -1;
                if (!hasNext) { return false; }
                number = GetInt();
                return true;
            }
        }
    }

    //The client
    public class NumberSeriesUser
    {
        private readonly ThreadSafeNumberSeries _series;
        public NumberSeriesUser(ThreadSafeNumberSeries series)
        {
            _series = series;
        }
        public void Run()
        {
            while(_series.GetNumberAndMoveNext(out var number))
            {
                //do something with the value
            }
        }
    }
}
