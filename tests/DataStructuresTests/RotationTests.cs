namespace DataStructuresTests;

public class RotationTests
{
    [Fact]
    // Left Rotation
    //  N                  N
    //  |                  |
    //  1                  2
    //   \                / \
    //    2       -->    1   3
    //   / \            / \ / \
    //  N   3          N  N N  N
    //
    public void LeftRotation3Nodes()
    {
        // build tree manually
        AVLTreeNode<int> root = new()
        {
            Value = 1,
            Height = 2
        };

        AVLTreeNode<int> node2 = new()
        {
            Value = 2,
            Height = 1,
            Parent = root
        };
        root.Right = node2;

        AVLTreeNode<int> node3 = new()
        {
            Value = 3,
            Height = 0,
            Parent = node2
        };
        node2.Right = node3;

        IBinaryTreeNode<int>? rotlNode = BinaryTreeFunctions.RotateLeft<int>(root);
        Assert.NotNull(rotlNode);

        rotlNode.Parent = null;

        Assert.NotNull(rotlNode.Left);
        Assert.NotNull(rotlNode.Right);
        Assert.Equal(rotlNode.Left.Parent, rotlNode);
        Assert.Equal(rotlNode.Right.Parent, rotlNode);
        Assert.Equal(2, rotlNode.Value);
        Assert.Equal(1, rotlNode.Left.Value);
        Assert.Equal(3, rotlNode.Right.Value);

        Assert.Equal(1, rotlNode.Height);
        Assert.Equal(0, rotlNode.Left.Height);
        Assert.Equal(0, rotlNode.Right.Height);
    }

    [Fact]
    // Right Rotation
    //        N                       N
    //        |                       |
    //        3                       2
    //       / \                     / \
    //      2   N        -->        1   3
    //     / \                     / \ / \
    //    1   N                   N  N N  N
    //   / \
    //  N   N
    public void RightRotation3Nodes()
    {
        // build tree manually
        AVLTreeNode<int> root = new()
        {
            Value = 3,
            Height = 2
        };

        AVLTreeNode<int> node2 = new()
        {
            Value = 2,
            Height = 1,
            Parent = root
        };
        root.Left = node2;

        AVLTreeNode<int> node3 = new()
        {
            Value = 1,
            Height = 0,
            Parent = node2
        };
        node2.Left = node3;

        IBinaryTreeNode<int>? rotrNode = BinaryTreeFunctions.RotateRight<int>(root);
        Assert.NotNull(rotrNode);

        rotrNode.Parent = null;

        Assert.NotNull(rotrNode.Left);
        Assert.NotNull(rotrNode.Right);
        Assert.Equal(rotrNode.Left.Parent, rotrNode);
        Assert.Equal(rotrNode.Right.Parent, rotrNode);
        Assert.Equal(2, rotrNode.Value);
        Assert.Equal(1, rotrNode.Left.Value);
        Assert.Equal(3, rotrNode.Right.Value);

        Assert.Equal(1, rotrNode.Height);
        Assert.Equal(0, rotrNode.Left.Height);
        Assert.Equal(0, rotrNode.Right.Height);
    }

    [Fact]
    // Left Rotation
    //       N                            N
    //       |                            |
    //       2                            4
    //      / \          -->             / \
    //     1   4                        2   5
    //    /\  / \                      / \  /\
    //   N N 3   5                    1   3 N N
    //      /\  /\                   / \  /\
    //     N  NN  N                 N   NN  N
    public void LeftRotation5Node()
    {
        // build tree manually
        AVLTreeNode<int> root = new()
        {
            Value = 2,
            Height = 2
        };

        AVLTreeNode<int> node2 = new()
        {
            Value = 1,
            Height = 0,
            Parent = root
        };
        root.Left = node2;

        AVLTreeNode<int> node4 = new()
        {
            Value = 4,
            Height = 1,
            Parent = root
        };
        root.Right = node4;

        AVLTreeNode<int> node3 = new()
        {
            Value = 3,
            Height = 0,
            Parent = node4
        };
        node4.Left = node3;

        AVLTreeNode<int> node5 = new()
        {
            Value = 5,
            Height = 0,
            Parent = node4
        };
        node4.Right = node5;

        IBinaryTreeNode<int>? rotlNode = BinaryTreeFunctions.RotateLeft<int>(root);
        Assert.NotNull(rotlNode);

        rotlNode.Parent = null;

        Assert.NotNull(rotlNode.Left);
        Assert.NotNull(rotlNode.Right);
        Assert.NotNull(rotlNode.Left.Left);
        Assert.NotNull(rotlNode.Left.Right);
        Assert.Null(rotlNode.Left.Left.Left);
        Assert.Null(rotlNode.Left.Left.Right);
        Assert.Null(rotlNode.Left.Right.Left);
        Assert.Null(rotlNode.Left.Right.Right);
        Assert.Null(rotlNode.Right.Left);
        Assert.Null(rotlNode.Right.Right);

        Assert.Equal(rotlNode.Left.Parent, rotlNode);
        Assert.Equal(rotlNode.Right.Parent, rotlNode);
        Assert.Equal(rotlNode.Left.Left.Parent, rotlNode.Left);
        Assert.Equal(rotlNode.Left.Right.Parent, rotlNode.Left);

        Assert.Equal(4, rotlNode.Value);
        Assert.Equal(2, rotlNode.Left.Value);
        Assert.Equal(5, rotlNode.Right.Value);
        Assert.Equal(1, rotlNode.Left.Left.Value);
        Assert.Equal(3, rotlNode.Left.Right.Value);

        Assert.Equal(2, rotlNode.Height);
        Assert.Equal(1, rotlNode.Left.Height);
        Assert.Equal(0, rotlNode.Right.Height);
        Assert.Equal(0, rotlNode.Left.Left.Height);
        Assert.Equal(0, rotlNode.Left.Right.Height);
    }

    [Fact]
    // Right Rotation
    //          N                           N
    //          |                           |
    //          4          -->              2
    //         / \                         / \
    //        2   5                       1   4
    //       / \   /\                    /\  / \
    //      1   3 N  N                  N N 3   5
    //     / \  /\                         /\  / \    
    //    N   NN  N                       N  NN   N
    public void RightRotation5Node()
    {
        AVLTreeNode<int> root = new()
        { 
            Value = 4,
            Height = 2,
        };

        AVLTreeNode<int> node2 = new()
        {
            Value = 2,
            Height = 1,
            Parent = root,
        };
        root.Left = node2;

        AVLTreeNode<int> node5 = new()
        {
            Value = 5,
            Height = 0,
            Parent = root,
        };
        root.Right = node5;

        AVLTreeNode<int> node1 = new()
        {
            Value = 1,
            Height = 0,
            Parent = node2,
        };
        node2.Left = node1;

        AVLTreeNode<int> node3 = new()
        {
            Value = 3,
            Height = 0,
            Parent = node2,
        };
        node2.Right = node3;

        IBinaryTreeNode<int>? rotrNode = BinaryTreeFunctions.RotateRight<int>(root);
        Assert.NotNull(rotrNode);
        rotrNode.Parent = null;

        Assert.NotNull(rotrNode.Left);
        Assert.NotNull(rotrNode.Right);
        Assert.NotNull(rotrNode.Right.Left);
        Assert.NotNull(rotrNode.Right.Right);
        Assert.Null(rotrNode.Left.Left);
        Assert.Null(rotrNode.Left.Right);
        Assert.Null(rotrNode.Right.Left.Left);
        Assert.Null(rotrNode.Right.Left.Right);
        Assert.Null(rotrNode.Right.Right.Left);
        Assert.Null(rotrNode.Right.Right.Right);


        // assert parents
        Assert.Equal(rotrNode.Left.Parent, rotrNode);
        Assert.Equal(rotrNode.Right.Parent, rotrNode);
        Assert.Equal(rotrNode.Right.Left.Parent, rotrNode.Right);
        Assert.Equal(rotrNode.Right.Right.Parent, rotrNode.Right);


        Assert.Equal(2, rotrNode.Value);
        Assert.Equal(1, rotrNode.Left.Value);
        Assert.Equal(4, rotrNode.Right.Value);
        Assert.Equal(3, rotrNode.Right.Left.Value);
        Assert.Equal(5, rotrNode.Right.Right.Value);

        Assert.Equal(2, rotrNode.Height);
        Assert.Equal(0, rotrNode.Left.Height);
        Assert.Equal(1, rotrNode.Right.Height);
        Assert.Equal(0, rotrNode.Right.Left.Height);
        Assert.Equal(0, rotrNode.Right.Right.Height);
    }

    [Fact]
    // Left Rotation
    //       N                            N
    //       |                            |
    //       5                            9
    //      / \          -->             / \
    //     3   9                        5   11
    //    /\  / \                      / \ / \
    //   N N 7   11                   3  7 N  12
    //      /\   /\                  / \ /\   / \
    //     N N  N  12               N   N  N N   N
    //            / \
    //           N   N
    public void LeftRotation6Nodes()
    {
        AVLTreeNode<int> root = new()
        {
            Value = 5,
            Height = 3,
        };

        AVLTreeNode<int> node3 = new()
        {
            Value = 3,
            Height = 0,
            Parent = root,
        };
        root.Left = node3;

        AVLTreeNode<int> node9 = new()
        {
            Value = 9,
            Height = 2,
            Parent = root
        };
        root.Right = node9;

        AVLTreeNode<int> node7 = new()
        {
            Value = 7,
            Height = 0,
            Parent = node9
        };
        node9.Left = node7;

        AVLTreeNode<int> node11 = new()
        {
            Value = 11,
            Height = 1,
            Parent = node9
        };
        node9.Right = node11;

        AVLTreeNode<int> node12 = new()
        {
            Value = 12,
            Height = 0,
            Parent = node11
        };
        node11.Right = node12;

        IBinaryTreeNode<int>? rotlNode = BinaryTreeFunctions.RotateLeft<int>(root);
        Assert.NotNull(rotlNode);
        rotlNode.Parent = null;

        Assert.NotNull(rotlNode.Left);
        Assert.NotNull(rotlNode.Right);
        Assert.NotNull(rotlNode.Left.Left);
        Assert.NotNull(rotlNode.Left.Right);
        Assert.NotNull(rotlNode.Right.Right);
        Assert.Null(rotlNode.Left.Left.Left);
        Assert.Null(rotlNode.Left.Left.Right);
        Assert.Null(rotlNode.Left.Right.Left);
        Assert.Null(rotlNode.Left.Right.Right);
        Assert.Null(rotlNode.Right.Left);
        Assert.Null(rotlNode.Right.Right.Left);
        Assert.Null(rotlNode.Right.Right.Right);

        Assert.Equal(rotlNode.Left.Parent, rotlNode);
        Assert.Equal(rotlNode.Right.Parent, rotlNode);
        Assert.Equal(rotlNode.Left.Left.Parent, rotlNode.Left);
        Assert.Equal(rotlNode.Left.Right.Parent, rotlNode.Left);
        Assert.Equal(rotlNode.Right.Right.Parent, rotlNode.Right);

        Assert.Equal(9, rotlNode.Value);
        Assert.Equal(5, rotlNode.Left.Value);
        Assert.Equal(11, rotlNode.Right.Value);
        Assert.Equal(3, rotlNode.Left.Left.Value);
        Assert.Equal(7, rotlNode.Left.Right.Value);
        Assert.Equal(12, rotlNode.Right.Right.Value);

        Assert.Equal(2, rotlNode.Height);
        Assert.Equal(1, rotlNode.Left.Height);
        Assert.Equal(1, rotlNode.Right.Height);
        Assert.Equal(0, rotlNode.Left.Left.Height);
        Assert.Equal(0, rotlNode.Left.Right.Height);
        Assert.Equal(0, rotlNode.Right.Right.Height);

    }

    [Fact]
    // Right Rotation
    //          N                          N
    //          |                          |
    //          9          -->             4
    //         / \                        / \
    //        4   12                     2   9
    //       /\  / \                    / \  /\
    //      2  7N   N                  1   N7 12
    //     /\ /\                      / \   /\ /\
    //    1  N  N                    N   N N  N  N
    //   / \
    //  N   N
    public void RightRotation6Nodes()
    {
        AVLTreeNode<int> root = new()
        {
            Value = 9,
            Height = 3
        };

        AVLTreeNode<int> node4 = new()
        {
            Value = 4,
            Height = 2,
            Parent = root
        };
        root.Left = node4;

        AVLTreeNode<int> node12 = new()
        {
            Value = 12,
            Height = 0,
            Parent = root
        };
        root.Right = node12;

        AVLTreeNode<int> node2 = new()
        {
            Value = 2,
            Height = 1,
            Parent = node4
        };
        node4.Left = node2;

        AVLTreeNode<int> node7 = new()
        {
            Value = 7,
            Height = 0,
            Parent = node4
        };
        node4.Right = node7;

        AVLTreeNode<int> node1 = new()
        {
            Value = 1,
            Height = 0,
            Parent = node2
        };
        node2.Left = node1;

        IBinaryTreeNode<int>? rotrNode = BinaryTreeFunctions.RotateRight<int>(root);
        Assert.NotNull(rotrNode);
        rotrNode.Parent = null;

        Assert.NotNull(rotrNode.Left);
        Assert.NotNull(rotrNode.Right);
        Assert.NotNull(rotrNode.Left.Left);
        Assert.NotNull(rotrNode.Right.Left);
        Assert.NotNull(rotrNode.Right.Right);
        Assert.Null(rotrNode.Left.Left.Left);
        Assert.Null(rotrNode.Left.Left.Right);
        Assert.Null(rotrNode.Left.Right);
        Assert.Null(rotrNode.Right.Left.Left);
        Assert.Null(rotrNode.Right.Left.Right);
        Assert.Null(rotrNode.Right.Right.Left);
        Assert.Null(rotrNode.Right.Right.Right);

        Assert.Equal(rotrNode.Left.Parent, rotrNode);
        Assert.Equal(rotrNode.Right.Parent, rotrNode);
        Assert.Equal(rotrNode.Left.Left.Parent, rotrNode.Left);
        Assert.Equal(rotrNode.Right.Left.Parent, rotrNode.Right);
        Assert.Equal(rotrNode.Right.Right.Parent, rotrNode.Right);

        Assert.Equal(4, rotrNode.Value);
        Assert.Equal(2, rotrNode.Left.Value);
        Assert.Equal(9, rotrNode.Right.Value);
        Assert.Equal(1, rotrNode.Left.Left.Value);
        Assert.Equal(7, rotrNode.Right.Left.Value);
        Assert.Equal(12, rotrNode.Right.Right.Value);

        Assert.Equal(2, rotrNode.Height);
        Assert.Equal(1, rotrNode.Left.Height);
        Assert.Equal(1, rotrNode.Right.Height);
        Assert.Equal(0, rotrNode.Left.Left.Height);
        Assert.Equal(0, rotrNode.Right.Left.Height);
        Assert.Equal(0, rotrNode.Right.Right.Height);
    }

}
