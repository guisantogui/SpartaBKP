using Sparta.ADO;
using Sparta.Bussiness;
using Sparta.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta.UI.Tests
{
    class Program
    {
        static void Main(string[] args)
        {

            //var context = new DatabaseContext();

            //context.ExecuteSqlWrite("INSERT INTO UserAccount (username, password) VALUES ('pepe','batman')");

            var uab = new UserAccountBussiness();

            var user = uab.GetUserAccountById(3);
            Console.WriteLine(string.Format("Username: {0}, Password: {1}", user.Username, user.Password));
            Console.Read();
           // account.Id = 2;

            //uab.Save(account);

            //uab.DeleteUser(2);

            //foreach (var user in uab.GetUserAccounts())
            //{
            //    Console.WriteLine( string.Format("Username: {0}, Password: {1}", user.Username, user.Password));
            //    Console.Read();
            //}

            

        }
    }
}
