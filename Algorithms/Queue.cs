class QueueItem<T>
{
	public T Value {get; set;}
	public QueueItem Next {get; set;}
}

class Queue<T>
{
	QueueItem<T> head=null;
	QueueItem<T> tail=null;
	
	public void Enqueue(T value)
	{
		var item=new QueueItem{Value=value, Next=null};
		if(head==null)
			head=tail=item;
		else
		{
			tail.Next=item;
			tail=item;
		}
	}
	
	public T Dequeue()
	{
		if(head==null) throw new InvalidOperationException();
		
		var item=head.Value;
		head=head.Next;
		if(head==null) tail=null;
		
		return item;
	}
}