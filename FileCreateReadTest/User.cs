using System;
using System.Collections.Generic;
using System.IO;

namespace FileCreateReadTest
{

    public class User
    {
        const string FileLocation = @"D:\";


        public string FinCode { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public DateTime CreatedAt { get; set; }

        public User CreateUser()
        {
            User user = new User();

            Console.WriteLine("Enter user fin code: ");
            user.FinCode = Console.ReadLine();

            Console.WriteLine("Enter user name: ");
            user.Name = Console.ReadLine();

            Console.WriteLine("Enter user surname: ");
            user.Surname = Console.ReadLine();

            Console.WriteLine("Enter user age: ");
            user.Age = int.Parse(Console.ReadLine());

            user.CreatedAt = DateTime.Now;

            return user;
        }

        public void RegisterUser(User user)
        {
            string filePath = Path.Combine(FileLocation + $"{user.FinCode}.txt");
            
            if (File.Exists(filePath))
            {
                Console.WriteLine("User is already registred!");
            }
            else
            {
                string fileText = $"FinCode: {user.FinCode}\n" +
                    $"Name: {user.Name}\n" +
                    $"Surname: {user.Surname} \n" +
                    $"Age: {user.Age} \n" +
                    $"CreatedAt: {user.CreatedAt}";
                File.WriteAllText(filePath, fileText);
                Console.WriteLine("User is successfuly registred!");
            }
        }

        public List<User> GetUsers()
        {
            var files = Directory.GetFiles(FileLocation);
            List<User> users = new List<User>();

            foreach (var file in files)
            {
                string[] fileText = File.ReadAllLines(file);
                User user = new User();
                user.FinCode = fileText[0].Split(' ')[1].Trim();
                user.Name = fileText[1].Split(' ')[1].Trim();
                user.Surname = fileText[2].Split(' ')[1].Trim();
                user.Age = int.Parse(fileText[3].Split(' ')[1].Trim());
                user.CreatedAt = DateTime.Parse(fileText[4].Split(' ')[1].Trim());

                users.Add(user);
            }
            return users;
        }

        public void PrintUsers(List<User> users)
        {
            foreach (var user in users)
            {
                PrintUser(user);

            }
        }

        public void PrintUser(User user)
        {
            Console.WriteLine("_________________________________________\n");

            Console.WriteLine(nameof(user.FinCode) + " " + user.FinCode);
            Console.WriteLine(nameof(user.Name) + " " + user.Name);
            Console.WriteLine(nameof(user.Surname) + " " + user.Surname);
            Console.WriteLine(nameof(user.Age) + " " + user.Age);
            Console.WriteLine(nameof(user.CreatedAt) + " " + user.CreatedAt);

            Console.WriteLine("\n\n");
        }

        public void SelectUser()
        {
            Console.WriteLine("Select Delete User FIn Code:");
            string finCode = Console.ReadLine();
            DeleteUser(finCode);
        }

        public void DeleteUser(string finCode)
        {
            var filePath = Path.Combine(FileLocation + $"{finCode}.txt");
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                Console.WriteLine("User is successfully deleted");
            }
            else
            {
                Console.WriteLine("User cannot find!");
            }
        }
    }
}
