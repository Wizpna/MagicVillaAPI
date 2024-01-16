using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicVilla.Models
{
	public class Villa
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string Name { get; set; }

		public string Details { get; set; }

		public double Rate { get; set; }

		public int sqft { get; set; }

		public int Occupancy { get; set; }

		public string ImageUrl { get; set; }

		public string Amenity { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime UpdatedDate { get; set; }

	}
}

