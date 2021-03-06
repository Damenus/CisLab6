﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CisLab6_Server
{
    class Program
    {
        public void serverThread()
        {
            UdpClient udpClient = new UdpClient(8080);
            while (true)
            {
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                Byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);
                string returnData = Encoding.ASCII.GetString(receiveBytes);
                Console.Out.Write(RemoteIpEndPoint.Address.ToString() + ":" + returnData.ToString());
            }
        }

        static void Main(string[] args)
        {
            Task mainTask = Task.Run(
                () =>
                {
                    Thread thdUDPServer = new Thread(new ThreadStart(serverThread));
                    thdUDPServer.Start();
                });

        }
    }
}
