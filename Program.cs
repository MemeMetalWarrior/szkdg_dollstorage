using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace Client
{
	internal class Program
	{
		static Socket sck;
		static void Main(string[] args)
		{
			sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);
			try
			{
				sck.Connect(localEndPoint);
			}
			catch {
				Console.WriteLine("Nem tud capcsolódni");
				Main(args);
			}
			Console.Write("Enter text:  ");
			string text = Console.ReadLine();
			byte[] data = Encoding.UTF8.GetBytes(text);

			sck.Send(data);
			Console.WriteLine("Elküldve \r\n");
			Console.WriteLine("PRESS ANY KEY!");
			Console.ReadKey();
			sck.Close();
		}
	}
}
