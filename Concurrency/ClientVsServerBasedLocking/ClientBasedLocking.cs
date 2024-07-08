namespace ClientVsServerBasedLocking.ClientBased
{
    //The server
    public class NumberSeries
    {
        //not real code, just some dummy implementation
        public bool HasNext()
        {
            return false;
        }

        public int GetInt()
        {
            return 12;
        }
    }

    //The client
    public class NumberSeriesUser
    {
        private readonly NumberSeries _series;
        private object __lockObj;
        public NumberSeriesUser(NumberSeries series)
        {
            _series = series;
        }
        public void Run()
        {
            while(GetNumberAndMoveNext(out var number))
            {
                //do something
            }
        }

        private bool GetNumberAndMoveNext(out int number)
        {
            //all clients calling HasNext and GetInt must implement the locking
            //otherwise there is a chance a sync issue will occur.
            //this is called client based locking
            lock(__lockObj) {
                var hasNext = _series.HasNext();
                number = -1;
                if(!hasNext) { return false; }
                number = _series.GetInt();
                return true;
            }
        }
    }
}
