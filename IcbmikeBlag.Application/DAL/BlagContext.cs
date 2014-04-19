using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IcbmikeBlag.Application.Entities;

namespace IcbmikeBlag.Application.DAL
{
    public class BlagContext : DbContext
    {
        public BlagContext() : base("blagDB")
        {
         
        }


        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
