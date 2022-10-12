namespace AspNetCore.SecurityHeaders.Demo
{
	using System.Text;
	using Microsoft.Extensions.Primitives;

	public static class Program
	{
		public static void Main(string[] args)
		{
			WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
			builder.Services.AddSecurityHeaders(options =>
			{
				options.PermissionsPolicy.Accelerometer.Value = AllowListValue.Self;
				options.PermissionsPolicy.Accelerometer.WriteEnabled = true;
			});
			WebApplication app = builder.Build();
			app.UseSecurityHeaders();
			app.MapGet("/", async context =>
			{
				StringBuilder stringBuilder = new StringBuilder();

				foreach((string key, StringValues stringValues) in context.Response.Headers)
				{
					stringBuilder.AppendLine($"{key}: {stringValues.FirstOrDefault()}");
				}

				context.Response.ContentType = "text/plain";
				await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes(stringBuilder.ToString().TrimEnd()));
			});
			app.Run();
		}
	}
}
