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

			//// It is a complex policy of what can execute. This can be really restrictive so please read up on it if you tighten it. I have laid out basic setting that is very permissive and will not save you from XSS attacks. https://content-security-policy.com/ or https://infosec.mozilla.org/guidelines/web_security#content-security-policy
			//httpContext.Response.Headers.Add("Content-Security-Policy", "default-src 'none'; upgrade-insecure-requests; base-uri 'self'; frame-ancestors 'self'; form-action 'self'; object-src 'none';");

			if(this.options.FrameOptions.WriteEnabled)
			{
				httpContext.Response.Headers.Add("X-Frame-Options",
					this.options.FrameOptions.GetValue());
			}

			if(this.options.ContentTypeOptions.WriteEnabled)
			{
				httpContext.Response.Headers.Add("X-Content-Type-Options",
					this.options.ContentTypeOptions.GetValue());
			}

			if(this.options.XssProtection.WriteEnabled)
			{
				httpContext.Response.Headers.Add("X-XSS-Protection",
					this.options.XssProtection.GetValue());
			}

			if(this.options.ReferrerPolicy.WriteEnabled)
			{
				httpContext.Response.Headers.Add("Referrer-Policy",
					this.options.ReferrerPolicy.GetValue());
			}

			if(this.options.PermissionsPolicy.WriteEnabled)
			{
				httpContext.Response.Headers.Add("Permissions-Policy",
					this.options.PermissionsPolicy.GetValue());
			}

			if(this.options.ContentSecurityPolicy.WriteEnabled)
			{
				httpContext.Response.Headers.Add("Content-Security-Policy",
					this.options.ContentSecurityPolicy.GetValue());
			}

			await this.next(httpContext);
		}
	}
}
