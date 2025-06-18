using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Web;

namespace SafeVaultSecureApp.Middleware
{
    public class InputSanitizerMiddleware
    {
        private readonly RequestDelegate _next;

        public InputSanitizerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Iterar sobre los parámetros de la query string
            foreach (var queryParam in context.Request.Query)
            {
                string sanitizedValue = Sanitize(queryParam.Value);

                // Guardar los valores sanitizados en context.Items
                context.Items[$"sanitized_query_{queryParam.Key}"] = sanitizedValue;
            }

            await _next(context);
        }

        private string Sanitize(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            // Sanitizar para prevenir XSS o inyección de HTML/JS
            return HttpUtility.HtmlEncode(input);
        }
    }
}
