using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WepAPI.Controllers
{
    public class CarImageController
    {
        [Route("api/[controller]")]
        [ApiController]
        public class CarImageControlller : ControllerBase
        {
            ICarImageService _carImageService;

            public CarImageControlller(ICarImageService carImageService)
            {
                _carImageService = carImageService;

            }
            [HttpPost("add")]
            public IActionResult Add([FromForm(Name = ("file"))] IFormFile file, [FromForm] CarImage carImage)
            {
                var result = _carImageService.Add(file, carImage);
                if (result.Success)
                {
                    return Ok(result);

                }
                return BadRequest(result);

            }
            [HttpDelete("delete")]
            public IActionResult Delete([FromForm(Name = ("Id"))] int Id)
            {

                var carImage = _carImageService.Get(Id).Data;

                var result = _carImageService.Delete(carImage);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }

            [HttpPut("update")]
            public IActionResult Update([FromForm(Name = ("Image"))] IFormFile file, [FromForm(Name = ("Id"))] int Id)
            {
                var carImage = _carImageService.Get(Id).Data;
                var result = _carImageService.Update(file, carImage);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }



            [HttpGet("getall")]
            public IActionResult GetAll()
            {
                var result = _carImageService.GetAll();
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }


        }

    }
}
