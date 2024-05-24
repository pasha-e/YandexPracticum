using System;

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
    public static int Solve(Node root)
    {
        int max = root.Value;

        if (root.Left != null)
        {
            var maxLeft = Solve(root.Left);

            if(maxLeft > max) 
                max = maxLeft;
        }

        if (root.Right != null)
        {
            var maxRight = Solve(root.Right);

            if(maxRight >max)
                max = maxRight;
        }

        return max;

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
        var node4 = new Node(2)
        {
            Left = node3
        };
        Console.WriteLine(Solve(node4)); // ==3
    }
#endif
}