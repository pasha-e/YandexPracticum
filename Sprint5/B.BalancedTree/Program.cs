﻿using System;

#if !REMOTE_JUDGE
public class Node
{
    public int Value { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }

    public Node(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}
#endif

public class Solution
{
    public static bool Solve(Node root)
    {
        if(root == null)
            return true;

        var leftHeight = GetHeight(root.Left);
        var rightHeight = GetHeight(root.Right);

        if(Math.Abs(leftHeight - rightHeight) <= 1 &&
            Solve(root.Left)  &&
            Solve(root.Right)  )
            return true;

        return false;
    }

    private static int GetHeight(Node root)
    {
        if(root == null) 
            return 0;

        var leftHeight = GetHeight(root.Left);
        var rightHeight = GetHeight(root.Right);

        return Math.Max(leftHeight, rightHeight) + 1 ;
    }

#if !REMOTE_JUDGE
    private static void Main()
    {
        var node1 = new Node(1);
        var node2 = new Node(-5);
        var node3 = new Node(3)
        {
            Left = node1,
            Right = node2
        };
        var node4 = new Node(10);
        var node5 = new Node(2)
        {
            Left = node3,
            Right = node4
        };
        Console.WriteLine(Solve(node5));
    }
#endif
}