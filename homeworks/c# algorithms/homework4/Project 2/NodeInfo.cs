using System;
using System.Collections.Generic;
using System.Text;

namespace Project_2
{
    public class NodeInfo
    {
        public int Depth { get; set; }
        public TreeNode Node { get; set; }
        public string Text;
        public int StartPos;
        public int Size { get { return Text.Length; } }
        public int EndPos { get { return StartPos + Size; } set { StartPos = value - Size; } }
        public NodeInfo Parent, LeftChild, RightChild;
    }
}
