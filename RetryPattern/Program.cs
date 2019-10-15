using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetryPattern
{
    class Program
    {
        public static void Main(string[] args)
        {
            DataService dataService = new DataService();
            dataService.GetData();
        }
    }
}
