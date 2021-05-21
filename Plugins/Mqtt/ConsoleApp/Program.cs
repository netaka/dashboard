using System;
using Mqtt;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var mqtt = new Class1(args[0]);
            mqtt.Connect();

            Console.ReadKey();
        }
    }
}
