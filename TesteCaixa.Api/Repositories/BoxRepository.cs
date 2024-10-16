using TesteCaixa.Api.Entities;

namespace TesteCaixa.Api.Repositories
{
    public class BoxRepository : IBoxRepository
    {
        public IEnumerable<Box> GetAll()
            => [
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
            ];
    }
}
