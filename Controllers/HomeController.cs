using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RedirectToAction_MVC.Models;

namespace RedirectToAction_MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

[HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult RedirectedAction(){

        return View();
    }

    public IActionResult ParametreAction(string name){
        return View("ParametreAction",name);
        // "ParametreAction": Dönüşte kullanılacak View'ın adıdır.
        // Yani Views/ControllerAdı/ParametreAction.cshtml dosyası açılır.
        // name: View'a model olarak gönderilen verilerdir. Bu durumda name, 
        // bir string model olarak View'a iletilir.
    }

    [HttpPost]
    public IActionResult Index(HomeViewModel model)
    {
        if (model.Name== "Hakan")
        {
            // bir acitondan başka bir actiona yönlendirme yapmak için kullanılır.
            //return RedirectToAction("RedirectedAction");
            // RedirectToAction ile bir acitondan başka bir actiona yönlenebilirsiniz.
            // RedirectToAction İLE FARKLI CONTROLLERDAKI BIR ACTIONA DA YONLENEBİLİRSNİZ.

            //return RedirectToAction("Index","Wissen");
            // RedirectToAction ile parametre transferi yapabilirsiniz.
            // name isimli Actionu diğer actiona parametre olarak gönderdik.
            return RedirectToAction("ParametreAction", new {name = model.Name});

        }
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
