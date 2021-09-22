using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopAPI.Data;
using ShopAPI.Models;

namespace ShopAPI.Controllers
{
    // https://localhost:5001/categories
    // http://localhost:5000/
    [Route("categories")]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Category>>> Get(
            [FromServices] DataContext context
        )
        {
            var categories = await context.Categories.AsNoTracking().ToListAsync();
            return Ok(categories);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Category>> GetById(
            int id,
            [FromServices] DataContext context)
        {
            var category = await context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return Ok(category);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Category>> Post(
            [FromBody] Category model,
            [FromServices] DataContext context)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.Categories.Add(model);
                await context.SaveChangesAsync();

                return Ok(model);
            }
            catch
            {
                return BadRequest(new { message = "Wasn't possible to create the category" });
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Category>> Put(
            int id,
            [FromBody] Category model,
            [FromServices] DataContext context)
        {
            // Verifica se o ID informado é o mesmo do modelo
            if (model.Id != id)
                return NotFound(new { message = "Category not founded!" });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.Entry<Category>(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();

                return Ok(model);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "This register was already changed!" });
            }
            catch
            {
                return BadRequest(new { message = "Wasn't possible to create the category" });
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Category>> Delete(
            int id,
            [FromServices] DataContext context)
        {
            var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
                return NotFound(new { message = "The category wasn't founded" });

            try
            {
                context.Categories.Remove(category);
                await context.SaveChangesAsync();
                return Ok(category);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Wasn't possible to delete the category" });
            }
        }
    }
}