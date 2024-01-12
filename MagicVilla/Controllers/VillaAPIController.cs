using MagicVilla.Data;
using MagicVilla.Models;
using MagicVilla.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla.Controllers
{
	[Route("api/VillaAPI")]
	[ApiController]
	public class VillaAPIController : ControllerBase
	{
		[HttpGet]
		public ActionResult<IEnumerable<VillaDTO>> GetVillas()
		{
			return Ok( VillaStore.villaList );
		}

		[HttpGet("{id:int}", Name = "GetVilla")]
		[ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDTO> GetVillas(int id)
        {
			if(id == 0)
			{
				return BadRequest();
			}
			var villa = VillaStore.villaList.FirstOrDefault(c => c.Id == id);
			if(villa == null)
			{
				return NotFound();
			}
            return Ok( villa );
        }

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<VillaDTO> CreateVilla([FromBody] VillaDTO villaDTO)
		{
			if(villaDTO == null)
			{
				return BadRequest(villaDTO);
			}

			if(VillaStore.villaList.FirstOrDefault(c => c.Name.ToLower() == villaDTO.Name.ToLower()) != null )
			{
				ModelState.AddModelError("CustomError", "Villa name already exist");
				return BadRequest(ModelState);
			}

			if(villaDTO.Id > 0)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
			villaDTO.Id = VillaStore.villaList.OrderByDescending(c => c.Id).FirstOrDefault().Id + 1;

			VillaStore.villaList.Add(villaDTO);

			return CreatedAtRoute("GetVilla", new { id = villaDTO.Id }, villaDTO);
		}
    }
}

