using System;
using System.IO;

namespace list
{
    public class Node{
        public int data;
        public Node next;
        public Node(int data)
        {
            this.data = data;
            next = null;
        }
    }
    public class ListC
    {
        public Node head;
        public int length;
        public ListC()
        {
            length = 0;
            head = null;
        }
        public void AddToBegin(int data)
        {
            Node node = new Node(data);
            length++;
            if (head == null) head = node;
            else
            {
                node.next = head;
                head = node;
            }
        }
        public void Print()
        {
            Node node = head;
            for(int i = 0; i<length; i++)
            {
                Console.Out.Write(node.data + " ");
                node = node.next;
            }
            Console.Out.WriteLine();
        }
        public void AddTo(int ind, int data)
        {
            length++;
            Node node = head;
            if (ind == 0) AddToBegin(data);
            else
            {
                for (int i = 0; i < ind - 1; i++)
                {
                    node = node.next;
                }
                Node temp = node.next;
                node.next = new Node(data)
                {
                    next = temp
                };
            }
        }
        public void AddToEnd(int data)
        {
            AddTo(length, data);
        }
        public int Find(int key)
        {
            Node node = head;
            for (int i = 0; i < length; i++)
            {
                if (node.data == key) return i;
                node = node.next;
            }
            return -1;
        }
        public void Edit(int ind, int data)
        {
            Node node = head;
            for (int i = 0; i < ind; i++)
                node = node.next;
            node.data = data;
        }
        private int GetData(int ind)
        {
            Node node = head;
            for (int i = 0; i < ind; i++)
                node = node.next;
            return node.data;
        }
        private Node GetNode(int ind)
        {
            Node node = head;
            for (int i = 0; i < ind; i++)
                node = node.next;
            return node;
        }
        public void Delete(int ind)
        {
            Node node = head;
            length--;
            if (ind == 0) head = head.next;
            else
            {
                for (int i = 0; i < ind-1; i++)
                    node = node.next;
                node.next = node.next.next;
            }
        }
        private void SwapNodes(int ind1, int ind2)
        {
            Node temp;
            Node nextTemp;
            Node temp2;
            if (ind1 == 0)
            {
                temp = head;
                nextTemp = temp.next;
                head = GetNode(ind2);
                temp.next = head.next;
                head.next = nextTemp;
                GetNode(ind2 - 1).next = temp;
                return;
            }
            if (ind2 - ind1 == 1)
            {
                temp = GetNode(ind1);
                temp2 = GetNode(ind2);
                nextTemp = temp2.next;
                GetNode(ind1 - 1).next = temp2;
                temp2.next = temp;
                temp.next = nextTemp;
                return;
            }
            temp = GetNode(ind1);
            temp2 = GetNode(ind2);
            Node prev2 = GetNode(ind2 - 1);
            GetNode(ind1 - 1).next = temp2;
            nextTemp = temp2.next;
            temp2.next = temp.next;
            prev2.next = temp;
            temp.next = nextTemp;
        }
        public void Srt(int key)
        {
            for (int i = 0; i < length - 1; i++)
                for (int j = 0; j < length - i - 1; j++)
                {
                    if (key == 0)
                    {
                        if (GetData(j) > GetData(j + 1)) SwapNodes(j, j + 1);
                    }
                    else
                        if (GetData(j) < GetData(j + 1)) SwapNodes(j, j + 1);
                }
        }
        public void PrintInFile(string path)
        {
            Node node = head;
            for (int i = 0; i < length; i++)
            {
                File.AppendAllText(path, node.data + " ");
                node = node.next;
            }
        }
    }
   
    class Program
    {   
        static void Main(string[] args)
        {
            ListC l = new ListC();
            l.AddToBegin(1);
            l.AddToBegin(2);
            l.AddToBegin(0);
            l.AddTo(3, 3);
            l.AddTo(2, 5);
            l.AddToEnd(6);
            l.Print();
            l.Srt(-1);
            l.Print();
            l.PrintInFile("output.txt");
        }
    }
}
