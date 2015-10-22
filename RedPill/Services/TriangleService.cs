using RedPill.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedPill.Services
{
    public class TriangleService: ITriangleService
    {
        private bool IsTriangle(int a, int b, int c) 
        {
            if (a <= 0 || b <= 0 || c <= 0) {
                return false;
            }
            if ((a >= b + c) || (b >= a + c) || (c >= b + a)) 
            {
                return false;
            }
            return true;
        }

        private bool IsEquilateral(int a, int b, int c) 
        {
            return a == b && b == c;
        }

        private bool IsIsosceles(int a, int b, int c) 
        {
            return a == b || a == c || b == c;
        }

        public TriangleType WhatShapeIsThis(int a, int b, int c)
        {
            if (!IsTriangle(a, b, c)) 
            {
                return TriangleType.Error;
            }
            if (IsEquilateral(a, b, c)) 
            {
                return TriangleType.Equilateral;
            }
            if (IsIsosceles(a, b, c))
            {
                return TriangleType.Isosceles;
            }
            return TriangleType.Scalene;
        }
    }
}