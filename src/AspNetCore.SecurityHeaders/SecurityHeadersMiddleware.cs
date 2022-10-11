namespace AspNetCore.SecurityHeaders
{
	using System.Threading.Tasks;
	using Microsoft.AspNetCore.Http;
	using Microsoft.Extensions.Logging;
	using Microsoft.Extensions.Options;

	internal sealed class SecurityHeadersMiddleware
	{
		private readonly ILogger<SecurityHeadersMiddleware> logger;
		private readonly RequestDelegate next;
		private readonly SecurityHeadersOptions options;

		public SecurityHeadersMiddleware(
			RequestDelegate next,
			ILogger<SecurityHeadersMiddleware> logger,
			IOptions<SecurityHeadersOptions> options)
		{
			this.next = next;
			this.logger = logger;
			this.options = options.Value;
		}

		public async Task Invoke(HttpContext httpContext)
		{
			// Add configured security headers.

			await this.next(httpContext);
		}
	}
}
