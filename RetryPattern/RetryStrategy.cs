using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetryPattern
{
    public class RetryStrategy
    {
        private int MaxRetries { get; set; }

        private TimeSpan Interval { get; set; }

        public RetryStrategy(int maxRetries, TimeSpan interval)
        {
            this.MaxRetries = maxRetries;
            this.Interval = interval;
        }

        public int getMaxRetries() 
        {
            return MaxRetries;
        }

        public TimeSpan getTimeInterval() 
        {
            return Interval;
        }
    }
}
