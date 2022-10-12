namespace AspNetCore.SecurityHeaders
{
	using System;
	using JetBrains.Annotations;

	/// <summary>
	///     An options class for the 'Content-Security-Policy' header.
	/// </summary>
	/// <remarks>
	///     See: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy
	/// </remarks>
	[PublicAPI]
	public sealed class ContentSecurityPolicyOptions : HeaderOptionsBase
	{
		/// <summary>
		///     Initializes a new instance of the <see cref="ContentSecurityPolicyOptions" /> type.
		/// </summary>
		public ContentSecurityPolicyOptions()
		{
			this.DefaultSrc = new FetchDirectiveOptions
			{
				WriteEnabled = true,
				Sources =
				{
					ContentSecurityPolicySources.None
				}
			};

			this.ChildSrc = new FetchDirectiveOptions();
			this.ConnectSrc = new FetchDirectiveOptions();
			this.FontSrc = new FetchDirectiveOptions();
			this.FrameSrc = new FetchDirectiveOptions();
			this.ImgSrc = new FetchDirectiveOptions();
			this.ManifestSrc = new FetchDirectiveOptions();
			this.MediaSrc = new FetchDirectiveOptions();
			this.ObjectSrc = new FetchDirectiveOptions();
			this.PrefetchSrc = new FetchDirectiveOptions();
			this.ScriptSrc = new FetchDirectiveOptions();
			this.ScriptSrcElem = new FetchDirectiveOptions();
			this.ScriptSrcAttr = new FetchDirectiveOptions();
			this.StyleSrc = new FetchDirectiveOptions();
			this.StyleSrcElem = new FetchDirectiveOptions();
			this.StyleSrcAttr = new FetchDirectiveOptions();
			this.WorkerSrc = new FetchDirectiveOptions();
			this.BaseUri = new FetchDirectiveOptions();
			this.Sandbox = new FetchDirectiveOptions();
			this.FormAction = new FetchDirectiveOptions();
			this.FrameAncestors = new FetchDirectiveOptions();
			this.NavigateTo = new FetchDirectiveOptions();
			this.ReportUri = new FetchDirectiveOptions();
			this.ReportTo = new FetchDirectiveOptions();
			this.RequireTrustedTypesFor = new FetchDirectiveOptions();
			this.TrustedTypes = new FetchDirectiveOptions();
			this.UpgradeInsecureRequests = new FetchDirectiveOptions();
		}

		/// <summary>
		///     Gets the 'default-src' directive.
		/// </summary>
		/// <remarks>
		///     See: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/default-src
		/// </remarks>
		public FetchDirectiveOptions DefaultSrc { get; set; }

		/// <summary>
		///     Gets the 'child-src' directive.
		/// </summary>
		/// <remarks>
		///     See: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/child-src
		/// </remarks>
		public FetchDirectiveOptions ChildSrc { get; set; }

		/// <summary>
		///     Gets the 'connect-src' directive.
		/// </summary>
		/// <remarks>
		///     See: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/connect-src
		/// </remarks>
		public FetchDirectiveOptions ConnectSrc { get; set; }

		/// <summary>
		///     Gets the 'font-src' directive.
		/// </summary>
		/// <remarks>
		///     See: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/font-src
		/// </remarks>
		public FetchDirectiveOptions FontSrc { get; set; }

		/// <summary>
		///     Gets the 'frame-src' directive.
		/// </summary>
		/// <remarks>
		///     See: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/frame-src
		/// </remarks>
		public FetchDirectiveOptions FrameSrc { get; set; }

		/// <summary>
		///     Gets the 'img-src' directive.
		/// </summary>
		/// <remarks>
		///     See: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/img-src
		/// </remarks>
		public FetchDirectiveOptions ImgSrc { get; set; }

		/// <summary>
		///     Gets the 'manifest-src' directive.
		/// </summary>
		/// <remarks>
		///     See: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/manifest-src
		/// </remarks>
		public FetchDirectiveOptions ManifestSrc { get; set; }

		/// <summary>
		///     Gets the 'media-src' directive.
		/// </summary>
		/// <remarks>
		///     See: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/media-src
		/// </remarks>
		public FetchDirectiveOptions MediaSrc { get; set; }

		/// <summary>
		///     Gets the 'object-src' directive.
		/// </summary>
		/// <remarks>
		///     See: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/object-src
		/// </remarks>
		public FetchDirectiveOptions ObjectSrc { get; set; }

		/// <summary>
		///     Gets the 'prefetch-src' directive.
		/// </summary>
		/// <remarks>
		///     See: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/prefetch-src
		/// </remarks>
		public FetchDirectiveOptions PrefetchSrc { get; set; }

		/// <summary>
		///     Gets the 'script-src' directive.
		/// </summary>
		/// <remarks>
		///     See: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/script-src
		/// </remarks>
		public FetchDirectiveOptions ScriptSrc { get; set; }

		/// <summary>
		///     Gets the 'script-src-elem' directive.
		/// </summary>
		/// <remarks>
		///     See: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/script-src-elem
		/// </remarks>
		public FetchDirectiveOptions ScriptSrcElem { get; set; }

		/// <summary>
		///     Gets the 'script-src-attr' directive.
		/// </summary>
		/// <remarks>
		///     See: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/script-src-attr
		/// </remarks>
		public FetchDirectiveOptions ScriptSrcAttr { get; set; }

		/// <summary>
		///     Gets the 'style-src' directive.
		/// </summary>
		/// <remarks>
		///     See: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/style-src
		/// </remarks>
		public FetchDirectiveOptions StyleSrc { get; set; }

		/// <summary>
		///     Gets the 'style-src-elem' directive.
		/// </summary>
		/// <remarks>
		///     See: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/style-src-elem
		/// </remarks>
		public FetchDirectiveOptions StyleSrcElem { get; set; }

		/// <summary>
		///     Gets the 'style-src-attr' directive.
		/// </summary>
		/// <remarks>
		///     See: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/style-src-attr
		/// </remarks>
		public FetchDirectiveOptions StyleSrcAttr { get; set; }

		/// <summary>
		///     Gets the 'worker-src' directive.
		/// </summary>
		/// <remarks>
		///     See: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/worker-src
		/// </remarks>
		public FetchDirectiveOptions WorkerSrc { get; set; }

		/// <summary>
		///     Gets the 'base-uri' directive.
		/// </summary>
		/// <remarks>
		///     See: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/base-uri
		/// </remarks>
		public FetchDirectiveOptions BaseUri { get; set; }

		/// <summary>
		///     Gets the 'sandbox' directive.
		/// </summary>
		/// <remarks>
		///     See: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/sandbox
		/// </remarks>
		public FetchDirectiveOptions Sandbox { get; set; }

		/// <summary>
		///     Gets the 'form-action' directive.
		/// </summary>
		/// <remarks>
		///     See: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/form-action
		/// </remarks>
		public FetchDirectiveOptions FormAction { get; set; }

		/// <summary>
		///     Gets the 'frame-ancestors' directive.
		/// </summary>
		/// <remarks>
		///     See: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/frame-ancestors
		/// </remarks>
		public FetchDirectiveOptions FrameAncestors { get; set; }

		/// <summary>
		///     Gets the 'navigate-to' directive.
		/// </summary>
		/// <remarks>
		///     See: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/navigate-to
		/// </remarks>
		public FetchDirectiveOptions NavigateTo { get; set; }

		/// <summary>
		///     Gets the 'report-uri' directive.
		/// </summary>
		/// <remarks>
		///     See: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/report-uri
		/// </remarks>
		[Obsolete("Deprecated: This feature is no longer recommended. The 'report-to' directive is intended to replace the deprecated 'report-uri' directive.")]
		public FetchDirectiveOptions ReportUri { get; set; }

		/// <summary>
		///     Gets the 'report-to' directive.
		/// </summary>
		/// <remarks>
		///     See: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/report-to
		/// </remarks>
		public FetchDirectiveOptions ReportTo { get; set; }

		/// <summary>
		///     Gets the 'require-trusted-types-for' directive.
		/// </summary>
		/// <remarks>
		///     See: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/require-trusted-types-for
		/// </remarks>
		public FetchDirectiveOptions RequireTrustedTypesFor { get; set; }

		/// <summary>
		///     Gets the 'trusted-types' directive.
		/// </summary>
		/// <remarks>
		///     See: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/trusted-types
		/// </remarks>
		public FetchDirectiveOptions TrustedTypes { get; set; }

		/// <summary>
		///     Gets the 'upgrade-insecure-requests' directive.
		/// </summary>
		/// <remarks>
		///     See: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/upgrade-insecure-requests
		/// </remarks>
		public FetchDirectiveOptions UpgradeInsecureRequests { get; set; }
	}
}
