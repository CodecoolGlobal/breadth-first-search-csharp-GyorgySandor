using System;
using System.Collections.Generic;

namespace BFS_c_sharp.Model
{
    public class UserNode
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private readonly HashSet<UserNode> _friends = new HashSet<UserNode>();

        public HashSet<UserNode> Friends
        {
            get { return _friends; }
        }


        public UserNode() { }

        public UserNode(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public void AddFriend(UserNode friend)
        {
            Friends.Add(friend);
            friend.Friends.Add(this);
        }

        public override string ToString()
        {
            return FirstName + " " + LastName + "(" + Friends.Count + ")";
        }

        public static int Distance(UserNode startingUser, UserNode targetUser)
        {
            Queue<UserNode> nextToVisit = new Queue<UserNode>();
            Dictionary<UserNode, int> visited = new Dictionary<UserNode, int>();
            nextToVisit.Enqueue(startingUser);
            int distance = 0;
            visited.Add(startingUser, distance);
 
            while (nextToVisit.Count != 0)
            {
                UserNode currentUser = nextToVisit.Dequeue();


                foreach (UserNode friend in currentUser.Friends)
                {
                    if (!visited.ContainsKey(friend))
                    {
                        int dist;
                        visited.TryGetValue(currentUser, out dist);
                        Console.WriteLine(dist);
                        visited.Add(friend, dist + 1);
                        nextToVisit.Enqueue(friend);
                    }
                    if (targetUser.Equals(friend))
                    {
                        visited.TryGetValue(friend, out distance);
                        return distance;                       
                    }                                   
                }
            }
            return distance;
        }

        public static void friendOfFriends(UserNode startingUser, int distance)
        {
            Queue<UserNode> nextToVisit = new Queue<UserNode>();
            Dictionary<UserNode, int> visited = new Dictionary<UserNode, int>();
            nextToVisit.Enqueue(startingUser);
            
            visited.Add(startingUser, 0);
            bool distanceReached = false;
            List<UserNode> friendsList = new List<UserNode>();

            while (!distanceReached)
            {
                UserNode currentUser = nextToVisit.Dequeue();

                int lastDist;
                visited.TryGetValue(currentUser, out lastDist);
                if (lastDist + 1 == distance) { distanceReached = true; }


                foreach (UserNode friend in currentUser.Friends)
                {
                    if (!visited.ContainsKey(friend))
                    {
                        int dist;
                        visited.TryGetValue(currentUser, out dist);
                        Console.WriteLine(dist);
                        visited.Add(friend, dist + 1);
                        nextToVisit.Enqueue(friend);
                        
                    }

                }

                if (distanceReached)
                {
                    foreach (KeyValuePair<UserNode, int> entry in visited) {
                        if (entry.Value == distance)
                        {
                            friendsList.Add(entry.Key);
                        }
                    }
                }

            }
            Console.WriteLine($"{startingUser.FirstName} {startingUser.LastName} has {friendsList.Count} friends in" +
                              $" {distance} distance: ");
            foreach (UserNode friend in friendsList){
                Console.WriteLine($"{friend.FirstName} {friend.LastName}");
            }
        }
    }
}
