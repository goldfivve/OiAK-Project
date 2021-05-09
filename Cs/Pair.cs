using System;
using System.Collections;
using System.Collections.Generic;

namespace Cs {
    public class Pair : IComparable<Pair>{
        public int first;
        public int second;

        public Pair(int f, int s) {
            first = f;
            second = s;
        }

        public int CompareTo(Pair other) {
            return first.CompareTo(other.first);
        }

    }
}