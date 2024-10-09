using Microsoft.AspNetCore.Mvc;
using OnlineBankingSystem.Models;
using System.Collections.Generic;

namespace OnlineBankingSystem.Controllers
{
    public class AccountController : Controller
    {
        private static List<Account> accounts = new List<Account>();

        public IActionResult Index()
        {
            return View(accounts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string name, string phone, string accountType)
        {
            var accountNumber = GenerateAccountNumber();
            Account newAccount = null;

            switch (accountType)
            {
                case "Savings":
                    newAccount = new SavingsAccount(name, accountNumber);
                    break;
                case "Current":
                    newAccount = new CurrentAccount(name, accountNumber);
                    break;
                case "Business":
                    newAccount = new BusinessAccount(name, accountNumber);
                    break;
                default:
                    ModelState.AddModelError(string.Empty, "Invalid account type.");
                    return View();
            }

            accounts.Add(newAccount);
            return RedirectToAction("Index");
        }

        public IActionResult Details(string accountNumber)
        {
            var account = accounts.Find(a => a.AccountNumber == accountNumber);
            if (account == null) return NotFound();
            return View(account);
        }

        private string GenerateAccountNumber()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
