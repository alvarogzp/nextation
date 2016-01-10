public class LinkedList<T>
{
	private LinkedListItem<T> first;
	private LinkedListItem<T> last;
	private int length = 0;

	public T First {
		get {
			return first.Item;
		}
	}
	public T Last {
		get {
			return last.Item;
		}
	}
	public int Length {
		get {
			return length;
		}
	}

	public void Add(T item)
	{
		LinkedListItem<T> linkedListItem = new LinkedListItem<T>(item);
		if (first == null) {
			first = linkedListItem;
		} else {
			last.Next = linkedListItem;
		}
		last = linkedListItem;
		length++;
	}

	public void RemoveFirst()
	{
		first = first.Next;
		length--;
	}
}
