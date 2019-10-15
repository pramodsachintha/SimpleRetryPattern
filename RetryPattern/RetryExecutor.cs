using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetryPattern
{
    public class RetryExecutor
    {
        public RetryStrategy retryStrategy;

        public RetryExecutor(RetryStrategy retryStrategy)
        {
            this.retryStrategy = retryStrategy;
        }
        public void Retry(Action logic) 
        {
            int retries = 0;
            int maxRetries = retryStrategy.getMaxRetries();
            TimeSpan interval = retryStrategy.getTimeInterval();

            while (true)
            {
                try
                {
                    retries++;
                    logic();
                }
                catch (Exception ex)
                {
                    //log the exception 
                    if (retries == maxRetries)
                    {
                        break;
                    }
                    else 
                    {
                        Task.Delay(interval).Wait();
                    }
                }
            }
        }
    }
}
