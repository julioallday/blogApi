using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogApi.models;
using Microsoft.EntityFrameworkCore;

namespace blogApi.Data
{
    public class PostContext : DbContext
    {
        public PostContext (DbContextOptions<PostContext> opts)
        : base(opts)
        {

        }
        public DbSet<Post> Posts { get; set; }
    }
}