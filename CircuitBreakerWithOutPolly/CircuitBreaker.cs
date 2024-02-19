namespace CircuitBreakerWithOutPolly
{
    public  class CircuitBreaker
    {
        private readonly TimeSpan _timeout;
        private readonly int _retryLimit;
        private int _retryCount;
        private DateTime _lastFailedAttempt;
        public CircuitBreaker(TimeSpan timeout, int retryLimit)
        {
            _timeout = timeout;
            _retryLimit = retryLimit;
            _retryCount = 0;
            _lastFailedAttempt = DateTime.MinValue;

        }
        public bool IsCircuitOpen
        {
            get
            {
                if (_retryCount < _retryLimit) return false;
                if (DateTime.UtcNow - _lastFailedAttempt > _timeout)
                {
                    _retryCount = 0;
                    return false;
                }
                return true;
            }
        }

        public void RecordFailure()
        {
            _retryCount++;
            _lastFailedAttempt = DateTime.UtcNow;
        }

        public void Reset()
        {
            _retryCount = 0;
        }

    }
}
