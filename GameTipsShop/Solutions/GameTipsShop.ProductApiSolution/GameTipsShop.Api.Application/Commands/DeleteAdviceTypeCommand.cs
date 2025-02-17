using GameTipsShop.Api.Application.Interfaces;
using GameTipsShop.Api.Domain.Entities;
using GameTipsShop.SharedLibrary.Responses;
using MediatR;

namespace GameTipsShop.Api.Application.Commands
{
    public record DeleteAdviceTypeCommand(AdviceType AdviceType) : IRequest<Response>;

    public class DeleteAdviceTypeHandler(IAdviceTypeRepository adviceTypeRepository) : IRequestHandler<DeleteAdviceTypeCommand, Response>
    {
        public async Task<Response> Handle(DeleteAdviceTypeCommand request, CancellationToken cancellationToken)
        {
            return await adviceTypeRepository.DeleteAsync(request.AdviceType);
        }
    }
}
