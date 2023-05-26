﻿using DataBase;
using DataBase.Services.Users;
using lab6.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace lab6.Controllers
{
    
        [ApiController]
        [Route("api/[controller]")]
        public class ProductController : ControllerBase
        {
            private readonly IProductRepository productRepository;

            public ProductController(IProductRepository productRepository)
            {
                this.productRepository = productRepository;
            }

            [HttpGet]
            public ActionResult<IEnumerable<Product>> Get(
                [FromQuery] int page = 1,
                [FromQuery] int min_price = 0,
                [FromQuery] int max_price = int.MaxValue,
                [FromQuery] int onPage = 20)
            {
                Product[] data = productRepository.Get(page, onPage, min_price, max_price);
                return data;
            }

            [HttpGet("{id}")]   
            public ActionResult<Product> Get([FromRoute] int id)
            {
                var user = productRepository.Get(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }

            [HttpPost]
            public ActionResult Post([FromBody] AddProductContract contract)
            {
                var product = new Product()
                {
                    Name = contract.Name,
                    Description = contract.Description,
                    Price = contract.Price
                };
                productRepository.Create(product);
                return Ok();
            }

            [HttpPut]
            public ActionResult Update([FromBody] NewProductContract contract)
            {
            var product = new Product()
            {
                Name = contract.Name,
                Description = contract.Description,
                Price = contract.Price,
                Isdeleted = contract.Isdeleted
            };

                productRepository.Update(product);
                return Ok();
            }



            [HttpDelete("{id}")]  
            public ActionResult Delete([FromRoute] int id)
            {
                productRepository.Delete(id);
                return Ok();
            }
    }
}