static int BubbleSort(T[] array)
{
	for(var i=array.Length-1; i>0; i--)
		for(var j=0; j<i; j++)
			if(array[j]>array[j+1])
			{
				var tmp=array[j+1];
				array[j+1]=array[j];
				array[j]=tmp;
			}
}

static int BubbleSortRange(T[] array, int left, int right)
{
	for(var i=right; i>left; i--)
		for(var j=left; j<i; j++)
			if(array[j]>array[j+1])
			{
				var tmp=array[j+1];
				array[j+1]=array[j];
				array[j]=tmp;
			}
}