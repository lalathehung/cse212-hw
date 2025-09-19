public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Step 1: Create a new array of double numbers with the given length. This array will store the multiples.
        // Step 2: Use a for loop to go from 0 to length minus 1. For each spot i, figure out the multiple by multiplying number by (i plus 1) and put it in the array at spot i.
        // Step 3: After the loop, return the completed array.

        double[] result = new double[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        // Step 1: Calculate the split point: the index where the rotation starts, which is data.Count - amount.
        // Step 2: Extract the last 'amount' elements into a new list using GetRange(data.Count - amount, amount). This will be the new front part.
        // Step 3: Extract the first (data.Count - amount) elements into another new list using GetRange(0, data.Count - amount). This will be the new back part.
        // Step 4: Clear the original data list to remove all elements.
        // Step 5: Add the front part (lastPart) to the data list using AddRange.
        // Step 6: Add the back part (firstPart) to the data list using AddRange. The list is now rotated in place.

        int n = data.Count;
        List<int> lastPart = data.GetRange(n - amount, amount);
        List<int> firstPart = data.GetRange(0, n - amount);
        data.Clear();
        data.AddRange(lastPart);
        data.AddRange(firstPart);
    }
}
