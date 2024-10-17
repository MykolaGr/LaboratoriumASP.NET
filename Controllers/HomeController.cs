using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Laboratorium1.Models;

namespace Laboratorium1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Calculator(Operator op, double? a, double? b)
    {
        if (a == null || b == null)
        {
            ViewBag.Error = "Both operands 'a' and 'b' are required!";
            return View();
        }
        
        double result = 0;
        string operation = "";

        switch (op)
        {
            case Operator.Add:
                result = a.Value + b.Value;
                operation = "add";
                break;
            case Operator.Sub:
                result = a.Value - b.Value;
                operation = "sub";
                break;
            case Operator.Mul:
                result = a.Value * b.Value;
                operation = "mul";
                break;
            case Operator.Div:
                if (b.Value != 0)
                {
                    result = a.Value / b.Value;
                    operation = "div";
                }
                else
                {
                    ViewBag.Error = "Division by zero is not allowed!";
                    return View();
                }
                break;
            default:
                ViewBag.Error = "Invalid operation!";
                return View();
        }

        ViewBag.A = a.Value;
        ViewBag.B = b.Value;
        ViewBag.Op = operation;
        ViewBag.Result = result;

        return View();
        }
    
    public enum Operator
    {
        Unknown, Add, Mul, Sub, Div
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
