using Microsoft.AspNetCore.Mvc;
using ReminderApp.Application.Interfaces.Usecases;
using ReminderApp.Domain.Entities;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReminderApp.Api.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class CategoryController : ControllerBase
   {
      private readonly IGetAllCategoryUseCase _getAllCategoryUseCase;
      public CategoryController(IGetAllCategoryUseCase getAllCategoryUseCase)
      {
         _getAllCategoryUseCase = getAllCategoryUseCase;
      }

      // GET: api/<CategoryController>
      [HttpGet]
      public IEnumerable<Category> Get()
      {
         return _getAllCategoryUseCase.Execute();
      }

      // GET api/<CategoryController>/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
         return "value";
      }

      // POST api/<CategoryController>
      [HttpPost]
      public void Post([FromBody] string value)
      {
      }

      // PUT api/<CategoryController>/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody] string value)
      {
      }

      // DELETE api/<CategoryController>/5
      [HttpDelete("{id}")]
      public void Delete(int id)
      {
      }
   }
}
