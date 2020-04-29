using BFS_c_sharp.Model;
using System;
using System.Collections.Generic;

namespace BFS_c_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomDataGenerator generator = new RandomDataGenerator();
            List<UserNode> users = generator.Generate();

            foreach (var user in users)
            {
                Console.WriteLine(user);
            }

            Console.WriteLine("Done");

            UserNode user1 = users[1];
            UserNode user2 = users[2];
            int distance = UserNode.Distance(user1, user2);

            Console.WriteLine($"Distance between: {user1.FirstName} {user1.LastName} " +
                                           $"and  {user2.FirstName} {user2.LastName} is {distance}");

            Console.ReadKey();
        }
    }
}
