using TesteCaixa.Api.Dtos.Payload;
using TesteCaixa.Api.Dtos.Response;
using TesteCaixa.Api.Repositories;

namespace TesteCaixa.Api.ServiceDomain
{
    public class BoxCalculateDimensionService(IBoxRepository boxRepository): IBoxCalculateDimensionService
    {
        private readonly IBoxRepository _boxRepository = boxRepository;

        public static int Volume(int length, int width, int height)
            => length * width * height;
        
        public OrdersCalculatedDto FitCalc(CalcDimensionForOrdersDto dto)
        {
            var boxes = _boxRepository.GetAll();
            var ordersCalculated = new OrdersCalculatedDto();            
            foreach (var order in dto.Orders) if (order.Products.Count > 0)
            {
                var orderCalculated = new OrderProcessedDto { OrderId = order.OrderId };
                foreach (var box in boxes)
                {
                    var boxDto = new BoxDto { BoxId = box.BoxId };                    
                    var volumeBox = Volume(box.Length, box.Width, box.Height);
                    foreach (var product in order.Products.ToList()) if (DimensionsIsValid(product.Dimensions!))
                    {                        
                        var volumeProduct = Volume(product.Dimensions!.Length, product.Dimensions.Width, product.Dimensions.Height);
                        if (volumeProduct > volumeBox)
                        {
                            continue;
                        }
                        boxDto.Products.Add(new ProductFitDto { ProductId = product.ProductId });
                        order.Products.Remove(product);                                
                    }
                    if (boxDto.Products.Count > 0)
                    {
                        orderCalculated.Boxes.Add(boxDto);
                    }
                }
                ordersCalculated.Orders.Add(orderCalculated);
            }
            return ordersCalculated;            
        }

        private bool DimensionsIsValid(DimensionsDto dimensions) 
            => dimensions is not null && dimensions.Width > 0 && dimensions.Length > 0 && dimensions.Height > 0;
    }
}
