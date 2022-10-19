using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Device.Gpio;

namespace aspnetcoreapp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private GpioController controller;

    public IndexModel(GpioController controller, ILogger<IndexModel> logger)
    {
        this.controller=controller;
        _logger = logger;
    }

    [BindProperty]
    public bool Output18 { get; set; }

    public void OnGet()
    {

    }

    public void OnPost()
    {
        //using(var controller = new GpioController())
        {
           // controller.OpenPin(18,PinMode.Output);
            controller.Write(18,Output18?PinValue.High:PinValue.Low);
            Console.WriteLine($"Output 1 is {Output18}");
        }
    }

}
