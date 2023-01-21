namespace SampleProject.Application.DTO
{
    public class ProductPaginationResponse
    {
        public ProductPaginationResponse()
        {
            Result = new List<ProductResponse>();
        }

        public List<ProductResponse> Result { get; set; }
        public int TotalRecord { get; set; }
        public int Page { get; set; }
    }
}
