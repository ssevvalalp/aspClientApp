using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using aspClientApp.Models;
using System.Text.Json;

namespace aspClientApp.Controllers;

public class HomeController : Controller
{
    

    public async Task <IActionResult> Index()
    {
        var products = new List<ProductDTO>(); //gelecek olan datalar ProductDTO listesine doldurulur

        using(var httpClient = new HttpClient())
        {
          using (var response = await httpClient.GetAsync("http://localhost:5265/api/products"))
            {
                //servisten gelen datalar string olarak okunur
                string apiResponse = await response.Content.ReadAsStringAsync();
                //Deserialize
                products = JsonSerializer.Deserialize<List<ProductDTO>>(apiResponse); //göderilecek olan string değer apiResponse
            }
        }
        return View(products);
    }

    
}
