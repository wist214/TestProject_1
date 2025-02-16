namespace GameTipsShop.Api.Domain.Entities
{
    public class Advice
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required AdviceType AdviceType { get; set; }
        public bool IsDeleted { get; set; }
    }
}
