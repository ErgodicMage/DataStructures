using System.Xml;

namespace ErgodicMage.DataStructures.Trees;

internal static class BinaryTreeFunctions
{
    internal static IBinaryTreeNode<T>? MinNode<T>(IBinaryTreeNode<T>? node) where T : IComparable<T>
        => LeftmostNode(node);

    internal static IBinaryTreeNode<T>? LeftmostNode<T>(IBinaryTreeNode<T>? node) where T : IComparable<T>
    {
        if (node is null) return default;
        while (node is not null)
        {
            if (node.Left is null) return node;
            node = node.Left;
        }
        return default;
    }

    internal static IBinaryTreeNode<T>? MaxNode<T>(IBinaryTreeNode<T>? node) where T : IComparable<T>
        => RightmostNode(node);

    internal static IBinaryTreeNode<T>? RightmostNode<T>(IBinaryTreeNode<T>? node) where T : IComparable<T>
    {
        if (node is null) return default;
        while (node is not null)
        {
            if (node.Right is null) return node;
            node = node.Right;
        }
        return default;
    }

    internal static bool Find<T>(IBinaryTreeNode<T>? node, T value) where T : IComparable<T>
    {
        if (node is null) return false;

        if (value.CompareTo(node.Value) == 0) return true;

        //return Find(node.Left, value) && Find(node.Right, value);

        IBinaryTreeNode<T>? current = node;

        while (current is not null)
        {
            if (current.Value.CompareTo(value) < 0)
                current = current.Left;
            else if (current.Value.CompareTo(value) > 0)
                current = current.Right;
            else return true;
        }

        return false;
    }

    internal static int GetHeight<T>(IBinaryTreeNode<T>? node) where T : IComparable<T> => node is null ? -1 : node.Height;

    internal static IBinaryTreeNode<T>? RotateLeft<T>(IBinaryTreeNode<T>? node) where T : IComparable<T>
    {
        if (node is null) return null;
        if (node.Right is null) return null;

        IBinaryTreeNode<T> right = node.Right;
        node.Right = right.Left;
        right.Left = node;

        right.Parent = node.Parent;
        if (node.Right is not null) node.Right.Parent = node;
        node.Parent = right;

        node.Height = Math.Max(GetHeight(node.Left), GetHeight(node.Right)) + 1;
        if (right is not null)
            right.Height = Math.Max(GetHeight(right.Left), GetHeight(right.Right)) + 1;

        return right;
    }

    internal static IBinaryTreeNode<T>? RotateRight<T>(IBinaryTreeNode<T>? node) where T : IComparable<T>
    {
        if (node is null) return null;
        if (node.Left is null) return null;

        IBinaryTreeNode<T>? left = node.Left;
        node.Left = left.Right;
        left.Right = node;

        left.Parent = node.Parent;
        if (node.Left is not null) node.Left.Parent = node;
        node.Parent = left;

        node.Height = Math.Max(GetHeight(node.Left), GetHeight(node.Right)) + 1;
        if (left is not null)
            left.Height = Math.Max(GetHeight(left.Left), GetHeight(left.Right)) + 1;
        
        return left;
    }

}
