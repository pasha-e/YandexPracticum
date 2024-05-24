/*
 https://www.geeksforgeeks.org/a-program-to-check-if-a-binary-tree-is-bst-or-not/ 
*/

#if !REMOTE_JUDGE
public class Node
{
    public int Value;
    public Node Left;
    public Node Right;

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
        return IsBinarySearchTree(root, Int32.MinValue, Int32.MaxValue);        
    }

    private static bool IsBinarySearchTree(Node root, int minValue, int maxValue)
    {
        if (root == null)
            return true;

        if(root.Value <= minValue ||
            root.Value >= maxValue) 
            return false;

        var isLeftBST = IsBinarySearchTree(root.Left, minValue, root.Value );

        var isRightBST = IsBinarySearchTree(root.Right, root.Value ,  maxValue);

        return isLeftBST && isRightBST;
    }


#if !REMOTE_JUDGE
    private static void Main()
    {
        var node1 = new Node(1);
        var node2 = new Node(4);
        var node3 = new Node(3)
        {
            Left = node1,
            Right = node2
        };
        var node4 = new Node(8);
        var node5 = new Node(5)
        {
            Left = node3,
            Right = node4
        };
        Console.WriteLine(Solve(node5)); // true
        node2.Value = 5;
        Console.WriteLine(Solve(node5)); // false
    }
#endif
}