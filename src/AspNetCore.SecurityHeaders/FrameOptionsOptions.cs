namespace AspNetCore.SecurityHeaders
{
	using JetBrains.Annotations;

	/// <summary>
	///     An options class for the 'X-Frame-Options' header.
	/// </summary>
	/// <remarks>
	///     See: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-Frame-Options
	/// </remarks>
	[PublicAPI]
	public sealed class FrameOptionsOptions : HeaderOptionsBase
	{
		/// <summary>
		///     Gets or sets the header value.
		/// </summary>
		public FrameOptionsValue Value { get; set; } = FrameOptionsValue.Deny;
	}
}
