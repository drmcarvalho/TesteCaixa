namespace TesteCaixa.Api.Dtos.Payload
{
    public class CalcDimensionForOrdersDto
    {
        public List<OrderDto> Orders { get; set; } = [];
    }

    public class OrderDto
    {
        public int OrderId { get; set; }
        public List<ProductDto> Products { get; set; } = [];
    }

    public class ProductDto
    {
        public string ProductId { get; set; } = string.Empty;        
        public DimensionsDto? Dimensions { get; set; } = null;

    }

    public class DimensionsDto
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
    }
}
