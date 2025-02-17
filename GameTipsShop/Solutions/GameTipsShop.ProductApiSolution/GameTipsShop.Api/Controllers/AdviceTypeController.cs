using GameTipsShop.Api.Application.Commands;
using GameTipsShop.Api.Application.DTOs;
using GameTipsShop.Api.Application.DTOs.Conversions;
using GameTipsShop.Api.Application.Queries;
using GameTipsShop.SharedLibrary.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameTipsShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdviceTypeController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdviceTypeDTO>>> GetAdviceTypes()
        { 
            var adviceTypes = await mediator.Send(new GetAllAdviceTypesQuery());

            if (!adviceTypes.Any())
            {
                return NotFound($"No advice types were found in database");
            }

            return adviceTypes!.Any() ? Ok(adviceTypes) : NotFound($"No product found");
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<AdviceTypeDTO>> GetAdviceType(int id)
        {
            var adviceType = await mediator.Send(new GetAdviceTypeQuery(id));

            if (adviceType is null)
            {
                return NotFound($"Not found");
            }

            return adviceType is not null ? Ok(adviceType) : NotFound($"No product found");
        }

        [HttpPost]
        public async Task<ActionResult<Response>> CreateAdviceType(AdviceTypeDTO adviceTypeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var adviceType = AdviceTypeConversion.ToEntity(adviceTypeDTO);

            var result = await mediator.Send(new AddAdviceTypeCommand(adviceType));
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
            var result = await mediator.Send(new UpdateAdviceTypeCommand(adviceType));

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
            var result = await mediator.Send(new DeleteAdviceTypeCommand(adviceType));

            return result.Flag ? Ok(result) : BadRequest(result.Message);
        }
    }
}
