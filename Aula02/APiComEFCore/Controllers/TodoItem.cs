using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APiComEFCore.Data;
using APiComEFCore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APiComEFCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoItemController : ControllerBase
    {

        private readonly TodoContext _context;

        public TodoItemController(TodoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public  ActionResult<List<TodoItemModel>> ItemTodo() {
            // return Created();
            return _context.TodoItems.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemModel?>> ItemTodoByID(long id) {
            // return Created();
            // return await _context.TodoItems.Where(i => i.TodoItemID.Equals(id)).SingleOrDefaultAsync();
            return await _context.TodoItems.Where(i => i.TodoItemID.Equals(id)).FirstAsync();
        }

        [HttpPost]
        public async Task<ActionResult<TodoItemModel>> ItemTodo(TodoItemModel todoItem) {
            _context.Add(todoItem);
            await _context.SaveChangesAsync();

            // return Created();
            return CreatedAtAction("ItemTodo", todoItem);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TodoItemModel>> ItemTodo(long id, TodoItemModel todoItem) {
            if (id != todoItem.TodoItemID) {
                return BadRequest();
            }

            _context.Entry(todoItem).State = EntityState.Modified;
            
            await _context.SaveChangesAsync();

            // return Created();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoItemModel>> ItemTodoDelete(long id) {
            var todoItem =await ItemTodoByID(id);
            _context.Remove<TodoItemModel>(todoItem.Value!);
            await _context.SaveChangesAsync();

            // return Created();
            return Ok();
        }
    }

}