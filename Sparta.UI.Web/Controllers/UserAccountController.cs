using Sparta.Bussiness;
using Sparta.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sparta.UI.Web.Controllers
{
    public class UserAccountController : Controller
    {

        public ActionResult Index()
        {
            var userAccountBussiness = new UserAccountBussiness();

            return View(userAccountBussiness.GetUserAccounts());
        }

        public ActionResult Details(int id)
        {
            var userAccountBussiness = new UserAccountBussiness();

            return View(userAccountBussiness.GetUserAccountById(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserAccountModel userAccount)
        {
            if (ModelState.IsValid)
            {
                var userAccountBussiness = new UserAccountBussiness();
                userAccountBussiness.Save(userAccount);
                return RedirectToAction("Index");
            }

            return View(userAccount);
        }

        public ActionResult Edit(int id)
        {
            var userAccountBussiness = new UserAccountBussiness();
            var userAccount = userAccountBussiness.GetUserAccountById(id);

            if (userAccount == null)
            {
                HttpNotFound();
            }

            return View(userAccount);
        }

        [HttpPost]
        public ActionResult Edit(UserAccountModel userAccount)
        {
            if (ModelState.IsValid)
            {
                var userAccountBussiness = new UserAccountBussiness();
                userAccountBussiness.Save(userAccount);
                return RedirectToAction("Index");
            }

            return View(userAccount);
        }


        public ActionResult Delete(int id)
        {
            var userAccountBussiness = new UserAccountBussiness();
            var userAccount = userAccountBussiness.GetUserAccountById(id);

            if (userAccount == null)
            {
                HttpNotFound();
            }

            return View(userAccount);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteOk(int id)
        {
            var userAccountBussiness = new UserAccountBussiness();
            userAccountBussiness.DeleteUser(id);

            return RedirectToAction("Index");
        }
    }
}
