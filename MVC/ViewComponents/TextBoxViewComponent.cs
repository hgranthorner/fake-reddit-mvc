using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.ViewComponents
{
    public class TextBoxViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string name, int number)
        {
            var n = await Task.FromResult(name);
            return View(new MyData {Name = n, Number = number});
        }   
    }
}