namespace ErgodicMage.DataStructures.Trees;

public class BinaryTreeIterator<T> where T : IComparable<T>
{
    private readonly IBinaryTreeNode<T>? _root;
    private IBinaryTreeNode<T>? _current;

    private BinaryTreeIterator() { }

    internal BinaryTreeIterator(IBinaryTreeNode<T>? root, bool startMinNode = true)
    {
        _root = root;
        _current = startMinNode ? BinaryTreeFunctions.MinNode(_root) : BinaryTreeFunctions.MaxNode(_root);
    }

    public BinaryTreeIterator(BinaryTree<T> tree, bool startMinNode = true)
    {
        _root = tree?.Root;
        _current = startMinNode ? BinaryTreeFunctions.MinNode(_root) : BinaryTreeFunctions.MaxNode(_root);
    }

    public static BinaryTreeIterator<T> CreateForwardIterator(BinaryTree<T> tree)
        => new(tree, true);

    public static BinaryTreeIterator<T> CreateReverseIterator(BinaryTree<T> tree)
        => new(tree, false);

    public T? Current => _current is null ? default : _current.Value;

    public bool Next()
    {
        if (_current is null) return false;
        if (_current.IsLeaf)
        {
            _current = _current.Parent;
            return _current is not null;
        }

        // Go down Left to find min if no min go down Right to find min
        _current = BinaryTreeFunctions.MinNode(_current.Left) ?? BinaryTreeFunctions.MinNode(_current.Right);

        return _current is not null;
    }

    public bool Previous()
    {
        if (_current is null) return false;
        if (_current.IsLeaf)
        {
            _current = _current.Parent;
            return _current is not null;
        }

        // Go down Right to find max if no max go down Left to find max
        _current = BinaryTreeFunctions.MaxNode(_current.Right) ?? BinaryTreeFunctions.MaxNode(_current.Left);

        return _current is not null;
    }

    public static BinaryTreeIterator<T> operator ++(BinaryTreeIterator<T> tree)
    {
        tree.Next();
        return tree;
    }

    public static BinaryTreeIterator<T> operator --(BinaryTreeIterator<T> tree)
    {
        tree.Previous();
        return tree;
    }
}
