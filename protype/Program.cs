using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Client
{
	internal class Program
	{
		static Socket sck;
		static void Main(string[] args)
		{
			string bem;
			sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);
			try
			{
				sck.Connect(localEndPoint);
			}
			catch
			{
				Console.WriteLine("Nem tud capcsolódni");
				Main(args);
			}
			do
			{
				Console.WriteLine("Parancsot add ki: [login(bejelentkezés, reg(regisztrálás), exit(bezárás)]");
				bem=Console.ReadLine();
				byte[] data;
				switch (bem)
					{
					case "reg":
						//register
						Console.WriteLine("Regisztáció");
						string fel="<REG>";
						Console.Write("Felhasználónév: ");
						fel=fel+Console.ReadLine();
						Console.WriteLine();
						Console.Write("Jelszó: ");
						fel=fel+";"+Console.ReadLine();
						data = Encoding.UTF8.GetBytes(fel);

						sck.Send(data);
						break;
						
					case "log": //login
						Console.WriteLine("Bejelentkezés");
						string bej="<LOGIN>";
						Console.Write("Felhasználónév: ");
						bej=bej+Console.ReadLine();
						Console.WriteLine();
						Console.Write("Jelszó: ");
						bej=bej+";"+Console.ReadLine();
						Console.WriteLine();
						data = Encoding.UTF8.GetBytes(bej);

						sck.Send(data);
						break;
						
					case "exit": //exit
								 
						Console.WriteLine("Kilépés a programból");
						break;
					//----------------------------------------------
					default:
						Console.WriteLine("Nem felismert parancs");
						break;
				}
			} while (bem=="exit");



			/*Console.Write("Enter text:  ");
			string text = Console.ReadLine();
			byte[] data = Encoding.UTF8.GetBytes(text);

			sck.Send(data);
			Console.WriteLine("Elküldve \r\n");*/
			Console.WriteLine("PRESS ANY KEY!");
			Console.ReadKey();
			sck.Close();
		}
	}
}
