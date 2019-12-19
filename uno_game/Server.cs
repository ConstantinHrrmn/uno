using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using uno_game;

class Server
{
    TcpListener server = null;
    Controller ctrl;

    public Server(string ip, int port, Controller controller)
    {
        this.ctrl = controller;

        IPAddress localAddr = IPAddress.Parse(ip);
        server = new TcpListener(localAddr, port);
        server.Start();
        StartListener();
    }

    public void StartListener()
    {
        try
        {
            while (true)
            {
                Console.WriteLine("Waiting for a connection...");
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Connected!");

                Thread t = new Thread(new ParameterizedThreadStart(HandleDeivce));
                t.Start(client);
            }
        }
        catch (SocketException e)
        {
            Console.WriteLine("SocketException: {0}", e);
            server.Stop();
        }
    }

    public void HandleDeivce(Object obj)
    {
        TcpClient client = (TcpClient)obj;
        var stream = client.GetStream();
        string imei = String.Empty;

        string data = null;
        Byte[] bytes = new Byte[256];
        int i;
        try
        {
            while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                string hex = BitConverter.ToString(bytes);
                data = Encoding.ASCII.GetString(bytes, 0, i);
                Console.WriteLine("{1}: Received: {0}", data, Thread.CurrentThread.ManagedThreadId);

                string[] words = data.Split(';');
                string str = "Hey Device!";

                switch (words[0])
                {
                    case "newPlayer":
                        Console.WriteLine(words[1]);
                        this.ctrl.CreatePlayer(words[1], words[2]);
                        str = "Welcome to the game " + words[1];
                        break;
                    case "Players":
                        str = "Test ok";
                        str = Serial.Serialize(this.ctrl.Players);
                        break;
                    case "Deck":
                        str = Serial.Serialize(this.ctrl.Deck);
                        break;
                    case "Stack":
                        str = Serial.Serialize(this.ctrl.Stack);
                        break;
                    case "Player":
                        str = Serial.Serialize(this.ctrl.ActualPlayer);
                        break;
                    case "PlusToGive":
                        str = Serial.Serialize(this.ctrl.PlusToGiveToNextlayer());
                        break;
                    case "infos":
                        str = Serial.Serialize(this.ctrl.Players);
                        str += Serial.Serialize(this.ctrl.Deck);
                        str += Serial.Serialize(this.ctrl.Stack);
                        str += Serial.Serialize(this.ctrl.ActualPlayer);
                        str += Serial.Serialize(this.ctrl.PlusToGiveToNextlayer());
                        break;
                    case "Controller":
                        str = Serial.Serialize(this.ctrl);
                        break;
                }


                Byte[] reply = System.Text.Encoding.ASCII.GetBytes(str);
                stream.Write(reply, 0, reply.Length);
                Console.WriteLine("{1}: Sent: {0}", str, Thread.CurrentThread.ManagedThreadId);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: {0}", e.ToString());
            client.Close();
        }
    }
}