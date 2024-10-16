﻿using TesteCaixa.Api.Dtos.Payload;
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
            OrdersCalculatedDto ordersCalculated = new();            
            foreach (var order in dto.Orders) if (order.Products.Count > 0)
            {
                OrderProcessedDto orderCalculated = new() { OrderId = order.OrderId };                
                foreach (var box in boxes)
                {
                    BoxDto boxDto = new() { BoxId = box.BoxId };                    
                    var volumeBox = Volume(box.Length, box.Width, box.Height);
                    var minDimensionBox = GetMinDimension(box.Length, box.Height, box.Width);
                    foreach (var product in order.Products.ToList()) if (DimensionsIsValid(product.Dimensions!))
                    {                        
                        var maxDimensionProduct = GetMaxDimension(product.Dimensions!.Length, product.Dimensions.Height, product.Dimensions.Width);
                        if (maxDimensionProduct > minDimensionBox)
                        {
                            continue;
                        }
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

        private static bool DimensionsIsValid(DimensionsDto dimensions) 
            => dimensions is not null && dimensions.Width > 0 && dimensions.Length > 0 && dimensions.Height > 0;

        private static int GetMaxDimension(int length, int height, int width)
        {
            if ((length > height) && (length > width))
            {
                return length;
            }
            else if ((height > length) && (height > width))
            {
                return height;
            }
            return width;
        }

        private static int GetMinDimension(int length, int height, int width)
        {
            if ((length < height) && (length < width))
            {
                return length;
            }
            else if ((height < length) && (height < width))
            {
                return height;
            }
            return width;
        }
    }
}
