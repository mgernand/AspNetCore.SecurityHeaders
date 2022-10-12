namespace AspNetCore.SecurityHeaders
{
	using JetBrains.Annotations;

	/// <summary>
	///     The available values for the 'X-Frame-Options' header.
	/// </summary>
	/// <remarks>
	///     See: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-Frame-Options
	/// </remarks>
	[PublicAPI]
	public enum FrameOptionsValue
	{
		/// <summary>
		///     The page cannot be displayed in a frame, regardless of the site attempting to do so.
		/// </summary>
		Deny,

		/// <summary>
		///     The page can only be displayed if all ancestor frames are same origin to the page itself.
		/// </summary>
		SameOrigin
	}
}
