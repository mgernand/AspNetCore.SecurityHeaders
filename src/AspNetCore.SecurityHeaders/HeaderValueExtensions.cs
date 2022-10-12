namespace AspNetCore.SecurityHeaders
{
	using System;
	using System.Linq;
	using System.Text;

	internal static class HeaderValueExtensions
	{
		public static string GetValue(this FrameOptionsOptions options)
		{
			string value = options.Value switch
			{
				FrameOptionsValue.Deny => "DENY",
				FrameOptionsValue.SameOrigin => "SAMEORIGIN",
				_ => throw new ArgumentOutOfRangeException()
			};

			return value;
		}

		public static string GetValue(this ContentTypeOptionsOptions options)
		{
			return "nosniff";
		}

		public static string GetValue(this XssProtectionOptions options)
		{
			string value = options.Value switch
			{
				XssProtectionValue.Disabled => "0",
				XssProtectionValue.Enabled => "1",
				XssProtectionValue.EnabledBlock => "1; mode=block",
				XssProtectionValue.EnabledReport => $"1; report={options.ReportingUri}",
				_ => throw new ArgumentOutOfRangeException()
			};

			return value;
		}

		public static string GetValue(this ReferrerPolicyOptions options)
		{
			string value = options.Value switch
			{
				ReferrerPolicyValue.NoReferrer => "no-referrer",
				ReferrerPolicyValue.NoReferrerWhenDowngrade => "no-referrer-when-downgrade",
				ReferrerPolicyValue.Origin => "origin",
				ReferrerPolicyValue.OriginWhenCrossOrigin => "origin-when-cross-origin",
				ReferrerPolicyValue.SameOrigin => "same-origin",
				ReferrerPolicyValue.StrictOrigin => "strict-origin",
				ReferrerPolicyValue.StrictOriginWhenCrossOrigin => "strict-origin-when-cross-origin",
				ReferrerPolicyValue.UnsafeUrl => "unsafe-url",
				_ => throw new ArgumentOutOfRangeException()
			};

			return value;
		}

		public static string GetValue(this PermissionsPolicyOptions options)
		{
			StringBuilder builder = new StringBuilder();

			builder.Append(options.Accelerometer.GetAllowList("accelerometer"));
			builder.Append(options.AmbientLightSensor.GetAllowList("ambient-light-sensor"));
			builder.Append(options.Autoplay.GetAllowList("autoplay"));
			builder.Append(options.Battery.GetAllowList("battery"));
			builder.Append(options.Camera.GetAllowList("camera"));
			builder.Append(options.DisplayCapture.GetAllowList("display-capture"));
			builder.Append(options.DocumentDomain.GetAllowList("document-domain"));
			builder.Append(options.EncryptedMedia.GetAllowList("encrypted-media"));
			builder.Append(options.ExecutionWhileNotRendered.GetAllowList("execution-while-not-rendered"));
			builder.Append(options.ExecutionWhileOutOfViewport.GetAllowList("execution-while-out-of-viewport"));
			builder.Append(options.Fullscreen.GetAllowList("fullscreen"));
			builder.Append(options.Gamepad.GetAllowList("gamepad"));
			builder.Append(options.Geolocation.GetAllowList("geolocation"));
			builder.Append(options.Gyroscope.GetAllowList("gyroscope"));
			builder.Append(options.LayoutAnimations.GetAllowList("layout-animations"));
			builder.Append(options.LegacyImageFormats.GetAllowList("legacy-image-formats"));
			builder.Append(options.Magnetometer.GetAllowList("magnetometer"));
			builder.Append(options.Microphone.GetAllowList("microphone"));
			builder.Append(options.Midi.GetAllowList("midi"));
			builder.Append(options.NavigationOverride.GetAllowList("navigation-override"));
			builder.Append(options.OversizedImages.GetAllowList("oversized-images"));
			builder.Append(options.Payment.GetAllowList("payment"));
			builder.Append(options.PictureInPicture.GetAllowList("picture-in-picture"));
			builder.Append(options.PublicKeyCredentialsGet.GetAllowList("publickey-credentials-get"));
			builder.Append(options.SpeakerSelection.GetAllowList("speaker-selection"));
			builder.Append(options.SyncXhr.GetAllowList("sync-xhr"));
			builder.Append(options.UnoptimizedImages.GetAllowList("unoptimized-images"));
			builder.Append(options.UnsizedMedia.GetAllowList("unsized-media"));
			builder.Append(options.Usb.GetAllowList("usb"));
			builder.Append(options.ScreenWakeLock.GetAllowList("screen-wake-lock"));
			builder.Append(options.WebShare.GetAllowList("web-share"));
			builder.Append(options.XrSpatialTracking.GetAllowList("xr-spatial-tracking"));

			return builder.ToString().TrimEnd().TrimEnd(',');
		}

		public static string GetValue(this ContentSecurityPolicyOptions options)
		{
			StringBuilder builder = new StringBuilder();

			builder.Append(options.DefaultSrc.GetFetchDirective("default-src"));

			return builder.ToString().TrimEnd();
		}

		private static string GetAllowList(this AllowListOptions options, string directive)
		{
			string GetOrigins()
			{
				string origins = string.Empty;

				if(options.Origins.Any())
				{
					origins = options.Origins.Select(x => @$"""{x}""").Aggregate((s1, s2) => string.Concat(s1, " ", s2));
					origins = $" {origins}";
				}

				return origins;
			}

			string allowList = string.Empty;

			if(options.WriteEnabled)
			{
				allowList = options.Value switch
				{
					AllowListValue.All => "*",
					AllowListValue.Self => $"(self{GetOrigins()})",
					AllowListValue.Src => $"(src{GetOrigins()})",
					AllowListValue.None => "()",
					_ => throw new ArgumentOutOfRangeException()
				};

				allowList = $"{directive}={allowList}, ";
			}

			return allowList;
		}

		private static string GetFetchDirective(this FetchDirectiveOptions options, string directive)
		{
			string fetchDirective = string.Empty;

			if(options.WriteEnabled && options.Sources.Any())
			{
				fetchDirective = options.Sources.Aggregate((s1, s2) => string.Concat(s1, " ", s2));
				fetchDirective = $"{directive} {fetchDirective.TrimEnd()}; ";
			}

			return fetchDirective;
		}
	}
}
