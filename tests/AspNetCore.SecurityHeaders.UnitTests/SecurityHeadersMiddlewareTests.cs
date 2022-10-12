namespace AspNetCore.SecurityHeaders.UnitTests
{
	using System;
	using System.Collections.Generic;
	using System.Net;
	using System.Net.Http;
	using System.Threading.Tasks;
	using FluentAssertions;
	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.AspNetCore.TestHost;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.Hosting;
	using Microsoft.Extensions.Logging;
	using Microsoft.Extensions.Logging.Mock;
	using Moq;
	using NUnit.Framework;

	[TestFixture]
	public class SecurityHeadersMiddlewareTests
	{
		public Mock<ILogger> MockLogger { get; set; }

		public HttpClient CreateHttpClient(Action<SecurityHeadersOptions> configureOptions = null, string environment = null)
		{
			this.MockLogger = new Mock<ILogger>();

			IWebHostBuilder builder = new WebHostBuilder()
				.UseEnvironment(environment ?? Environments.Development)
				.ConfigureLogging(logging =>
				{
					logging.AddConsole();
					logging.AddMock(this.MockLogger);
				})
				.ConfigureServices(services =>
				{
					services.AddLogging();
					services.AddSecurityHeaders(configureOptions);
					services
						.AddControllers()
						.AddControllersAsServices();
				})
				.Configure(app =>
				{
					app.UseSecurityHeaders();
					app.UseRouting();
					app.UseEndpoints(builder =>
					{
						builder.MapControllers();
						builder.MapGet("/", () => "Hello World!");
					});
				});

			TestServer server = new TestServer(builder);

			HttpClient httpClient = server.CreateClient();

			return httpClient;
		}

		public static IEnumerable<object[]> TestCasesContentSecurityPolicy()
		{
			yield return new object[] { new ContentSecurityPolicyOptions(), "default-src 'none';", true };
			yield return new object[] { new ContentSecurityPolicyOptions(), null, false };
		}

		public static IEnumerable<object[]> TestCasesPermissionsPolicy()
		{
			yield return new object[] { new PermissionsPolicyOptions(), "", true };
			yield return new object[] { new PermissionsPolicyOptions(), null, false };

			yield return new object[]
			{
				new PermissionsPolicyOptions
				{
					Accelerometer =
					{
						WriteEnabled = true
					}
				},
				"accelerometer=(self)",
				true
			};
			yield return new object[]
			{
				new PermissionsPolicyOptions
				{
					Accelerometer =
					{
						Value = AllowListValue.All,
						WriteEnabled = true
					}
				},
				"accelerometer=*",
				true
			};
			yield return new object[]
			{
				new PermissionsPolicyOptions
				{
					Accelerometer =
					{
						Value = AllowListValue.None,
						WriteEnabled = true
					}
				},
				"accelerometer=()",
				true
			};
			yield return new object[]
			{
				new PermissionsPolicyOptions
				{
					Accelerometer =
					{
						Value = AllowListValue.Self,
						WriteEnabled = true,
						Origins =
						{
							"https://localhost",
							"https://my.nicedomain.xyz"
						}
					}
				},
				@"accelerometer=(self ""https://localhost"" ""https://my.nicedomain.xyz"")",
				true
			};

			yield return new object[]
			{
				new PermissionsPolicyOptions
				{
					Accelerometer =
					{
						Value = AllowListValue.Self,
						WriteEnabled = true
					},
					Camera =
					{
						Value = AllowListValue.None,
						WriteEnabled = true
					},
					Payment =
					{
						Value = AllowListValue.All,
						WriteEnabled = true
					}
				},
				"accelerometer=(self), camera=(), payment=*",
				true
			};
		}

		[Test]
		[TestCaseSource(nameof(TestCasesContentSecurityPolicy))]
		public async Task ShouldWriteContentSecurityPolicyHeader(ContentSecurityPolicyOptions contentSecurityPolicyOptions, string expectedValue, bool writeEnabled)
		{
			void ConfigureOptions(SecurityHeadersOptions options)
			{
				options.ContentSecurityPolicy = contentSecurityPolicyOptions;
				options.ContentSecurityPolicy.WriteEnabled = writeEnabled;
			}

			using(HttpClient httpClient = this.CreateHttpClient(ConfigureOptions))
			{
				HttpResponseMessage response = await httpClient.GetAsync("");

				response.Should().HaveStatusCode(HttpStatusCode.OK);

				if(writeEnabled)
				{
					response.Headers.Should().ContainKey("Content-Security-Policy");
					response.Headers.GetValues("Content-Security-Policy").Should().Contain(expectedValue);
				}
				else
				{
					response.Headers.Should().NotContainKey("Content-Security-Policy");
				}
			}
		}

		[Test]
		[TestCase(true)]
		[TestCase(false)]
		public async Task ShouldWriteContentTypeOptionsHeader(bool writeEnabled)
		{
			void ConfigureOptions(SecurityHeadersOptions options)
			{
				options.ContentTypeOptions.WriteEnabled = writeEnabled;
			}

			using(HttpClient httpClient = this.CreateHttpClient(ConfigureOptions))
			{
				HttpResponseMessage response = await httpClient.GetAsync("");

				response.Should().HaveStatusCode(HttpStatusCode.OK);

				if(writeEnabled)
				{
					response.Headers.Should().ContainKey("X-Content-Type-Options");
					response.Headers.GetValues("X-Content-Type-Options").Should().Contain("nosniff");
				}
				else
				{
					response.Headers.Should().NotContainKey("X-Content-Type-Options");
				}
			}
		}

		[Test]
		[TestCase(null, "DENY", true)]
		[TestCase(null, null, false)]
		[TestCase(FrameOptionsValue.Deny, "DENY", true)]
		[TestCase(FrameOptionsValue.Deny, null, false)]
		[TestCase(FrameOptionsValue.SameOrigin, "SAMEORIGIN", true)]
		[TestCase(FrameOptionsValue.SameOrigin, null, false)]
		public async Task ShouldWriteFrameOptionsHeader(FrameOptionsValue? value, string expectedValue, bool writeEnabled)
		{
			void ConfigureOptions(SecurityHeadersOptions options)
			{
				if(value.HasValue)
				{
					options.FrameOptions.Value = value.Value;
				}

				options.FrameOptions.WriteEnabled = writeEnabled;
			}

			using(HttpClient httpClient = this.CreateHttpClient(ConfigureOptions))
			{
				HttpResponseMessage response = await httpClient.GetAsync("");

				response.Should().HaveStatusCode(HttpStatusCode.OK);

				if(writeEnabled)
				{
					response.Headers.Should().ContainKey("X-Frame-Options");
					response.Headers.GetValues("X-Frame-Options").Should().Contain(expectedValue);
				}
				else
				{
					response.Headers.Should().NotContainKey("X-Frame-Options");
				}
			}
		}

		[Test]
		[TestCaseSource(nameof(TestCasesPermissionsPolicy))]
		public async Task ShouldWritePermissionsPolicyHeader(PermissionsPolicyOptions permissionsPolicyOptions, string expectedValue, bool writeEnabled)
		{
			void ConfigureOptions(SecurityHeadersOptions options)
			{
				options.PermissionsPolicy = permissionsPolicyOptions;
				options.PermissionsPolicy.WriteEnabled = writeEnabled;
			}

			using(HttpClient httpClient = this.CreateHttpClient(ConfigureOptions))
			{
				HttpResponseMessage response = await httpClient.GetAsync("");

				response.Should().HaveStatusCode(HttpStatusCode.OK);

				if(writeEnabled)
				{
					response.Headers.Should().ContainKey("Permissions-Policy");
					response.Headers.GetValues("Permissions-Policy").Should().Contain(expectedValue);
				}
				else
				{
					response.Headers.Should().NotContainKey("Permissions-Policy");
				}
			}
		}

		[Test]
		[TestCase(null, "strict-origin-when-cross-origin", true)]
		[TestCase(null, null, false)]
		[TestCase(ReferrerPolicyValue.NoReferrer, "no-referrer", true)]
		[TestCase(ReferrerPolicyValue.NoReferrer, null, false)]
		[TestCase(ReferrerPolicyValue.NoReferrerWhenDowngrade, "no-referrer-when-downgrade", true)]
		[TestCase(ReferrerPolicyValue.NoReferrerWhenDowngrade, null, false)]
		[TestCase(ReferrerPolicyValue.Origin, "origin", true)]
		[TestCase(ReferrerPolicyValue.Origin, null, false)]
		[TestCase(ReferrerPolicyValue.OriginWhenCrossOrigin, "origin-when-cross-origin", true)]
		[TestCase(ReferrerPolicyValue.OriginWhenCrossOrigin, null, false)]
		[TestCase(ReferrerPolicyValue.SameOrigin, "same-origin", true)]
		[TestCase(ReferrerPolicyValue.SameOrigin, null, false)]
		[TestCase(ReferrerPolicyValue.StrictOrigin, "strict-origin", true)]
		[TestCase(ReferrerPolicyValue.StrictOrigin, null, false)]
		[TestCase(ReferrerPolicyValue.StrictOriginWhenCrossOrigin, "strict-origin-when-cross-origin", true)]
		[TestCase(ReferrerPolicyValue.StrictOriginWhenCrossOrigin, null, false)]
		[TestCase(ReferrerPolicyValue.UnsafeUrl, "unsafe-url", true)]
		[TestCase(ReferrerPolicyValue.UnsafeUrl, null, false)]
		public async Task ShouldWriteReferrerPolicyHeader(ReferrerPolicyValue? value, string expectedValue, bool writeEnabled)
		{
			void ConfigureOptions(SecurityHeadersOptions options)
			{
				if(value.HasValue)
				{
					options.ReferrerPolicy.Value = value.Value;
				}

				options.ReferrerPolicy.WriteEnabled = writeEnabled;
			}

			using(HttpClient httpClient = this.CreateHttpClient(ConfigureOptions))
			{
				HttpResponseMessage response = await httpClient.GetAsync("");

				response.Should().HaveStatusCode(HttpStatusCode.OK);

				if(writeEnabled)
				{
					response.Headers.Should().ContainKey("Referrer-Policy");
					response.Headers.GetValues("Referrer-Policy").Should().Contain(expectedValue);
				}
				else
				{
					response.Headers.Should().NotContainKey("Referrer-Policy");
				}
			}
		}

		[Test]
		[TestCase(null, "1; mode=block", true)]
		[TestCase(null, null, false)]
		[TestCase(XssProtectionValue.Disabled, "0", true)]
		[TestCase(XssProtectionValue.Disabled, null, false)]
		[TestCase(XssProtectionValue.Enabled, "1", true)]
		[TestCase(XssProtectionValue.Enabled, null, false)]
		[TestCase(XssProtectionValue.EnabledBlock, "1; mode=block", true)]
		[TestCase(XssProtectionValue.EnabledBlock, null, false)]
		[TestCase(XssProtectionValue.EnabledReport, "1; report=https://localhost:5001/report", true)]
		[TestCase(XssProtectionValue.EnabledReport, null, false)]
		public async Task ShouldWriteXssProtectionHeader(XssProtectionValue? value, string expectedValue, bool writeEnabled)
		{
			void ConfigureOptions(SecurityHeadersOptions options)
			{
				if(value.HasValue)
				{
					options.XssProtection.Value = value.Value;
				}

				options.XssProtection.WriteEnabled = writeEnabled;
				options.XssProtection.ReportingUri = new Uri("https://localhost:5001/report");
			}

			using(HttpClient httpClient = this.CreateHttpClient(ConfigureOptions))
			{
				HttpResponseMessage response = await httpClient.GetAsync("");

				response.Should().HaveStatusCode(HttpStatusCode.OK);

				if(writeEnabled)
				{
					response.Headers.Should().ContainKey("X-XSS-Protection");
					response.Headers.GetValues("X-XSS-Protection").Should().Contain(expectedValue);
				}
				else
				{
					response.Headers.Should().NotContainKey("X-XSS-Protection");
				}
			}
		}
	}
}
