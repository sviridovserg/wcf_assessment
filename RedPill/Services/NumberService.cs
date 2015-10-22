using RedPill.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedPill.Services
{
    internal class NumberService : INumberService
    {
        private long GetPositiveFibonacciNumber(long n) {
            if (n <= 2) {
                return 1;
            }
            long n2 = 1;
            long n1 = 1;
            long result = 0;
            for (int i = 2; i < n; i++) {
                result = n2 + n1;
                n2 = n1;
                n1 = result;
            }
            return result;
        }

        public long GetFibonacciNumber(long n)
        {
            if (n == 0) {
                return 0;
            }
            else if (n > 0)
            {
                return GetPositiveFibonacciNumber(n);
            }
            else
            {
                var f = GetPositiveFibonacciNumber(Math.Abs(n));
                if ((n + 1) % 2 == 0) 
                {
                    return f;
                }
                return -f;
            }
        }
    }
}