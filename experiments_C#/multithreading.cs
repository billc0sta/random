using System; 

namespace Multithreading; 
internal static class Program 
{

	static void Writer() 
	{
		int i = 0;
		while(i++ < 100) 
		{
			Console.WriteLine("{0}, {1}", i, (i % 10 == 0) ? "\n" : "");
		} 
	}
	static void Main() 
	{
		WriterExample();
	}

	static void WriterExample() 
	{
		Console.WriteLine("[1] or [2] threads of execution?");
		string threadCount = Console.ReadLine();
		Thread primaryThread = Thread.CurrentThread;
		primaryThread.Name = "Primary";

		switch(threadCount) 
		{
			case "2":
			Thread backgroundThread = new Thread
			(new ThreadStart(Writer));
			backgroundThread.Name = "Secondary";
			backgroundThread.Start();
			break;
			case "1":
			Writer();

		}
	}

	static void ParameterizedExample() 
	{
		List<int> ints = new List<int>();
		Thread backgroundThread = new Thread(new ParameterizedThreadStart(AddMultiples))
		backgroundThread.Start(ints);
		Thread.Sleep(5);
		Console.ReadLine();
	}

	static void AddMultiples(in object data) 
	{
		if (data is List<int> list) 
		{
			foreach(var ss in list) 
			{
				Console.WriteLine(ss);
			}
		}
	}

	static void locker() 
	{
		lock(lockerToken) 
		{
			++changeable;
		}
	}

	static int changeable = 0;
	static int lockerToken = 1;
}