namespace GameTipsShop.Api.Domain.Entities
{
    public class AdviceType
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
