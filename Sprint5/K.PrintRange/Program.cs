using System.IO;

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
    public static void PrintRange(Node root, int left, int right, StreamWriter writer)
    {
        if(root == null) 
            return;

        if (root.Value >= left)
        {
            PrintRange(root.Left, left, right, writer);
        }

        if (left <= root.Value && root.Value <= right)
        {
            writer.WriteLine(root.Value);
        }

        if (root.Value <= right)
        {
            PrintRange(root.Right, left, right, writer);
        }

    }
}