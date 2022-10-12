namespace AspNetCore.SecurityHeaders
{
	using JetBrains.Annotations;

	/// <summary>
	///     An options class for the header configurations.
	/// </summary>
	[PublicAPI]
	public sealed class SecurityHeadersOptions
	{
		/// <summary>
		///     Initializes a new instance of the <see cref="SecurityHeadersOptions" /> type.
		/// </summary>
		public SecurityHeadersOptions()
		{
			this.FrameOptions = new FrameOptionsOptions();
			this.ContentTypeOptions = new ContentTypeOptionsOptions();
			this.XssProtection = new XssProtectionOptions();
			this.ReferrerPolicy = new ReferrerPolicyOptions();
			this.PermissionsPolicy = new PermissionsPolicyOptions();
			this.ContentSecurityPolicy = new ContentSecurityPolicyOptions();
		}

		/// <summary>
		///     Gets or sets the 'X-Frame-Options' header options.
		/// </summary>
		public FrameOptionsOptions FrameOptions { get; set; }

		/// <summary>
		///     Gets or sets the 'X-Content-Type-Options' header options.
		/// </summary>
		public ContentTypeOptionsOptions ContentTypeOptions { get; set; }

		/// <summary>
		///     Gets or sets the 'X-XSS-Protection' header options.
		/// </summary>
		public XssProtectionOptions XssProtection { get; set; }

		/// <summary>
		///     Gets or sets the 'Referrer-Policy' header options.
		/// </summary>
		public ReferrerPolicyOptions ReferrerPolicy { get; set; }

		/// <summary>
		///     Gets or sets the 'Permissions-Policy' header options.
		/// </summary>
		public PermissionsPolicyOptions PermissionsPolicy { get; set; }

		/// <summary>
		///     Gets or sets the 'Content-Security-Policy' header options.
		/// </summary>
		public ContentSecurityPolicyOptions ContentSecurityPolicy { get; set; }
	}
}
