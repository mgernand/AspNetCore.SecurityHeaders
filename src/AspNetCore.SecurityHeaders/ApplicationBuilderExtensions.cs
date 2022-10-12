namespace AspNetCore.SecurityHeaders
{
	using JetBrains.Annotations;
	using Microsoft.AspNetCore.Builder;

	/// <summary>
	///     Extension methods for the <see cref="IApplicationBuilder" /> type.
	/// </summary>
	[PublicAPI]
	public static class ApplicationBuilderExtensions
	{
		/// <summary>
		///     Adds the <see cref="SecurityHeadersMiddleware" /> to the application's pipeline.
		/// </summary>
		/// <param name="app">The application builder.</param>
		/// <returns></returns>
		public static IApplicationBuilder UseSecurityHeaders(this IApplicationBuilder app)
		{
			return app.UseMiddleware<SecurityHeadersMiddleware>();
		}
	}
}
