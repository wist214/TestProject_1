using GameTipsShop.Api.Application.Interfaces;
using GameTipsShop.Api.Domain.Entities;
using GameTipsShop.SharedLibrary.Responses;
using MediatR;

namespace GameTipsShop.Api.Application.Commands
{
    public record AddAdviceTypeCommand(AdviceType AdviceType) : IRequest<Response>;

    public class AddAdviceTypeHandler(IAdviceTypeRepository adviceTypeRepository) : IRequestHandler<AddAdviceTypeCommand, Response>
    {
        public async Task<Response> Handle(AddAdviceTypeCommand request, CancellationToken cancellationToken)
        {
            return await adviceTypeRepository.CreateAsync(request.AdviceType);
        }
    }
}
