using GameTipsShop.Api.Application.DTOs;
using GameTipsShop.Api.Application.DTOs.Conversions;
using GameTipsShop.Api.Application.Interfaces;
using MediatR;

namespace GameTipsShop.Api.Application.Queries
{
    public record GetAllAdviceTypesQuery() : IRequest<IEnumerable<AdviceTypeDTO>>;

    public class GetAllAdviceTypesHandler(IAdviceTypeRepository repository) : IRequestHandler<GetAllAdviceTypesQuery, IEnumerable<AdviceTypeDTO>>
    {
        public async Task<IEnumerable<AdviceTypeDTO>?> Handle(GetAllAdviceTypesQuery request, CancellationToken cancellationToken)
        {
            var adviceTypes = await repository.GetAllAsync();
            return AdviceTypeConversion.FromEntity(null, adviceTypes).Item2;
        }
    }
}
