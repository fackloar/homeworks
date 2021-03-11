using System;
using System.Collections.Generic;
using System.Text;

namespace Project_2
{
    public class TreeNode: ITree
    {
        public int Value { get; set; }
        public TreeNode LeftChild { get; set; }
        public TreeNode RightChild { get; set; }
        public TreeNode Parent { get; set; }
        public TreeNode Root { get; set; }
        public TreeNode Current { get; set; }
        public TreeNode(int value)
        {
            Value = value;
        }
        public TreeNode GetRoot()
        {
            return Root;
        }
        public TreeNode GetMax(TreeNode current)
        {
            while (current.RightChild != null)
            {
                current = current.RightChild;
            }
            return current;
        }
        public override bool Equals(object obj)
        {
            var node = obj as TreeNode;

            if (node == null)
                return false;

            return node.Value == Value;
        }
        public void AddItem(int value)
        {
            TreeNode newNode = new TreeNode(value);
            if (Root == null) //add first node
                Root = newNode;
            else
            {
                Current = Root;
                while (true)
                {
                    Parent = Current;
                    if (newNode.Value < Current.Value)
                    {
                        Current = Current.LeftChild;
                        if (Current == null)
                        {
                            Parent.LeftChild = newNode;
                            newNode.Parent = Parent;
                            return;
                        }
                    }
                    else
                    {
                        Current = Current.RightChild;
                        if (Current == null)
                        {
                            Parent.RightChild = newNode;
                            newNode.Parent = Parent;
                            return;
                        }
                    }
                }
            }
        }
        public void RemoveItem(int value)
        {
            TreeNode tempDelete = this.GetNodeByValue(value);

            if (tempDelete.LeftChild != null && tempDelete.RightChild != null) //both children
            {
                TreeNode localMax = GetMax(tempDelete.LeftChild);
                tempDelete.Value = localMax.Value;
                if (localMax.LeftChild != null)
                {
                    //only left child
                    if (localMax == localMax.Parent.LeftChild)
                    {
                        localMax.Parent.LeftChild = localMax.LeftChild;
                    }
                    else
                    {
                        localMax.Parent.RightChild = localMax.LeftChild;
                    }
                }
                else if (localMax.RightChild != null)
                {
                    //only right child
                    if (localMax == localMax.Parent.RightChild)
                    {
                        localMax.Parent.RightChild = localMax.RightChild;
                    }
                    else
                    {
                        localMax.Parent.LeftChild = localMax.RightChild;
                    }
                }
                else
                {
                    //no children
                    if (localMax == localMax.Parent.LeftChild)
                        localMax.Parent.LeftChild = null;
                    else
                        localMax.Parent.RightChild = null;
                }
                return;
            }
            else if (tempDelete.LeftChild != null)
            {
                //only left child
                if (tempDelete == tempDelete.Parent.LeftChild)
                {
                    tempDelete.Parent.LeftChild = tempDelete.LeftChild;
                }
                else
                {
                    tempDelete.Parent.RightChild = tempDelete.LeftChild;
                }
            }
            else if (tempDelete.RightChild != null)
            {
                // Only right child
                if (tempDelete == tempDelete.Parent.RightChild)
                {
                    tempDelete.Parent.RightChild = tempDelete.RightChild;
                }
                else
                {
                    tempDelete.Parent.LeftChild = tempDelete.RightChild;
                }
            }
            else
            {
                //No children
                if (tempDelete == tempDelete.Parent.LeftChild)
                    tempDelete.Parent.LeftChild = null;
                else
                    tempDelete.Parent.RightChild = null;
            }
        }
        public TreeNode GetNodeByValue(int value)
        {
            Current = Root;
            if (Root == null || Root.Value == value) //root is empty; new tree
                return Root;
            try
            {
                while (true)
                {
                    // value < root's value => go right
                    if (Current.Value < value)
                    {
                        Current = Current.RightChild;
                    }

                    // value > root's value => go left
                    else if (Current.Value > value)
                    {
                        Current = Current.LeftChild;
                    }

                    else if (Current.Value == value) // found it!
                    {
                        return Current;
                    }
                }
                
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("No such number");
                int mistake =+ 1;
                return Root;
            }
        }
        public void PrintTree()
        {
            int topMargin = 2;
            int leftMargin = 2;
            if (Root == null) return;
            int rootTop = Console.CursorTop + topMargin;
            var last = new List<NodeInfo>();
            var next = Root;
            for (int level = 0; next != null; level++)
            {
                var value = new NodeInfo { Node = next, Text = next.Value.ToString(" 0 ") };
                if (level < last.Count)
                {
                    value.StartPos = last[level].EndPos + 1;
                    last[level] = value;
                }
                else
                {
                    value.StartPos = leftMargin;
                    last.Add(value);
                }
                if (level > 0)
                {
                    value.Parent = last[level - 1];
                    if (next == value.Parent.Node.LeftChild)
                    {
                        value.Parent.LeftChild = value;
                        value.EndPos = Math.Max(value.EndPos, value.Parent.StartPos);
                    }
                    else
                    {
                        value.Parent.RightChild = value;
                        value.StartPos = Math.Max(value.StartPos, value.Parent.EndPos);
                    }
                }
                next = next.LeftChild ?? next.RightChild;
                for (; next == null; value = value.Parent)
                {
                    Print(value, rootTop + 2 * level);
                    if (--level < 0) break;
                    if (value == value.Parent.LeftChild)
                    {
                        value.Parent.StartPos = value.EndPos;
                        next = value.Parent.Node.RightChild;
                    }
                    else
                    {
                        if (value.Parent.LeftChild == null)
                            value.Parent.EndPos = value.StartPos;
                        else
                            value.Parent.StartPos += (value.StartPos - value.Parent.EndPos) / 2;
                    }
                }
            }
            Console.SetCursorPosition(0, rootTop + 2 * last.Count - 1);
        }

        private static void Print(NodeInfo item, int top)
        {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.Black;
            Print(item.Text, top, item.StartPos);
            Console.ResetColor();
            if (item.LeftChild != null)
                PrintLink(top + 1, "┌", "┘", item.LeftChild.StartPos + item.LeftChild.Size / 2, item.StartPos);
            if (item.RightChild != null)
                PrintLink(top + 1, "└", "┐", item.EndPos - 1, item.RightChild.StartPos + item.RightChild.Size / 2);
        }

        private static void PrintLink(int top, string start, string end, int startPos, int endPos)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Print(start, top, startPos);
            Print("─", top, startPos + 1, endPos);
            Print(end, top, endPos);
            Console.ResetColor();
        }

        private static void Print(string s, int top, int left, int right = -1)
        {
            Console.SetCursorPosition(left, top);
            if (right < 0) right = left + s.Length;
            while (Console.CursorLeft < right) Console.Write(s);
        }

    }
}
