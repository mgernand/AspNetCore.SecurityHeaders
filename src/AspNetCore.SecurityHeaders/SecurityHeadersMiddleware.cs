namespace AspNetCore.SecurityHeaders
{
	using System.Threading.Tasks;
	using JetBrains.Annotations;
	using Microsoft.AspNetCore.Http;
	using Microsoft.Extensions.Logging;
	using Microsoft.Extensions.Options;

	[UsedImplicitly]
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

			if(this.options.ContentSecurityPolicy.WriteEnabled)
			{
				httpContext.Response.Headers.Add("Content-Security-Policy", this.options.ContentSecurityPolicy.GetValue());
			}

			if(this.options.FrameOptions.WriteEnabled)
			{
				httpContext.Response.Headers.Add("X-Frame-Options", this.options.FrameOptions.GetValue());
			}

			if(this.options.ContentTypeOptions.WriteEnabled)
			{
				httpContext.Response.Headers.Add("X-Content-Type-Options", this.options.ContentTypeOptions.GetValue());
			}

			if(this.options.XssProtection.WriteEnabled)
			{
				httpContext.Response.Headers.Add("X-XSS-Protection", this.options.XssProtection.GetValue());
			}

			if(this.options.ReferrerPolicy.WriteEnabled)
			{
				httpContext.Response.Headers.Add("Referrer-Policy", this.options.ReferrerPolicy.GetValue());
			}

			if(this.options.PermissionsPolicy.WriteEnabled)
			{
				string value = this.options.PermissionsPolicy.GetValue();
				if(!string.IsNullOrWhiteSpace(value))
				{
					httpContext.Response.Headers.Add("Permissions-Policy", value);
				}
			}

			await this.next(httpContext);
		}
	}
}
