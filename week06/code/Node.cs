public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        if (value == Data) return; // Check for duplicate values ​​and skip them

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        if (value == Data) return true; // Find value
        if (value < Data)
        {
            return Left?.Contains(value) ?? false; // Left
        }
        else
        {
            return Right?.Contains(value) ?? false; // Right
        }
    }

    public int GetHeight()
    {
        if (Left is null && Right is null) return 1; // Root only
        int leftHeight = Left?.GetHeight() ?? 0; // Height of left tree
        int rightHeight = Right?.GetHeight() ?? 0; // Height of right tree
        return 1 + Math.Max(leftHeight, rightHeight); // 1 + height of the highest tree
    }
}