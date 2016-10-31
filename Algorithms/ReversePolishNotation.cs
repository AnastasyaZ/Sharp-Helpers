static int Compute(string str)
{
	var operations=new Dictionary<char, Func<int,int,int>>();
	operations.Add('+', (y,x)=> x+y);
	operations.Add('-', (y,x)=> x-y);
	operations.Add('*', (y,x)=> x*y);
	operations.Add('/', (y,x)=> x/y);
	
	var stack=new Stack<int>();
	foreach(var c in str)
	{
		if(c >= '0' && c<= '9' )
			stack.Push((int)Char.GetNumericValue(c);
		else if(operations.ContainsKey(c))
			stack.Push(operations[c](stack.Pop(), stack.Pop()));
		else throw new ArgumentException();		
	}
	return stack.Pop();
}