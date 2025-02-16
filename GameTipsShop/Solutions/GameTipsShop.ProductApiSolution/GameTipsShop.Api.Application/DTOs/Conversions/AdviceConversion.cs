using GameTipsShop.Api.Domain.Entities;

namespace GameTipsShop.Api.Application.DTOs.Conversions
{
    public static class AdviceConversion
    {
        public static Advice ToEntity(AdviceDTO dto) => new()
        {
            Id = dto.Id,
            Name = dto.Name,
            AdviceType = AdviceTypeConversion.ToEntity(dto.AdviceType),
            Description = dto.Description,
            IsDeleted = false
        };

        public static (AdviceDTO?, IEnumerable<AdviceDTO>?) FromEntity(Advice? advice, IEnumerable<Advice>? advices)
        {
            if (advice is not null || advices is null)
            {
                var singleAdvice = new AdviceDTO(
                    advice.Id,
                    advice.Name,
                    advice.Description,
                    AdviceTypeConversion.FromEntity(advice.AdviceType, null).Item1
                );

                return (singleAdvice, null);
            }

            if (advices?.Any() == true || advice is null)
            {
                var results = advices.Select(x =>

                    new AdviceDTO(
                       x.Id,
                       x.Name,
                       x.Description,
                       AdviceTypeConversion.FromEntity(x.AdviceType, null).Item1
                    )
                ).ToList();

                return (null, results);
            }

            return (null, null);
        }
    }
}
