namespace ErgodicMage.DataStructures.Trees;
internal class AVLTreeNode<T> : IBinaryTreeNode<T> where T : IComparable<T>
{
    public IBinaryTreeNode<T>? Parent { get; set; }
    public IBinaryTreeNode<T>? Left { get; set; }
    public IBinaryTreeNode<T>? Right { get; set; }
    public required T Value { get; set; }

    public int Height { get; set; }
}
