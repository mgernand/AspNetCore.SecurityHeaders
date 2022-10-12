namespace AspNetCore.SecurityHeaders
{
	using JetBrains.Annotations;

	/// <summary>
	///     The available optional parameter for the 'X-XSS-Protection' header.
	/// </summary>
	/// <remarks>
	///     See: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-XSS-Protection
	/// </remarks>
	[PublicAPI]
	public enum XssProtectionValue
	{
		/// <summary>
		///     Disables XSS filtering.
		/// </summary>
		Disabled,

		/// <summary>
		///     Enables XSS filtering (usually default in browsers). If a cross-site scripting
		///     attack is detected, the browser will sanitize the page (remove the unsafe parts).
		/// </summary>
		Enabled,

		/// <summary>
		///     Enables XSS filtering. Rather than sanitizing the page, the browser will prevent
		///     rendering of the page if an attack is detected.
		/// </summary>
		EnabledBlock,

		/// <summary>
		///     (Chromium only)
		///     Enables XSS filtering. If a cross-site scripting attack is detected, the browser
		///     will sanitize the page and report the violation.
		/// </summary>
		EnabledReport
	}
}
