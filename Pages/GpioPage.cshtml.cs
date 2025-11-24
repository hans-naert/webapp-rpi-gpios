using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Device.Gpio;

namespace MyApp.Namespace
{
    public class GpioPageModel : PageModel
    {
        private readonly GpioController _gpioController;

        public GpioPageModel(GpioController gpioController)
        {
            _gpioController = gpioController;
        }

        public void OnGet()
        {
        }

        [BindProperty]
        public bool Output18 { get; set; }

        public void OnPost()
        {
            // Handle the form submission here
            Console.WriteLine($"Output18 value: {Output18}");
            Console.WriteLine($"Output18 is {Request.Form["Output18"]}");
            _gpioController.Write(18, Output18 ? PinValue.High : PinValue.Low);
        }   

    }
}
