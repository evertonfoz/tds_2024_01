using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APiComEFCore.Model;
using Microsoft.EntityFrameworkCore;

namespace APiComEFCore.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options) {

        }

        public DbSet<TodoItemModel> TodoItems { get; set; }// = null!;
    }
}