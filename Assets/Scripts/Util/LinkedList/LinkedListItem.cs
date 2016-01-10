public class LinkedListItem<T>
{
	private T item;

	public LinkedListItem<T> Next { get; set; }
	public T Item {
		get {
			return item;
		}
	}

	public LinkedListItem(T item)
	{
		this.item = item;
	}
}
