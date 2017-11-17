using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Configuration;

namespace DataBaseTest2
{
    class Program
    {
        static UserRepository repo = new UserRepository();


        static void Add()
        {
            Console.WriteLine("\nEnter user name and age.");
            User user = new User();
            user.Name = Console.ReadLine();
            user.Age = int.Parse(Console.ReadLine());
            repo.Create(user);
            Console.WriteLine("Success added User");
        }
        static void printAll()
        {
            Console.WriteLine("\nOurHeroes:");
            List<User> users = repo.GetUsers();

            foreach (User user in users)
            {
                Console.WriteLine(String.Format("{0} is {1} years old", user.Name, user.Age));
            }
        }

        static void Delete()
        {
            Console.WriteLine("\nPlease, enter id of user, you'd like to delete");
            int id = int.Parse(Console.ReadLine());
            repo.Delete(id);
        }
        static void Update()
        {


            Console.WriteLine("\nid, name, age");
            User user = new User();
            user.Id = int.Parse(Console.ReadLine());
            user.Name = Console.ReadLine();
            user.Age = int.Parse(Console.ReadLine());
            repo.Update(user);
           
        }


        static void Main(string[] args)
        {
            //repo.Create(new User() { Name = "ROMAN", Age = 16 });
            Console.WriteLine("enter character");
            Console.WriteLine("a - Add user");
            Console.WriteLine("p - print all users");
            Console.WriteLine("u - update user");
            Console.WriteLine("d - delete");
            char c = Console.ReadKey().KeyChar;
            switch (c)
            {
                case 'a':
                    Add();
                    break;
                case 'u':
                    Update();
                    break;
                case 'p':
                    printAll();
                    break;
                case 'd':
                    Delete();
                    break;
                default:
                    break;
            }
            Console.ReadKey();
        }
    }
}
