using System;
using System.Collections;
using System.Collections.Generic;


public class ListPart<T>
{
    public T val;
    public ListPart<T> next;

    public ListPart(T i)
    {
        val = i;
        next = null;
    }
}

class LinkedList<T> : IEnumerable
{
    private ListPart<T> head;

    public LinkedList()
    {
        head = null;
    }

    private IEnumerable<ListPart<T>> ListParts
    {
        get
        {
            ListPart<T> ListPart = head;
            while (ListPart != null)
            {
                yield return ListPart;
                ListPart = ListPart.next;
            }
        }
    }

    public void GnomeSort(LinkedList<int> input) // gnome sorting algorithm
    {
        int n = input.Count(), index = 0;

        while (index < n)
        {
            if (index == 0)
                index++;
            if (input.ElementAt(index).val >= input.ElementAt(index - 1).val)
                index++;
            else
            {
                int temp = 0;
                temp = input.ElementAt(index).val;
                input.ElementAt(index).val = input.ElementAt(index - 1).val;
                input.ElementAt(index - 1).val = temp;
                index--;
            }

        }
    }

    public void RecInsertionSort(LinkedList<int> input, int n)
    {
        if (n <= 1) 
            return;

        RecInsertionSort(input, n - 1);
        int last = input.ElementAt(n - 1).val;

        int m = n - 2; 
      
        while (m >= 0 && input.ElementAt(m).val > last) 
        {
            input.ElementAt(m + 1).val = input.ElementAt(m).val;
            m--; 
        }
        input.ElementAt(m + 1).val = last; 
    }

    public void ReverseList()
    {
        ListPart<T> prev, cur, next;
        prev = null;
        cur = head;
        while (cur != null)
        {
            next = cur.next;
            cur.next = prev;
            prev = cur;
            cur = next;
        }
        head = prev;
    }

    public ListPart<T> ElementAt(int index)
    {
        int counter = 0;
        foreach (ListPart<T> item in ListParts)
        {
            if (counter == index)
            {
                return item;
            }
            counter++;
        }
        return null;
    }

    public void Remove(T value)
    {
        if (head == null) return;

        if (head.val.Equals(value))
        {
            head = head.next;
            return;
        }

        ListPart<T> n = head;
        while (n.val != null)
        {
            if (n.next.val.Equals(value))
            {
                n.next = n.next.next;
                return;
            }

            n = n.next;
        }
    }

    public void IndexOf(T x)
    {
        int pos = 0;
        ListPart<T> p = head;
        while (p != null)
        {
            if (p.val.Equals(x))
                break;
            pos++;
            p = p.next;
        }
        switch (p)
        {
            case null:
                Console.WriteLine("null");
                break;
            default:
                Console.WriteLine(pos);
                break;
        }
    }

    public bool Contains(T x)
    {
        int count = 0;
        ListPart<T> p = head;

        while(p != null)
        {
            
            if (p.val.Equals(x))
            {
                count++;
                break;
            }
                
            p = p.next;
        }
        switch(count)
        {
            case 0:
                Console.WriteLine("False");
                return false;
            default:
                Console.WriteLine("True");
                return true;
        }
    }

    public void Print()
    {
        ListPart<T> p;
        if (head == null)
        {
            Console.WriteLine("NULL");
            return;
        }
        p = head;
        while (p != null)
        {
            Console.Write(p.val + " ");
            p = p.next;
        }
    }

    public int Count()
    {
        int n = 0;
        ListPart<T> p = head;
        while (p != null)
        {
            n++;
            p = p.next;
        }
        return n;
    }

    public void AddFirst(T x)
    {
        ListPart<T> placeholder = new ListPart<T>(x);
        placeholder.next = head;
        head = placeholder;
    }

    public void AddLast(T x)
    {
        ListPart<T> it;
        ListPart<T> temp = new ListPart<T>(x);

        if (head == null)
        {
            head = temp;
            return;
        }

        it = head;
        while (it.next != null)
            it = it.next;

        it.next = temp;
    }

    public IEnumerator GetEnumerator()
    {
        foreach (ListPart<T> item in ListParts)
        {
            yield return item.val;
        }
    }
}