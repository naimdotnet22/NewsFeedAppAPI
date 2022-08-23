﻿using Microsoft.EntityFrameworkCore;
using NewsFeedAPI.Models;

namespace NewsFeedAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }


        public DbSet<News> News { get; set; }
    }
}
