using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutomatedTellerMachine.Models;
using Microsoft.AspNet.Identity;

namespace AutomatedTellerMachine.Controllers
{
    public class TransactionController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Transaction
        public ActionResult Index()
        {
            return View();
        }

        // GET: Transaction/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Transaction/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transaction/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //GET: Transaction/Deposit
        [Authorize]
        [HttpGet]
        //[ValidateAntiForgeryToken]
        public ActionResult Deposit()
        {
            var currentUserId = "";
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    currentUserId = User.Identity.GetUserId();
                }

                if (ModelState.IsValid)
                {
                    //var transactions = _db.Transactions.Where(a => a.ApplicationUserId == currentUserId && a.Amount >= 0).ToList();
                    //if (transactions.Count <=0)
                    //    return HttpNotFound();
                    //return View("DepositList",transactions);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not retrieve deposit list. Errors: {ex}");
            }   
        }

        //POST: Transaction/Deposit
        [Authorize]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Deposit(Transaction transaction)
        {
            var currentUserId = "";
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    currentUserId = User.Identity.GetUserId();
                }

                if (ModelState.IsValid)
                {
                    var checkingAcctId = 0;
                    var defaultCheckAcct = _db.CheckingAccounts
                        .FirstOrDefault(a => a.ApplicationUserId == currentUserId);
                    if (defaultCheckAcct != null)
                    {
                        checkingAcctId = defaultCheckAcct.Id;
                        defaultCheckAcct.Balance += transaction.Amount;
                    }

                    var transToAdd = transaction;
                    transToAdd.TransactionTimeStamp = DateTime.Today;
                    transToAdd.CheckingAccountId = checkingAcctId;
                    _db.Transactions.Add(transToAdd);
                    _db.SaveChanges();

                    _db.Entry(defaultCheckAcct).State = EntityState.Modified;
                    _db.SaveChanges();
                }
                return RedirectToAction("Deposit","Transaction",null);
            }
            catch(Exception ex)
            {
                throw new Exception($"Error while deposit. Error: {ex}");
            }
        }

        // GET: Transaction/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Transaction/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Transaction/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Transaction/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
