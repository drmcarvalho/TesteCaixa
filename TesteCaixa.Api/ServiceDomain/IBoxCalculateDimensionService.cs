using TesteCaixa.Api.Dtos.Payload;
using TesteCaixa.Api.Dtos.Response;

namespace TesteCaixa.Api.ServiceDomain
{
    public interface IBoxCalculateDimensionService
    {
        OrdersCalculatedDto FitCalc(CalcDimensionForOrdersDto dto);
    }
}
