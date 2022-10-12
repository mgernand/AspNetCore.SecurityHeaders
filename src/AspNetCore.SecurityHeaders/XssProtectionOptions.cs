namespace AspNetCore.SecurityHeaders
{
	using System;
	using JetBrains.Annotations;

	/// <summary>
	///     An options class for the 'X-XSS-Protection' header.
	/// </summary>
	/// <remarks>
	///     See: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-XSS-Protection
	/// </remarks>
	[PublicAPI]
	public sealed class XssProtectionOptions : HeaderOptionsBase
	{
		/// <summary>
		///     Gets or sets the value for the header.
		/// </summary>
		public XssProtectionValue Value { get; set; } = XssProtectionValue.EnabledBlock;

		/// <summary>
		///     Gets or sets the (optional) reporting uri.
		/// </summary>
		public Uri ReportingUri { get; set; }
	}
}
