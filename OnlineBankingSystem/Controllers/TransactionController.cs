using Microsoft.AspNetCore.Mvc;
using OnlineBankingSystem.Models;

namespace OnlineBankingSystem.Controllers
{
    public class TransactionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Deposit(string accountNumber, decimal amount)
        {
            var account = AccountController.accounts.Find(a => a.AccountNumber == accountNumber);
            if (account == null) return NotFound();

            try
            {
                account.Deposit(amount);
                return RedirectToAction("Details", "Account", new { accountNumber });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View("Index");
            }
        }

        [HttpPost]
        public IActionResult Withdraw(string accountNumber, decimal amount)
        {
            var account = AccountController.accounts.Find(a => a.AccountNumber == accountNumber);
            if (account == null) return NotFound();

            try
            {
                account.Withdraw(amount);
                return RedirectToAction("Details", "Account", new { accountNumber });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View("Index");
            }
        }
    }
}
