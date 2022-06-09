﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReminderApi.Api.Models;
using ReminderApi.Application.Interfaces;
using ReminderApi.Domain.Entities;
using ReminderApi.Infrastructure.Context;

namespace ReminderApi.Api.Controllers
{
    [Route("api/v1/category")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;


        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _categoryService.GetAllAsync());
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _categoryService.GetByAsyncId(id));
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryEntry category)
        {
            await _categoryService.AddAsync(CategoryEntryToCategory(category));
            return Ok();
        }

        // PUT api/v1/<CategoriesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CategoryEntry category)
        {
            await _categoryService.UpdateAsync(id, CategoryEntryToCategory(category));
            return Ok();
        }

        // DELETE api/v1/<CategoriesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.RemoveAsync(id);
            return Ok();
        }

        private Category CategoryEntryToCategory(CategoryEntry categoryEntry)
        {
            Category category = new Category();
            category.Id = categoryEntry.Id;
            category.Description = categoryEntry.Description;
            return category;
        }

        
    }
}