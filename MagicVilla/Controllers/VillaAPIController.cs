using MagicVilla.Data;
using MagicVilla.Logging;
using MagicVilla.Models;
using MagicVilla.Models.Dto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla.Controllers
{
	[Route("api/VillaAPI")]
	[ApiController]
	public class VillaAPIController : ControllerBase
	{

		private readonly ILogging logger;

        public VillaAPIController(ILogging _logger)
        {
            this.logger = _logger;
        }

		[HttpGet]
		public ActionResult<IEnumerable<VillaDTO>> GetVillas()
		{
			logger.Log("Getting all villa", "");
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
                logger.Log("Get villa error with id " + id, "error");
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

			if( VillaStore.villaList.FirstOrDefault(c => c.Name.ToLower() == villaDTO.Name.ToLower()) != null )
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

		[HttpDelete("{id:int}", Name = "DeleteVilla")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteVilla(int id)
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

			VillaStore.villaList.Remove(villa);
			return NoContent();
		}

		[HttpPut("{id:int}", Name = "UpdateVilla")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateVilla(int id, [FromBody] VillaDTO villaDTO)
		{
			if(id == 0 || id == null || id != villaDTO.Id)
			{
				return BadRequest();
			}

			var villa = VillaStore.villaList.FirstOrDefault(c => c.Id == id);

			if (villa == null)
            {
                return NotFound();
            }

            villa.Name = villaDTO.Name;
			villa.sqft = villaDTO.sqft;
			villa.Occupancy = villaDTO.Occupancy;

			return NoContent();
		}

		[HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdatePartialVilla (int id, JsonPatchDocument<VillaDTO> patchDto)
		{
			if(id == 0 || patchDto == null)
			{
				return BadRequest();
			}

			var villa = VillaStore.villaList.FirstOrDefault(c => c.Id == id);

			if(villa == null)
			{
				return NotFound();
			}

			patchDto.ApplyTo(villa, ModelState);

			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			return NoContent();
		}
    }
}

