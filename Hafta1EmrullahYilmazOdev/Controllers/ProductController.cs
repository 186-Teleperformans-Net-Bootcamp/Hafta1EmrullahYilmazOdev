using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Hafta1EmrullahYilmazOdev.Model;



namespace Hafta1EmrullahYilmazOdev.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private static List<Product> products = new List<Product>()
        {
            new Product(0,"Bread",90),
            new Product(1,"Diamond",70),
            new Product(2,"Eggs",50),
            new Product(3,"Chicken",100),
            new Product(4,"Diamond",80),
        };


        [HttpGet]
        public IActionResult Get()
        {
            
            return Ok(products); //http 200

        }

        [HttpGet("Id")]
        public IActionResult GetById(int Id)
        {
            try
            {
                Product product = products.Find(f => f.Id == Id);
                return Ok(product); //http 200
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error"); //http 500
            }

        }
        [HttpGet("Name")]
        public IActionResult GetProductByListName([FromQuery] string Name)
        {
            try
            {
                var product = products.Where(f => f.Name == Name).ToList();


                return Ok(product); //http 200
            }
            catch (Exception ex)
            {
                return NotFound(); //http 404
            }

        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            try
            {
                products.Add(product);
                return Created("~api/Products", product);  //http 201
            }
            catch (Exception ex)
            {
                return BadRequest(); //http400
            }

        }

        [HttpPut]
        public IActionResult Put(int Id, [FromBody] Product product)
        {
            Product productToUpdate = products.Find(f => f.Id == Id);
            int index = products.IndexOf(productToUpdate);
            products[index].Id = product.Id;
            products[index].Name = product.Name;
            products[index].Price = product.Price;

            return Ok(product);  //http 200
        }
        [HttpPatch]
        public IActionResult Patch([FromQuery] string select, int id ,string updater)
        {
            //Product productToUpdate = products.Find(f => f.Id == id);
            switch (select)
            {
                case "Name":
                    Product productToUpdate = products.SingleOrDefault(g => g.Id == id);
                    int index = products.IndexOf(productToUpdate);
                    products[index].Name = updater;
                    return Ok(productToUpdate);//http 200
                case "Id":
                    Product productToUpdatee = products.SingleOrDefault(g => g.Id == id);
                    var ss = products.SingleOrDefault(g => g.Id == id);
                    int indexx = products.IndexOf(ss);
                    products[indexx].Id = Convert.ToInt32(updater);
                    return Ok(productToUpdatee);//http 200
                case "Price":
                    Product productToUpdateee = products.SingleOrDefault(g => g.Id == id);
                    var sss = products.SingleOrDefault(g => g.Id == id);
                    int indexxx = products.IndexOf(sss);
                    products[indexxx].Price = Convert.ToInt32(updater);
                    
                    return Ok(productToUpdateee);//http 200

                default:
                    return NotFound();//http 404
            }

            //return Ok(products);  //http 204 
            //Product productpatch = products.Find(f => f.Id == product.Id);
            //int index = products.IndexOf(productpatch);
            //products[index].Id = product.Id;
            //products.SingleOrDefault(g => g.Id == Id);
            return Ok();  //http 204 
        }

        [HttpDelete("Id")]
        public IActionResult Delete(int Id)
        {
            Product product = products.Find(f => f.Id == Id);
            products.Remove(product);
            return NoContent();  //http 204

        }
        [HttpGet("list")]
        public IActionResult SortProductByName([FromQuery] string sortmethod)
        {

            switch (sortmethod)
            {

                case "Name":
                    return Ok(products.OrderBy(a => a.Name).ToArray());//http 200

                case "Id":
                    return Ok(products.OrderBy(a => a.Id).ToArray());//http 200

                case "Price":
                    return Ok(products.OrderBy(a => a.Price).ToArray());//http 200

                default:
                    return NotFound();//http 404
            }


        }
    }
}
