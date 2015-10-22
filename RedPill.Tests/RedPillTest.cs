using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedPill.Interfaces;
using RedPill.Services;

namespace RedPill.Tests
{
    [TestClass]
    public class RedPillTest
    {
        private IRedPill _redPillService;

        [TestInitialize]
        public void Init() 
        {
            _redPillService = new RedPill(new NumberService(), new WordService(), new TriangleService());
        }

        [TestMethod]
        public void GetFibonacciNumberZeroInput()
        {
            Assert.AreEqual(0, _redPillService.FibonacciNumber(0));
        }

        [TestMethod]
        public void GetFibonacciNumberPositiveInput()
        {
            Assert.AreEqual(8, _redPillService.FibonacciNumber(6));
        }

        [TestMethod]
        public void GetFibonacciNumberNegativeInputOdd() 
        {
            Assert.AreEqual(-8, _redPillService.FibonacciNumber(-6));
        }

        [TestMethod]
        public void GetFibonacciNumberNegativeInputEven()
        {
            Assert.AreEqual(13, _redPillService.FibonacciNumber(-7));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetFibonacciNumberNegativeInputNegativeOutOfRange()
        {
            _redPillService.FibonacciNumber(-900);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetFibonacciNumberNegativeInputPositiveOutOfRange()
        {
            _redPillService.FibonacciNumber(900);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReverseWordsInputNull()
        {
            _redPillService.ReverseWords(null);
        }

        [TestMethod]
        public void ReverseWordsInputSingleWord()
        {
            Assert.AreEqual("fdsa", _redPillService.ReverseWords("asdf"));
        }

        [TestMethod]
        public void ReverseWordsInputEmpty()
        {
            Assert.AreEqual(String.Empty, _redPillService.ReverseWords(String.Empty));
        }

        [TestMethod]
        public void ReverseWordsInputTwoWords()
        {
            Assert.AreEqual("fdsa     hgfd", _redPillService.ReverseWords("asdf     dfgh"));
        }

        [TestMethod]
        public void ReverseWordsInputTwoWordsTrailingWhiteSpace()
        {
            Assert.AreEqual("fdsa     hgfd   ", _redPillService.ReverseWords("asdf     dfgh   "));
        }

        [TestMethod]
        public void ReverseWordsInputTwoWordsTrailingLeadingWhiteSpace()
        {
            Assert.AreEqual("    fdsa     hgfd   ", _redPillService.ReverseWords("    asdf     dfgh   "));
        }

        [TestMethod]
        public void ReverseWordsInputTwoWordsUTF16SupplementaryCharecters()
        {
            Assert.AreEqual("ोलैह  €𐐷 ", _redPillService.ReverseWords("हैलो  𐐷€ "));
        }

        [TestMethod]
        public void WhatShapeIsThisNegativeArgument1()
        {
            Assert.AreEqual(TriangleType.Error, _redPillService.WhatShapeIsThis(-1, 1, 1));
        }

        [TestMethod]
        public void WhatShapeIsThisNegativeArgument2()
        {
            Assert.AreEqual(TriangleType.Error, _redPillService.WhatShapeIsThis(1, -1, 1));
        }

        [TestMethod]
        public void WhatShapeIsThisNegativeArgument3()
        {
            Assert.AreEqual(TriangleType.Error, _redPillService.WhatShapeIsThis(1, 1, -1));
        }

        [TestMethod]
        public void WhatShapeIsThisNotTriangle1()
        {
            Assert.AreEqual(TriangleType.Error, _redPillService.WhatShapeIsThis(3, 1, 1));
        }

        [TestMethod]
        public void WhatShapeIsThisNotTriangle2()
        {
            Assert.AreEqual(TriangleType.Error, _redPillService.WhatShapeIsThis(1, 2, 1));
        }

        [TestMethod]
        public void WhatShapeIsThisNotTriangle3()
        {
            Assert.AreEqual(TriangleType.Error, _redPillService.WhatShapeIsThis(1, 1, 3));
        }

        [TestMethod]
        public void WhatShapeIsThisEquilateral()
        {
            Assert.AreEqual(TriangleType.Equilateral, _redPillService.WhatShapeIsThis(1, 1, 1));
        }

        [TestMethod]
        public void WhatShapeIsThisIsosceles()
        {
            Assert.AreEqual(TriangleType.Isosceles, _redPillService.WhatShapeIsThis(3, 3, 2));
        }

        [TestMethod]
        public void WhatShapeIsThisScalene()
        {
            Assert.AreEqual(TriangleType.Scalene, _redPillService.WhatShapeIsThis(3, 4, 5));
        }

        [TestMethod]
        public void WhatIsYoutTokenCorrect()
        {
            Assert.AreEqual(new Guid("1b5c48fb-86ff-4e2d-ac27-d4f51069f2ff"), _redPillService.WhatIsYourToken());
        }
    }
}
