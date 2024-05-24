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
    public static Node Insert(Node root, int key)
    {
        if (root == null)
        {
            return new Node(key);
        }

        if (key < root.Value)
        {
            root.Left = Insert(root.Left, key);
        }
        else if (key >= root.Value)
        {
            root.Right = Insert(root.Right, key);
        }

        return root;
    }

#if !REMOTE_JUDGE
    private static void Main()
    {
        var node1 = new Node(7);
        var node2 = new Node(8)
        {
            Left = node1
        };

        var node3 = new Node(7)
        {
            Right = node2
        };
        var newHead = Insert(node3, 6);
        Console.WriteLine(newHead == node3);
        Console.WriteLine(newHead.Left.Value == 6);
    }
#endif
}