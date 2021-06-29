using System;

namespace RetryPatternAsync {
    public class RetryStrategy {
        private int MaxRetries { get; }
        private TimeSpan Interval { get; }

        public RetryStrategy(int maxRetries, TimeSpan interval) {
            MaxRetries = maxRetries;
            Interval = interval;
        }

        public int GetMaxRetries() => MaxRetries;
        public TimeSpan GetTimeInterval() => Interval;
    }
}
