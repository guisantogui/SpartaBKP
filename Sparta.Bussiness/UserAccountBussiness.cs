using Sparta.ADO;
using Sparta.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sparta.ADO.UserAccount;

namespace Sparta.Bussiness
{
    public class UserAccountBussiness
    {

        public readonly UserAccountDAO userAccountDAO;

        public UserAccountBussiness()
        {
            userAccountDAO = new UserAccountDAO();
        }

        public void Save(UserAccountModel userAccount)
        {
            userAccountDAO.Save(userAccount);
        }

        public void DeleteUser(int id)
        {
            userAccountDAO.Delete(id);
        }

        public IEnumerable<UserAccountModel> GetUserAccounts()
        {
            return userAccountDAO.GetAllUsersAccounts();
        }

        public UserAccountModel GetUserAccountById(int id)
        {
            return userAccountDAO.GetUserById(id);
        }

    }
}
