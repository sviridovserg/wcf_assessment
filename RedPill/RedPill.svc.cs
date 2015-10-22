using RedPill.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace RedPill
{
    [ServiceBehavior(Namespace = "http://KnockKnock.readify.net")]
    public class RedPill : IRedPill
    {
        private INumberService _numberService;
        private IWordService _wordService;
        private ITriangleService _triangleService;
        private Guid _token = new Guid("1b5c48fb-86ff-4e2d-ac27-d4f51069f2ff");

        public RedPill(INumberService numberService, IWordService wordService, ITriangleService triangleService) {
            _numberService = numberService;
            _wordService = wordService;
            _triangleService = triangleService;
        }

        public long FibonacciNumber(long n)
        {
            if (Math.Abs(n) > 92)
            {
                throw new ArgumentOutOfRangeException("n", "Fib(>92) will cause a 64-bit integer overflow.");
            }
            return _numberService.GetFibonacciNumber(n);
        }

        
        public string ReverseWords(string s) 
        {
            if (s == null) 
            {
                throw new ArgumentNullException("s", "Value cannot be null");
            }
            return _wordService.ReverseWords(s);
        }

        
        public TriangleType WhatShapeIsThis(int a, int b, int c) 
        {
            return _triangleService.WhatShapeIsThis(a, b, c);
        }

        public Guid WhatIsYourToken() {
            return _token;
        }
    }
}
