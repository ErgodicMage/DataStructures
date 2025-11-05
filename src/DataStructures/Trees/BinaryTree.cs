namespace ErgodicMage.DataStructures.Trees;

public abstract class BinaryTree<T> where T : IComparable<T>
{
    internal IBinaryTreeNode<T>? Root { get; set; }
   
    public int Count { get; set; }

    public bool IsReadOnly { get; set; } = false;

    public bool Contains(T item) => BinaryTreeFunctions.Find(Root, item);

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    internal virtual void Add(T item)
    {
        ArgumentNullException.ThrowIfNull(item, nameof(item));

        if (Root is null)
        {
            Root = CreateNode(null, item); ;
            Count++;
            return;
        }

        IBinaryTreeNode<T> node = Root;

        while (node is not null)
        {
            int compare = node.Value.CompareTo(item);

            if (compare < 0)
            {
                if (node.Left is null)
                {
                    node.Left = CreateNode(node, item);
                    InsertBalance(node, 1);
                    Count++;
                    return;
                }
                node = node.Left;
            }
            else if (compare > 0)
            {
                if (node.Right is null)
                {
                    node.Right = CreateNode(node, item);
                    InsertBalance(node, -1);
                    Count++;
                    return;
                }
                node = node.Right;
            }
        }
    }

    internal abstract IBinaryTreeNode<T> CreateNode(IBinaryTreeNode<T>? parent, T item);

    internal virtual void InsertBalance(IBinaryTreeNode<T>? node, int balance) { }

    public void Clear()
    {
        BinaryTreeTraversal.PostOrder(Root, (node) =>
            {
                if (node is null) return;
                node.Parent = null;
                node.Left = null;
                node.Right = null;
                node.Value = default!;
            });
        Root = null;
        Count = 0;
    }
}

