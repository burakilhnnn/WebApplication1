namespace Application.Features.Categories.Queries
{
    public class GetCategoryByIdQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
    }
}
