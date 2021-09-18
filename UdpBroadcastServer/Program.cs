using System;
using System.Threading.Tasks;

namespace UdpBroadcastServer
{
    static class Program
    {
        private static Server _server;
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            _server = new Server(8844, "127.0.0.1");
            _server.Init();

            bool flag = true;
            while (flag)
            {
                Console.WriteLine("==================\n" +
                                  "\t1 - Send message\n" +
                                  "\t2 - Exit\n");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        await SendMessage();
                        break;
                    case "2":
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Error! Unexpected input!");
                        break;
                }
            }
        }

        private static async Task SendMessage()
        {
            Console.WriteLine("Enter message:\n");
            var input = Console.ReadLine();

            await _server.SendMessageAsync(input);
        }
    }
}