namespace AspNetCore.SecurityHeaders
{
	using JetBrains.Annotations;

	/// <summary>
	///     An options class for the 'X-Content-Type-Options' header.
	/// </summary>
	/// <remarks>
	///     See: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-Content-Type-Options
	/// </remarks>
	[PublicAPI]
	public sealed class ContentTypeOptionsOptions : HeaderOptionsBase
	{
	}
}
