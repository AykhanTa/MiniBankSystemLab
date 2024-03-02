namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person[] users = new Person[0];
            while (true)
            {
                Console.WriteLine("Proses secin:");
                Console.WriteLine("1.Add user.");
                Console.WriteLine("2.Show users:");
                Console.WriteLine("3.Login.");
                Console.WriteLine("4.Exit");

            TakeCommand:
                bool n = int.TryParse(Console.ReadLine(), out int command);

                if (command > 0 && command < 4)
                {
                    switch (command)
                    {
                        case 1:
                            AddUser(ref users);
                            break;
                        case 2:
                            ShowUsers(users);
                            break;
                        case 3:
                            Console.WriteLine("Login");
                            break;
                    }
                }
                else if (command == 4)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Duzgun proses daxil edin.");
                    goto TakeCommand;
                }

            }            
        }

        static void AddUser(ref Person[] users)
        {
            Console.WriteLine("Username daxil edin:");
            string username= Console.ReadLine();
            Console.WriteLine("Password daxil edin:");
            string password= Console.ReadLine();

            bool check = isUniqueUsername(username, users);

            if (check)
            {
                TakeUserName:
                Console.WriteLine("Basqa Username daxil edin:");
                username=Console.ReadLine();

                bool checks=isUniqueUsername(username, users);
                if (checks)
                {
                    goto TakeUserName;

                }
            }
            Person user=new Person();
            user.Username=username;
            user.Password = password;

            Array.Resize(ref users, users.Length+1);
            users[users.Length-1]=user;

        }

        static bool isUniqueUsername(string username, Person[] users)
        {
            bool isUnique=false;
            foreach (Person user in users)
            {
                if (user.Username == username)
                {
                    isUnique= true;
                    break;
                }
            }
            return isUnique;
        }

        static void ShowUsers(Person[] users)
        {
            foreach (var user in users)
            {
                Console.WriteLine($"Username: {user.Username} Password:{user.Password}");
            }
        }
    }
}