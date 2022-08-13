using System;
using System.Collections.Generic;
using System.IO;

namespace FileCreateReadTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool IsContinue = true;
            User user = new User();
            while (IsContinue)
            {
                Console.WriteLine("What do you want?\n1.Create User\n2.Show All Users\n3.Delete User\n4.Exit");
                int answer = int.Parse(Console.ReadLine());
                switch (answer)
                {
                    case 1:
                        user.RegisterUser(user.CreateUser());
                        break;
                    case 2:
                        user.PrintUsers(user.GetUsers());
                        break;
                    case 3:
                        user.SelectUser();
                        break;
                    case 4:
                        IsContinue = false;
                        break;
                    default:
                        break;
                }
            }

            
        }
      
    }
}
