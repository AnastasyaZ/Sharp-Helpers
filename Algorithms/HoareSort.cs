static int HoareSort(T[] arr, int start, int end)
{
	if(start==end) return;
	var pivot=arr[end];
	var storeIndex=start;
	for(var i=start; i<end; i++)
	{
		if(arr[i]<pivot)
		{
			Swap(arr, storeIndex, i);
			storeIndex++;
		}
	}
	Swap(arr, storeIndex, end);
	
	HoareSort(arr, start, storeIndex-1);
	HoareSort(arr, storeIndex+1, end);
}

void Swap(T[] arr, int first, int second)
{
	var tmp=arr[first];
	arr[first]=arr[second];
	arr[second=tmp];
}