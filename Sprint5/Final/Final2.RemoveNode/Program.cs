/*
https://contest.yandex.ru/contest/24810/run-report/114654282/
 */
/*
 -- ПРИНЦИП РАБОТЫ --
    

   -- ДОКАЗАТЕЛЬСТВО КОРРЕКТНОСТИ --
    
   -- ВРЕМЕННАЯ СЛОЖНОСТЬ --

   -- ПРОСТРАНСТВЕННАЯ СЛОЖНОСТЬ --



 */

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
    public static Node Remove(Node root, int key)
    {
        if(root == null)
            return root;

        if (root.Value == key)
        {
            //есть 2 дочерних элемента
            if (root.Left != null &&
                root.Right != null)
            {

                //будем брать самую правую вершину в левом поддереве
                (Node parentNode, Node minNode) = FindMin(root.Left, root);

                //меняем связи узлов в дереве
                
                //замена на месте переносимого элемента
                if(parentNode.Left == minNode)
                    parentNode.Left = minNode.Right;
                else
                {
                    parentNode.Right = minNode.Right;
                }

                //замена на месте удаляемого
                minNode.Left = root.Left;
                minNode.Right = root.Right;

                return minNode;
            }
            
            //есть только левый
            if (root.Left != null)
                return root.Left;
                
            //только правый
            return root.Right;
        }
        
        //иначе...

        if (root.Value > key)
        {
            if(root.Left != null)
                root.Left = Remove(root.Left, key);
        }
        else
        {
            if(root.Right != null)
                root.Right = Remove(root.Right, key);
        }

        return root;
    }

    //на входе две ноды - сама нода, и родительская к ней
    // на выходе - родительская нода, и искомая минимальная нода (самая правая)
    private static (Node, Node) FindMin(Node node, Node parent)
    {
        if (node.Left != null)
        {
            return FindMin(node.Right, node);
        }

        return (parent, node);
    }

#if !REMOTE_JUDGE
    public static void Main()
    {
        var node1 = new Node(2);
        var node2 = new Node(3)
        {
            Left = node1
        };

        var node3 = new Node(1)
        {
            Right = node2
        };

        var node4 = new Node(6);
        var node5 = new Node(8)
        {
            Left = node4
        };

        var node6 = new Node(10)
        {
            Left = node5
        };

        var node7 = new Node(5)
        {
            Left = node3,
            Right = node6
        };

        var newHead = Remove(node7, 10);

        Console.WriteLine(newHead.Value == 5); //true
        Console.WriteLine(newHead.Right == node5); //true
        Console.WriteLine(newHead.Right.Value == 8); // true
    }
#endif
}