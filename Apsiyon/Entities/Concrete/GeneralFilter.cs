namespace Apsiyon.Entities
{
    public class GeneralFilter : IPagingFilter
    {
        public int Page { get; set; }
        public string PropertyName { get; set; }
        public bool Asc { get; set; } = true;
        public int EntityId { get; set; }
    }
}
