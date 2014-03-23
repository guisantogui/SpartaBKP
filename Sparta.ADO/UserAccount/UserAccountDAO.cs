using Sparta.ADO.UserAccount;
using Sparta.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta.ADO
{
    public class UserAccountDAO
    {

        public readonly DatabaseContextADO context;

        public UserAccountDAO()
        {
            context = new DatabaseContextADO();
        }

        private void Insert(UserAccountModel userAccount)
        {
            var command = string.Format(UserAccountSQLs.Insert, userAccount.Username, userAccount.Password);
            context.ExecuteSqlWrite(command);
        }

        private void Update(UserAccountModel userAccount)
        {
            var command = string.Format(UserAccountSQLs.Update, userAccount.Username, userAccount.Password, userAccount.Id);
            context.ExecuteSqlWrite(command);
        }

        public void Save(UserAccountModel userAccount)
        {
            if (userAccount != null)
            {
                if (userAccount.Id > 0)
                {
                    Update(userAccount);
                }
                else
                {
                    Insert(userAccount);
                }

            }
        }

        public void Delete(int id)
        {
            var command = string.Format(UserAccountSQLs.Delete, id);
            context.ExecuteSqlWrite(command);
        }

        public IEnumerable<UserAccountModel> GetAllUsersAccounts()
        {
            var data = context.ExecuteSqlRead(UserAccountSQLs.SelectAll);
            return SqlDataReaderToIEnumerable(data);
        }

        public UserAccountModel GetUserById(int id)
        {
            var command = string.Format(UserAccountSQLs.SelectById, id);
            var data = context.ExecuteSqlRead(command);
            return SqlDataReaderToIEnumerable(data).FirstOrDefault();
        }

        private IEnumerable<UserAccountModel> SqlDataReaderToIEnumerable(SqlDataReader data)
        {
            UserAccountModel userAccount;
            var userAccounts = new List<UserAccountModel>();

            while (data.Read())
            {
                userAccount = new UserAccountModel
                                    {
                                        Id = int.Parse(data["accountId"].ToString()),
                                        Username = data["username"].ToString(),
                                        Password = data["password"].ToString()
                                    };
                userAccounts.Add(userAccount);
            }
            return userAccounts;

        }

    }
}
