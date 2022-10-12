namespace AspNetCore.SecurityHeaders.Demo
{
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
			app.MapGet("/", () => "Hello World!");
			app.Run();
		}
	}
}
