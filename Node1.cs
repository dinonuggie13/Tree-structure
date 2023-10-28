using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeAssignment
{
    internal class Node1
    {
        public string Data { get; set; }

        public Node1 Left;

        public Node1 Right;

        public int Length;

        public Node1()
        {
            Data = null;
            Left = null;
            Right = null;
            Length = 0;

        }

        public Node1(string data, int length)
        {
            Data = data;
            Left = null;
            Right = null;
            length = data.Length;
        }


        public override string ToString()
        {
            return $"{Data} Length: {Length}";
        }
    }
}
