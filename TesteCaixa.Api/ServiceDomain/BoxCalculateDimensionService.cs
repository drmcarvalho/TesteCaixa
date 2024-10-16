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
            foreach (var order in dto.Orders)
            {
                if (order.Products.Count == 0)
                {
                    continue;
                }
                var orderCalculated = new OrderProcessedDto { OrderId = order.OrderId };
                foreach (var box in boxes)
                {
                    var boxDto = new BoxDto { BoxId = box.BoxId };
                    var maxDimensionBox = GetMaxDimension(box.Height, box.Length, box.Width);
                    var volumeBox = Volume(box.Length, box.Width, box.Height);
                    foreach (var product in order.Products.ToList())
                    {
                        if (orderCalculated.Boxes.Exists(x => x.Products.Exists(p => p.ProductId == product.ProductId)))
                        {
                            continue;
                        }
                        if (product.Dimensions is not null && product.Dimensions.Width > 0 && product.Dimensions.Length > 0 && product.Dimensions.Height > 0)
                        {
                            var volumeProduct = Volume(product.Dimensions.Length, product.Dimensions.Width, product.Dimensions.Height);
                            if (volumeProduct > volumeBox)
                            {
                                continue;
                            }
                            var maxDimensionProduct = GetMaxDimension(product.Dimensions.Width, product.Dimensions.Length, product.Dimensions.Height);
                            if (maxDimensionProduct > maxDimensionBox)
                            {
                                continue;
                            }
                            boxDto.Products.Add(new ProductFitDto { ProductId = product.ProductId });
                            order.Products.Remove(product);
                        }
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

        public static int GetMaxDimension(int length, int height, int width)
        {          
            int maxTwo(int a, int b)
            {
                return (a > b) ? a : b;
            }

            int maxThree(int a, int b, int c)
            {
                return maxTwo(maxTwo(a, b), c);
            }

            return maxThree(length, height, width);            
        }
    }
}
