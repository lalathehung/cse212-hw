using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities and dequeue them.
    // Expected Result: Items are dequeued in order of highest priority: High (3), Medium (2), Low (1).
    // Defect(s) Found: 
    // 1. Dequeue loop only iterates to _queue.Count - 2, missing the last item.
    // 2. Condition uses >=, selecting the last item for equal priorities instead of the first (violates FIFO).
    // 3. Dequeue does not remove the item (_queue.RemoveAt missing), causing incorrect subsequent dequeues.
    public void TestPriorityQueue_DifferentPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 3);
        priorityQueue.Enqueue("Medium", 2);
        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same priority and dequeue.
    // Expected Result: Items with the same priority are dequeued in FIFO order: First, Second, Third.
    // Defect(s) Found: 
    // 1. Same as above: loop misses last item, >= violates FIFO, no removal.
    // 2. Equal priorities result in the last item being dequeued instead of the first.
    public void TestPriorityQueue_SamePriorityFIFO()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 5);
        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue.
    // Expected Result: Throws InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: 
    // None; test passes as Dequeue correctly throws the required exception.
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (Exception e)
        {
            Assert.Fail($"Unexpected exception of type {e.GetType()}: {e.Message}");
        }
    }

    [TestMethod]
    // Scenario: Enqueue items with mixed priorities, including duplicates, and dequeue all.
    // Expected Result: Items dequeued by highest priority, FIFO for equal priorities: B (3), D (3), A (2), C (2).
    // Defect(s) Found: 
    // 1. Same as above: loop misses last item, >= violates FIFO, no removal.
    // 2. Equal priorities (e.g., 3 or 2) dequeued in wrong order, and queue not properly emptied.
    public void TestPriorityQueue_MixedPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 2);
        priorityQueue.Enqueue("D", 3);
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("D", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
    }
}