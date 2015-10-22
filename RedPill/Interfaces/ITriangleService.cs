using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RedPill.Interfaces
{
    [DataContract(Namespace="http://KnockKnock.readify.net")]
    public enum TriangleType
    {
        [EnumMember(Value = "Error")]
        Error,
        [EnumMember(Value = "Equilateral")]
        Equilateral,
        [EnumMember(Value = "Isosceles")]
        Isosceles,
        [EnumMember(Value = "Scalene")]
        Scalene
    }

    public interface ITriangleService
    {
        TriangleType WhatShapeIsThis(int a, int b, int c);
    }
}
