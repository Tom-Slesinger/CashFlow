﻿using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Controllers
{
    public class TransactionController : Controller
    {
        public IActionResult Index()
        {
            return View("Transaction");
        }
    }
}
