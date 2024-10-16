using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TesteCaixa.Api.Auth
{
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        private const string ApiKeyName = "X-API-KEY";
        private const string ApiKey = "en7RdTeVJctQzkrADmhTvDJsFcB5MkBGuK3HutbpgzKffNFuKiyQ3CGK5qauwvAETsUTSyWes4T9KRuVnm4JmS1wafJB01VxL7mEiuwzm975CsnxcZvlPQ9AluP1GJ4l";

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyName, out var apiKeyFromRequest))
            {
                context.Result = new ContentResult { StatusCode = 401, Content = "ApiKey invalida" };
                return;
            }
            if (!ApiKey.Equals(apiKeyFromRequest))
            {
                context.Result = new ContentResult { StatusCode = 403, Content = "Não autorizado" };
                return;
            }
            await next();            
        }
    }
}
