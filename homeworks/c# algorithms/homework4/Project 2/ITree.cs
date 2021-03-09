using System;
using System.Collections.Generic;
using System.Text;

namespace Project_2
{
    public interface ITree
    {
        public TreeNode GetRoot();
        void AddItem(int value); // добавить узел
        void RemoveItem(int value); // удалить узел по значению
        TreeNode GetNodeByValue(int value); //получить узел дерева по значению
        void PrintTree(); //вывести дерево в консоль
    }
}
