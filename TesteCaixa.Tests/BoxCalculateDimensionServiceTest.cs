using Moq;
using TesteCaixa.Api.Dtos.Payload;
using TesteCaixa.Api.Repositories;
using TesteCaixa.Api.ServiceDomain;

namespace TesteCaixa.Tests
{
    [TestClass]
    public class BoxCalculateDimensionServiceTest
    {        
        [TestMethod]
        public void TestMethod()
        {
            //Arrange
            var mockBox = new Mock<IBoxRepository>();
            mockBox.Setup(x => x.GetAll()).Returns([
                new()
                {
                    BoxId = "Caixa 1",
                    Height = 30,
                    Width = 40,
                    Length = 80
                },
                new()
                {
                    BoxId = "Caixa 2",
                    Height = 80,
                    Width = 50,
                    Length = 40
                },
                new()
                {
                    BoxId = "Caixa 3",
                    Height = 50,
                    Width = 80,
                    Length = 60
                }
            ]);
            var service = new BoxCalculateDimensionService(mockBox.Object);
            var payload = new CalcDimensionForOrdersDto
            {
                Orders =
                [
                   new OrderDto
                   {
                       OrderId = 85,
                       Products =
                       [
                          new ProductDto
                          {
                              ProductId = "Mouse",
                              Dimensions = new DimensionsDto
                              {
                                  Height = 5,
                                  Length = 7,
                                  Width = 10
                              }
                          },
                          new ProductDto
                          {
                              ProductId = "Teclado",
                              Dimensions = new DimensionsDto
                              {
                                  Height = 20,
                                  Length = 10,
                                  Width = 10
                              }
                          },
                          new ProductDto
                          {
                              ProductId = "Cadeira Gamer",
                              Dimensions = new DimensionsDto
                              {
                                  Height = 220,
                                  Length = 50,
                                  Width = 101
                              }
                          }
                       ]
                   },
                   new OrderDto 
                   {
                       OrderId = 10,
                       Products = 
                       [
                          new ProductDto 
                          {
                              ProductId = "Tenis",
                              Dimensions = new DimensionsDto
                              {
                                  Height = 10,
                                  Width = 10,
                                  Length = 7
                              }
                          },
                          new ProductDto
                          {
                              ProductId = "Mesa Gamer",
                              Dimensions = new DimensionsDto
                              {
                                  Height = 100,
                                  Width = 150,
                                  Length = 80
                              }
                          },
                          new ProductDto
                          {
                              ProductId = "Pendrive",
                              Dimensions = new DimensionsDto
                              {
                                  Height = 8,
                                  Width = 4,
                                  Length = 2
                              }
                          },
                       ]
                   }
                ]
            };
            
            //Action
            var response = service.FitCalc(payload);
            var volume = BoxCalculateDimensionService.Volume(3, 8, 9);
            var maxDim1 = BoxCalculateDimensionService.GetMaxDimension(23, 8, 89);
            var maxDim2 = BoxCalculateDimensionService.GetMaxDimension(25, 8, 9);

            //Assert
            Assert.AreEqual(expected: 216, actual: volume);
            Assert.AreEqual(expected: 89, actual: maxDim1);
            Assert.AreEqual(expected: 25, actual: maxDim2);
            Assert.IsNotNull(response);
            Assert.AreEqual(expected: 2, actual: response.Orders.Count);
            Assert.IsNotNull(response.Orders.FirstOrDefault(x => x.OrderId.Equals(85))?.Boxes);
            Assert.AreNotEqual("Tenis", actual: response.Orders.FirstOrDefault(x => x.OrderId.Equals(85))?.Boxes.FirstOrDefault()?.Products.FirstOrDefault(x => x.ProductId == "Tenis")?.ProductId);
            Assert.AreEqual(expected: "Teclado", actual: response.Orders.FirstOrDefault(x => x.OrderId.Equals(85))?.Boxes.FirstOrDefault()?.Products.FirstOrDefault(x => x.ProductId == "Teclado")?.ProductId);
            Assert.AreEqual(expected: 2, actual: response.Orders.FirstOrDefault(x => x.OrderId.Equals(10))?.Boxes.SelectMany(x => x.Products).Count());
        }
    }
}