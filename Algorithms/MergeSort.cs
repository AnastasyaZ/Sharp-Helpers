
var tmpArr=new T[bigEnoughNumber];

static int MergeSort(T[] arr, int left, int right)
{
	if(start==end) return;
	var middle=(left+right)/2;
	MergeSort(arr, left, middle);
	MergeSort(middle+1, right);
	Merge(arr, left, middle, right);
}

static int Merge(T[] arr, int start, int middle, int end)
{
	var leftPtr=start;
	var rightPtr=middle+1;
	var length=end-start+1;
	
	for(var i=0; i<length; i++)
	{
		if( rightPtr>end||(leftPtr<=middle&&arr[leftPtr]<arr[rightPtr]))
		{
			tmpArr[i]=arr[leftPtr];
			leftPtr++;
		}
		else
		{
			tmpArr[i]=arr[rightPtr];
			rightPtr++;
		}
	}
	for(var i=0; i<length; i++)
		arr[start+i]=tmpArr[i];
}