namespace TesteCaixa.Api.Dtos.Response
{
    public class OrdersCalculatedDto
    {
        public List<OrderProcessedDto> Orders { get; set; } = [];
    }

    public class OrderProcessedDto
    {
        public int OrderId { get; set; }
        public List<BoxDto> Boxes { get; set; } = [];

    }

    public class BoxDto
    {
        public string BoxId { get; set; } = string.Empty;
        public List<ProductFitDto> Products { get; set; } = [];
    }

    public class ProductFitDto
    {
        public string? ProductId { get; set; } = null!;
    }
}
