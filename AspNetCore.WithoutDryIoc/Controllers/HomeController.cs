using AspNetCore.WithoutDryIoc.Models;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.WithoutDryIoc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment _hosting;

        public HomeController(IHostingEnvironment hosting)
        {
            _hosting = hosting;
        }
        public IActionResult Index()
        {
            //this throw parameterless construct
            var dto = new SampleClassDto()
            {
                Id = 1,
                Name = "test",
                ComplexType = new ComplexType()
                {
                    Id = 9999
                }
            };

            var sampleClass= Mapper.Map<SampleClass>(dto);

            return Ok(new {makeSureHostRegistered= _hosting, sampleClass});
        }
    }
}