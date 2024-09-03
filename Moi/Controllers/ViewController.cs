using GaragesStructure.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GaragesStructure.Controllers
{
    public class ViewController : Controller
    {
        // Change the method name to `Index` to map to the `/index` endpoint
        public IActionResult Index()
        {
            // Return the `chunk.cshtml` view instead of `index.cshtml`
            return View("chunk", new IndexModel());
        }
    }
}