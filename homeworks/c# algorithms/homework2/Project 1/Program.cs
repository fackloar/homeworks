using System;

namespace Project_1
{

    public class Node
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }
    }



    //Начальную и конечную ноду нужно хранить в самой реализации интерфейса
    public interface ILinkedList
    {
        int GetCount(); // возвращает количество элементов в списке
        void AddNode(int value);  // добавляет новый элемент списка
        void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
        void RemoveNode(int index); // удаляет элемент по порядковому номеру
        void RemoveNode(Node node); // удаляет указанный элемент
        Node FindNode(int searchValue); // ищет элемент по его значению
    }

    public class ImpClass : ILinkedList
    {
        Node firstNode = new Node();
        Node lastNode = new Node();

        public void AddNode(int value)
        {
            var newNode = new Node { Value = value };
            var last = firstNode;
            newNode.NextNode = null;

            if (firstNode == null)
            {
                newNode.PrevNode = null;
                firstNode = newNode;
                return;
            }

            while (last.NextNode != null)
                last = last.NextNode;

            last.NextNode = newNode;
            newNode.PrevNode = last;
        }

        public void AddNodeAfter(Node node, int value)
        {
            var newNode = new Node { Value = value };
            newNode.NextNode = node.NextNode;
            node.NextNode = newNode;
            newNode.PrevNode = node;

            if (newNode.NextNode != null)
                newNode.NextNode.PrevNode = newNode;
        }

        public Node FindNode(int searchValue)
        {
            Node temp = firstNode;
            int pos = 0;

            while (temp.Value != searchValue && temp.NextNode != null)
            {
                pos++;
                temp = temp.NextNode;
            }

            return (temp);
        }

        public int GetCount()
        {
            Node temp = new Node();
            temp = this.firstNode;
            int i = 0;

            while (temp != null)
            {
                i++;
                temp = temp.NextNode;
            }

            return i;
        }

        public void RemoveNode(Node node)
        {
            if (firstNode == null || node == null)
            {
                return;
            }

            if (firstNode == node)
            {
                firstNode = node.NextNode;
            }

            if (node.NextNode != null)
            {
                node.NextNode.PrevNode = node.PrevNode;
            }

            if (node.PrevNode != null)
            {
                node.PrevNode.NextNode = node.NextNode;
            }

            return;
        }
        public void RemoveNode(int index)
        {
            if (firstNode == null || index <= 0)
                return;

            Node current = firstNode;
            int i;

            for (i = 1; current != null && i < index; i++)
            {
                current = current.NextNode;
            }

            if (current == null)
                return;

            RemoveNode(current);
        }


        public void TraverseFront(Node node)

        {

            while (node != null)

            {

               Console.Write($"{node.Value}, ");

                node = node.NextNode;

            }

        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var List = new ImpClass();
            int[] Test = { 1, 20, 300, 4000, 50000 };
            for (int i =0; i < Test.Length; i++)
            {
                List.AddNode(Test[i]);   // list: 0, 1, 20, 300, 4000, 50000
            }                      
            
            int count = List.GetCount();
            int expectedCount = 6;
            Console.WriteLine($"expected result of GetCount: {expectedCount}\nactual result of GetCount: {count}");

            List.AddNodeAfter(List.FindNode(300), 500); // list: 0, 1, 20, 300, 500, 4000, 50000
            List.RemoveNode(6);  // list: 0, 1, 20, 300, 500, 50000

            int[] expectedArray = { 0, 1, 20, 300, 500, 50000 };
            Console.WriteLine("expected list: ");
            for (int i = 0; i < expectedArray.Length; i++)
            {
                Console.Write($"{expectedArray[i]}, ");
            }
            Console.WriteLine();
            Console.WriteLine("actual list: ");
            List.TraverseFront(List.FindNode(0));
            Console.ReadKey();


        }
    }
}
