using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Messaging;

namespace Common
{
	public class Msmq<T> where T : class,new()
	{
		public Msmq(string path)
		{
			try
			{
				if (MessageQueue.Exists(path))
				{
					this.queue = new MessageQueue(path);
				}
				else
				{
					this.queue = MessageQueue.Create(path);
				}
				this.queue.Formatter = new BinaryMessageFormatter();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		private MessageQueue queue;

		public void Enqueue(T t)
		{
			try
			{
				this.queue.Send(t);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		public T Dequeue()
		{
			T t = default(T);

			try
			{
				t = this.queue.Receive().Body as T;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}

			return t;
		}
	}
}
