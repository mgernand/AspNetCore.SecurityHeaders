namespace AspNetCore.SecurityHeaders.Demo
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


			WebApplication app = builder.Build();

			app.UseSecurityHeaders();
			app.MapGet("/", () => "Hello World!");
			app.Run();
		}
	}
}
