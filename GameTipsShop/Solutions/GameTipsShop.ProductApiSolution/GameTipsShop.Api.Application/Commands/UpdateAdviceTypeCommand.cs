using GameTipsShop.Api.Application.Interfaces;
using GameTipsShop.Api.Domain.Entities;
using GameTipsShop.SharedLibrary.Responses;
using MediatR;

namespace GameTipsShop.Api.Application.Commands
{
    public record UpdateAdviceTypeCommand(AdviceType AdviceType) : IRequest<Response>;

    public class UpdateAdviceTypeHandler(IAdviceTypeRepository adviceTypeRepository) : IRequestHandler<UpdateAdviceTypeCommand, Response>
    {
        public async Task<Response> Handle(UpdateAdviceTypeCommand request, CancellationToken cancellationToken)
        {
            return await adviceTypeRepository.UpdateAsync(request.AdviceType);
        }
    }
}
