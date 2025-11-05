namespace ErgodicMage.DataStructures.Trees;

internal interface IBinaryTreeNode<T> where T : IComparable<T>
{
    IBinaryTreeNode<T>? Parent { get; set; }
    IBinaryTreeNode<T>? Left { get; set; }
    IBinaryTreeNode<T>? Right { get; set; }

    T Value { get; set; }

    int Height { get; set; }

    internal bool IsLeaf => Left is null && Right is null;
    internal bool IsLeftChild => Parent is not null && Parent.Left == this;
    internal bool IsRightChild => Parent is not null && Parent.Right == this;
}
