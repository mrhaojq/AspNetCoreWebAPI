using System;
using System.Collections.Generic;
using System.Net.Http;
using ProtoBuf;

namespace ProtobufTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            HttpClient client = new HttpClient();
            var stream = client.GetStreamAsync("http://localhost:6820/api/users/proto").Result;

            var users = Serializer.Deserialize<List<UserForProto>>(stream);

            foreach (var user in users)
            {
                Console.WriteLine($"ID:{user.Id} Name:{user.Name} Age:{user.Age}");
            }

            Console.ReadKey();
        }
    }
}
