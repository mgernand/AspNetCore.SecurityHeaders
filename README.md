# AspNetCore.SecurityHeaders

A middleware to configure and add security headers to HTTP responses.

## Usage

To enable the middleware in your ASP.NET Core app, just call the ```UseSecurityHeaders``` extenion
method on the ```WebApplication``` instance. This minimal configuration will write the headers with
default values.

```C#
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();
app.UseSecurityHeaders();
app.MapGet("/", () => "Hello World!");
app.Run();
```

The default configuration produces the following response headers.

```plain
Content-Security-Policy: default-src 'none';
X-Frame-Options: DENY
X-Content-Type-Options: nosniff
X-XSS-Protection: 1; mode=block
Referrer-Policy: strict-origin-when-cross-origin
```

You can configure every header using the ```AddSecurityHeaders``` extension method 
on the ```IServiceCollection```. If you f.e. don't want to write the ```X-XSS-Protection```
header, just disble it using the options like below.

```C#
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddSecurityHeaders(options =>
{
	options.XssProtection.WriteEnabled = false;
});
WebApplication app = builder.Build();
app.UseSecurityHeaders();
app.MapGet("/", () => "Hello World!");
app.Run();
```

All header are ```WriteEnabled = true``` by default. The ```Permissions-Policy``` will
not be written, because the options of this header are defines as opt-in. If no directive
is activated, the header will not be written. Youn can enable directives using the options
like below.

```C#
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
```

This will write the ```Permissions-Policy``` in addition to the default header.

```plain
Permissions-Policy: accelerometer=(self)
```
