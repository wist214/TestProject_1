using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using GameTipsShop.Api.Domain.Entities;

namespace GameTipsShop.Api.Application.DTOs.Conversions
{
    public static class AdviceTypeConversion
    {
        public static AdviceType ToEntity(AdviceTypeDTO dto) => new()
        {
            Id = dto.Id,
            Name = dto.Name,
            Description = dto.Description
        };

        public static (AdviceTypeDTO?, IEnumerable<AdviceTypeDTO>?) FromEntity(AdviceType? adviceType, IEnumerable<AdviceType>? adviceTypes)
        {
            if (adviceType is not null || adviceTypes is null)
            {
                var singleAdviceType = new AdviceTypeDTO(
                    adviceType.Id,
                    adviceType.Name,
                    adviceType.Description
                );

                return (singleAdviceType, null);
            }

            if (adviceTypes?.Any() == true || adviceType is null)
            {
                var results = adviceTypes.Select(x =>
                
                    new AdviceTypeDTO(
                        x.Id,
                        x.Name,
                        x.Description
                    )
                ).ToList();

                return (null, results);
            }

            return (null, null);
        }
    }
}
