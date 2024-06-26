﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableLib
{
    internal class HashMaker<T>
    {
        public int SimpleNumber { get; set; }
        public HashMaker()
        {
            SimpleNumber = 61;
        }
        public HashMaker(int divider)
        {
            SimpleNumber = divider;
        }
        public int ReturnHash(T key)
        {
            return (key.GetHashCode() & 0x7FFFFFFF) % SimpleNumber;
        }
    }
}
