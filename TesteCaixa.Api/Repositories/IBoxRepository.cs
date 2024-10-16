using TesteCaixa.Api.Entities;

namespace TesteCaixa.Api.Repositories
{
    public interface IBoxRepository
    {
        IEnumerable<Box> GetAll();
    }
}
