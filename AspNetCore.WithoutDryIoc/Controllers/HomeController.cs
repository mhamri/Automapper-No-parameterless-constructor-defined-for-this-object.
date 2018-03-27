using AspNetCore.WithDryIoc.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.WithDryIoc.Controllers
{
    public class HomeController : Controller
    {
        // GET
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

            return Ok(sampleClass);
        }
    }
}