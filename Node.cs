using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeAssignment
{
   public class Node
    {
        public string Data;
        public Node left, right;
        public int length;
        public Node()
        {
            Data = null;
            left = null;
            right = null;
            length = 0;
        }

        public Node(string data, int length)
        {
            Data = data;
            left = right = null;
            this.length = data.Length;
                
        }

        public override string ToString()
        {
            return $"{Data} Length: {length}";
        }
    }
}
