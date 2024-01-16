using System;
using MagicVilla.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla.Data
{
	public class ApplicationDbContext: DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{}

		public DbSet<Villa> Villas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id = 1,
                    Name = "Royal Villa",
                    Details = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                    ImageUrl = "https://images.unsplash.com/photo-1580587771525-78b9dba3b914?q=80&w=3474&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    Occupancy = 5,
                    Rate = 200,
                    sqft = 550,
                    Amenity = "",
                    CreatedAt = DateTime.Now
                },
                new Villa()
                {
                    Id = 2,
                    Name = "Premium Pool Villa",
                    Details = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                    ImageUrl = "https://images.unsplash.com/photo-1580587771525-78b9dba3b914?q=80&w=3474&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    Occupancy = 5,
                    Rate = 300,
                    sqft = 550,
                    Amenity = "",
                    CreatedAt = DateTime.Now
                },
                new Villa()
                {
                    Id = 3,
                    Name = "Luxury Pool Villa",
                    Details = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                    ImageUrl = "https://images.unsplash.com/photo-1580587771525-78b9dba3b914?q=80&w=3474&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    Occupancy = 4,
                    Rate = 400,
                    sqft = 750,
                    Amenity = "",
                    CreatedAt = DateTime.Now
                },
                new Villa()
                {
                    Id = 4,
                    Name = "Diamond Villa",
                    Details = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                    ImageUrl = "https://images.unsplash.com/photo-1580587771525-78b9dba3b914?q=80&w=3474&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    Occupancy = 4,
                    Rate = 550,
                    sqft = 900,
                    Amenity = "",
                    CreatedAt = DateTime.Now
                },
                new Villa()
                {
                    Id = 5,
                    Name = "Diamond Pool Villa",
                    Details = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                    ImageUrl = "https://images.unsplash.com/photo-1580587771525-78b9dba3b914?q=80&w=3474&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    Occupancy = 4,
                    Rate = 600,
                    sqft = 1100,
                    Amenity = "",
                    CreatedAt = DateTime.Now
                }
            );
        }

    }
}

