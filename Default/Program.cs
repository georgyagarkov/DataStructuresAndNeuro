using System;
using System.Collections.Generic;
using System.Linq;
using LinkedList;
namespace MainFile;

sealed class MainFile
{
    static void Main()
    {
        var l=new LinkedListG<int>();
        l.AppendTail(1);
        l.AppendTail(2);
        l.AppendTail(3);
        l.AppendTail(4);
        l.AppendTail(5);
        l.AppendTail(6);
        l.AppendTail(7);
        l.AppendTail(8);
        l.AppendTail(9);
        l.AppendTail(10);
        l.Printlist();

        Console.WriteLine(l.Count);

        l.Delete(4);

        l.Printlist();

        l.Clear();

        l.Printlist();
    
    }
}