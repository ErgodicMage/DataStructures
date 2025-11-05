namespace ErgodicMage.DataStructures.Trees;

internal static class BinaryTreeTraversal
{
    internal static void InOrder<T>(IBinaryTreeNode<T>? node, Action<IBinaryTreeNode<T>?> action) where T : IComparable<T>
    {
        if (node is null) return;
        InOrder(node.Left, action);
        action(node);
        InOrder(node.Right, action);
    }

    internal static void PreOrder<T>(IBinaryTreeNode<T>? node, Action<IBinaryTreeNode<T>?> action) where T : IComparable<T>
    {
        if (node is null) return;
        action(node);
        PreOrder(node.Left, action);
        PreOrder(node.Right, action);
    }

    internal static void PostOrder<T>(IBinaryTreeNode<T>? node, Action<IBinaryTreeNode<T>?> action) where T : IComparable<T>
    {
        if (node is null) return;
        PostOrder(node.Left, action);
        PostOrder(node.Right, action);
        action(node);
    }
}
