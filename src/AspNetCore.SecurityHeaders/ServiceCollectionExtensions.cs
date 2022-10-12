namespace AspNetCore.SecurityHeaders
{
	using System;
	using JetBrains.Annotations;
	using Microsoft.Extensions.DependencyInjection;

	/// <summary>
	///     Extension methods for the <see cref="IServiceCollection" /> type.
	/// </summary>
	[PublicAPI]
	public static class ServiceCollectionExtensions
	{
		/// <summary>
		///     Adds the mandatory services and options.
		/// </summary>
		/// <param name="services"></param>
		/// <param name="configureOptions"></param>
		/// <returns></returns>
		public static IServiceCollection AddSecurityHeaders(this IServiceCollection services, Action<SecurityHeadersOptions> configureOptions = null)
		{
			if(configureOptions is not null)
			{
				services.Configure(configureOptions);
			}

			return services;
		}
	}
}
