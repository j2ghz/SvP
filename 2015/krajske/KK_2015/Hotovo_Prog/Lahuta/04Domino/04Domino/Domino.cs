using System;

namespace _04Domino
{
    public struct Domino
    {
        public byte A
        {
            get;
            set;
        }

        public byte B
        {
            get;
            set;
        }

        public override string ToString()
        {
            return "[" + A + ":" + B + "]";
        }
    }
}
