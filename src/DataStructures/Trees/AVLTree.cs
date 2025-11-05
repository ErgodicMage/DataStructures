namespace ErgodicMage.DataStructures.Trees;

public class AVLTree<T> : BinaryTree<T> where T : IComparable<T>
{
    #region IBinaryTree Implementation

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public bool Remove(T item)
    {
        throw new NotImplementedException();
    }
    #endregion

    internal override IBinaryTreeNode<T> CreateNode(IBinaryTreeNode<T>? parent, T item)
    {
        return new AVLTreeNode<T>
        {
            Parent = parent,
            Left = parent?.Left,
            Right = parent?.Right,
            Value = item
        };
    }

    internal override void InsertBalance(IBinaryTreeNode<T>? node, int balance)
    {
    }
}
