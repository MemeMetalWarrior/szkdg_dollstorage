using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace serverconn
{
	internal class Program
	{
		static byte[] Buffer {  get; set; }
		static Socket sck;

		static void Main(string[] args)
		{
			sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			sck.Bind(new IPEndPoint(0, 1234));
			sck.Listen(100);

			Socket accepted = sck.Accept();
			Buffer = new byte[accepted.ReceiveBufferSize];
			Console.WriteLine("Mükszik");
			int bytesRead = accepted.Receive(Buffer);
			Console.WriteLine("Mükszik 2");
			byte[] formatted = new byte[bytesRead];
			for (int i = 0; i < bytesRead; ++i)
			{
				formatted[i] = Buffer[i];
			}
			string strData = Encoding.UTF8.GetString(formatted);
			Console.WriteLine(strData + "\r\n");
			Console.ReadKey();
			accepted.Close();
		}
	}
}
