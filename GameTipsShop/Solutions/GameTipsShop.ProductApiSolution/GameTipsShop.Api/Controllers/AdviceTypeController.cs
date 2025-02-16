using GameTipsShop.Api.Application.DTOs;
using GameTipsShop.Api.Application.DTOs.Conversions;
using GameTipsShop.Api.Application.Interfaces;
using GameTipsShop.SharedLibrary.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GameTipsShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdviceTypeController(IAdviceType adviceTypeInterface) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdviceTypeDTO>>> GetAdviceTypes()
        {
            var adviceTypes = await adviceTypeInterface.GetAllAsync();

            if (!adviceTypes.Any())
            {
                return NotFound($"No advice types were found in database");
            }

            var (_, list) = AdviceTypeConversion.FromEntity(null, adviceTypes);

            return list!.Any() ? Ok(list) : NotFound($"No product found");
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<AdviceTypeDTO>> GetAdviceType(int id)
        {
            var adviceType = await adviceTypeInterface.FindByIdAsync(id);

            if (adviceType is null)
            {
                return NotFound($"Not found");
            }

            var (singleAdviceType, _) = AdviceTypeConversion.FromEntity(adviceType, null);

            return singleAdviceType is not null ? Ok(singleAdviceType) : NotFound($"No product found");
        }

        [HttpPost]
        public async Task<ActionResult<Response>> CreateAdviceType(AdviceTypeDTO adviceTypeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var adviceType = AdviceTypeConversion.ToEntity(adviceTypeDTO);
            var result = await adviceTypeInterface.CreateAsync(adviceType);

            return result.Flag ? Ok(result) : BadRequest(result.Message);
        }

        [HttpPut]
        public async Task<ActionResult<Response>> UpdateAdviceType(AdviceTypeDTO adviceTypeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var adviceType = AdviceTypeConversion.ToEntity(adviceTypeDTO);
            var result = await adviceTypeInterface.UpdateAsync(adviceType);

            return result.Flag ? Ok(result) : BadRequest(result.Message);
        }

        [HttpDelete]
        public async Task<ActionResult<Response>> DeleteAdviceType(AdviceTypeDTO adviceTypeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var adviceType = AdviceTypeConversion.ToEntity(adviceTypeDTO);
            var result = await adviceTypeInterface.DeleteAsync(adviceType);

            return result.Flag ? Ok(result) : BadRequest(result.Message);
        }
    }
}
