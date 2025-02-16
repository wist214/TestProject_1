using System.ComponentModel.DataAnnotations;

namespace GameTipsShop.Api.Application.DTOs
{
    public record AdviceTypeDTO(
        int Id,
        [Required] string Name,
        string Description);
}
