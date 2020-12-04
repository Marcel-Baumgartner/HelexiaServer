using System;
using System.IO;
using System.Net.Sockets;
using System.Net;

using HelexiaNetwork.Network.Packages;

namespace HelexiaServer.Network.Server
{
    public class ServerListener
    {
        public int port;
        public TcpListener listener;

        public ServerListener(int _port)
        {
            port = _port;
        }

        public void Start()
        {
            listener = new TcpListener(IPAddress.Any, port);

            listener.Start();

            listener.BeginAcceptTcpClient(ClientConnected_Callback, null);
        }

        private void ClientConnected_Callback(IAsyncResult ar)
        {
            TcpClient client = listener.EndAcceptTcpClient(ar);
            listener.BeginAcceptTcpClient(ClientConnected_Callback, null);

            byte[] buffer = new byte[104857600]; //104857600 Bytes -> 100 MB

            Stream netStream = client.GetStream();

            int lenght = netStream.Read(buffer, 0, buffer.Length);
            byte[] forPackage = new byte[lenght];
            Array.Copy(buffer, 0, forPackage, 0, lenght);

            Package fromClient = new Package(forPackage);

            Package response = new Package();

            netStream.Write(response.GetBytes(), 0, response.GetLenght());

            client.Close();
        }
    }
}
