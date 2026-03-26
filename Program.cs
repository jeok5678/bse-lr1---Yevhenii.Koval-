using System;
using System.Collections.Generic;
//
public class Node<T>
{
    public T Data { get; set; }
    public Node<T> Next { get; set; }

    public Node(T data)
    {
        Data = data;
        Next = null;
    }
}

public class LinkedList<T>
{
    private Node<T> head;

    public LinkedList()
    {
        head = null;
    }

    public void Add(T data)
    {
        Node<T> newNode = new Node<T>(data);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node<T> current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
    }

    public void Remove(T data)
    {
        if (head == null) return;

        if (head.Data.Equals(data))
        {
            head = head.Next;
            return;
        }

        Node<T> current = head;
        while (current.Next != null)
        {
            if (current.Next.Data.Equals(data))
            {
                current.Next = current.Next.Next;
                return;
            }
            current = current.Next;
        }
    }

    public void Display()
    {
        Node<T> current = head;
        while (current != null)
        {
            Console.Write(current.Data + " -> ");
            current = current.Next;
        }
        Console.WriteLine("null");
    }

    public bool Contains(T data)
    {
        Node<T> current = head;
        while (current != null)
        {
            if (current.Data.Equals(data))
                return true;
            current = current.Next;
        }
        return false;
    }
}

public class LinkedListExtensions<T>
{
    public int Count(LinkedList<T> list)
    {
        int count = 0;
        Node<T> current = list.head;
        while (current != null)
        {
            count++;
            current = current.Next;
        }
        return count;
    }

    public T GetAt(LinkedList<T> list, int index)
    {
        Node<T> current = list.head;
        int i = 0;
        while (current != null && i < index)
        {
            current = current.Next;
            i++;
        }
        return current != null ? current.Data : default(T);
    }

    public void InsertAt(LinkedList<T> list, T data, int index)
    {
        Node<T> newNode = new Node<T>(data);
        if (index == 0)
        {
            newNode.Next = list.head;
            list.head = newNode;
            return;
        }
        Node<T> current = list.head;
        for (int i = 0; i < index - 1 && current != null; i++)
            current = current.Next;
        if (current != null)
        {
            newNode.Next = current.Next;
            current.Next = newNode;
        }
    }

    public void Reverse(LinkedList<T> list)
    {
        Node<T> prev = null, current = list.head;
        while (current != null)
        {
            Node<T> next = current.Next;
            current.Next = prev;
            prev = current;
            current = next;
        }
        list.head = prev;
    }

    public void Clear(LinkedList<T> list)
    {
        list.head = null;
    }
}

class Program
{
    static void Main()
    {
        LinkedList<int> list = new LinkedList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Display();
    }
}
