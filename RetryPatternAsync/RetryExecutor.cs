using System;
using System.Threading.Tasks;

namespace RetryPatternAsync {
    public class RetryExecutor {
        public RetryStrategy RetryStrategy;

        public RetryExecutor(RetryStrategy retryStrategy) {
            RetryStrategy = retryStrategy;
        }

        public async Task Retry(Func<Task> logic) {
            var retries = 0;
            var maxRetries = RetryStrategy.GetMaxRetries();
            var interval = RetryStrategy.GetTimeInterval();

            while (true) {
                try {
                    retries++;
                    await logic();
                    break;
                } catch (Exception ex) {
                    //log the exception 
                    Console.WriteLine($"Unable to execute code block, try number {retries} of {maxRetries}. {ex.Message}");
                    if (retries <= maxRetries) {
                        break;
                    }
                    await Task.Delay(interval);
                }
            }
        }
    }
}
