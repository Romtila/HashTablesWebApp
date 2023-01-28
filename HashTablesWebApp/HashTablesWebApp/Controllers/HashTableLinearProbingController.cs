using Microsoft.AspNetCore.Mvc;

namespace HashTablesWebApp.Controllers;

public class HashTableLinearProbingController : Controller
{
    private readonly ILogger<HashTableLinearProbingController> _logger;

    public HashTableLinearProbingController(ILogger<HashTableLinearProbingController> logger)
    {
        _logger = logger;
    }

    public IActionResult Add()
    {
        return Empty;
    }

    public IActionResult Delete()
    {
        return Empty;
    }
}