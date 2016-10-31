static int FyndIndexByBinarySearch(T[] array, T element)
{
	var left=0;
	var right=array.Length-1;
	while(left<right)
	{
		var middle=(left+right)/2;
		if(array[middle]>=element)
			right=middle;
		else
			left=middle+1;
		if(array[right]==element) return right;
		else return -1;
	}
}