using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace Dequeue
{
	class DequeueProgram
	{
		static void Main(string[] args)
		{
			Msmq<Student> queue = new Msmq<Student>(AppConst.QueuePath);

			//queue.Enqueue(new Student { Name = "Tom", Age = 18 });

			var student = queue.Dequeue();

			if (student != null)
			{
				Console.WriteLine(student.Name);
				Console.WriteLine(student.Age);
			}
			else
			{
				Console.WriteLine("student is null.");
			}

			Console.WriteLine("Press any key to continue.");
			Console.Read();
		}
	}
}
