using System;
using MagicVilla.Models.Dto;

namespace MagicVilla.Data
{
	public class VillaStore
	{
        public static List<VillaDTO> villaList = new List<VillaDTO>
        {

                new VillaDTO
                {
                    Name = "Pool View",
                    Id = 1
                },
                new VillaDTO
                {
                    Name = "Beach View",
                    Id = 2
                }
        };
	}
}

