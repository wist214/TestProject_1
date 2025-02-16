using System.ComponentModel.DataAnnotations;

namespace GameTipsShop.Api.Application.DTOs
{
    public record AdviceDTO(
        int Id,
        [Required] string Name,
        string Description,
        [Required] AdviceTypeDTO AdviceType);
}
