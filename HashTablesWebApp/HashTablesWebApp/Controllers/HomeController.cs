using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HashTablesWebApp.Models;

namespace HashTablesWebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly Random _random;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        _random = new Random();
    }

    public IActionResult Index()
    {
        var hashTable = new HashTableLinearProbing(5);
        for (var i = 0; i < hashTable.Buckets.Length; i++)
        {
            hashTable.Buckets[i].Value = _random.Next();
            if (i % 2 == 0)
                hashTable.Buckets[i].Next = new Cell(_random.Next());
        }

        return View(hashTable);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}