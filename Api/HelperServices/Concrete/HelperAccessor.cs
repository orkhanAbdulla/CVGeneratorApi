using CVGeneratorApp.Api.HelperServices.Abstractions;

namespace CVGeneratorApp.Api.HelperServices.Concrete
{
    public class HelperAccessor:IHelperAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HelperAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string BaseUrl => $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}{_httpContextAccessor.HttpContext.Request.PathBase}";
    }
    
}
