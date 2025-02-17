using GameTipsShop.Api.Application.DTOs;
using GameTipsShop.Api.Application.DTOs.Conversions;
using GameTipsShop.Api.Application.Interfaces;
using MediatR;

namespace GameTipsShop.Api.Application.Queries
{
    public record GetAdviceTypeQuery(int Id) : IRequest<AdviceTypeDTO>;

    public class GetAdviceTypeQueryHandler(IAdviceTypeRepository repository) : IRequestHandler<GetAdviceTypeQuery, AdviceTypeDTO>
    {
        public async Task<AdviceTypeDTO> Handle(GetAdviceTypeQuery request, CancellationToken cancellationToken)
        {
            var adviceType = await repository.FindByIdAsync(request.Id);
            return AdviceTypeConversion.FromEntity(adviceType, null).Item1;
        }
    }
}
