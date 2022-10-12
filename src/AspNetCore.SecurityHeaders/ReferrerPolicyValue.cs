namespace AspNetCore.SecurityHeaders
{
	/// <summary>
	///     The available optional parameter for the 'Referrer-Policy' header.
	/// </summary>
	/// <remarks>
	///     See: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Referrer-Policy
	/// </remarks>
	public enum ReferrerPolicyValue
	{
		/// <summary>
		///     The Referer header will be omitted: sent requests do not include any referrer information.
		/// </summary>
		NoReferrer,

		/// <summary>
		///     Send the origin, path, and querystring in Referer when the protocol security level stays
		///     the same or improves. Don't send the Referer header for requests to less secure destinations.
		/// </summary>
		NoReferrerWhenDowngrade,

		/// <summary>
		///     Send only the origin in the Referer header.
		/// </summary>
		Origin,

		/// <summary>
		///     When performing a same-origin request to the same protocol level, send the origin, path,
		///     and query string. Send only the origin for cross origin requests and requests to less secure
		///     destinations.
		/// </summary>
		OriginWhenCrossOrigin,

		/// <summary>
		///     Send the origin, path, and query string for same-origin requests. Don't send the Referer header
		///     for cross-origin requests.
		/// </summary>
		SameOrigin,

		/// <summary>
		///     Send only the origin when the protocol security level stays the same. Don't send the Referer header
		///     to less secure destinations.
		/// </summary>
		StrictOrigin,

		/// <summary>
		///     Send the origin, path, and querystring when performing a same-origin request. For cross-origin requests
		///     send the origin (only) when the protocol security level stays same. Don't send the Referer header to less
		///     secure destinations.
		/// </summary>
		StrictOriginWhenCrossOrigin,

		/// <summary>
		///     Send the origin, path, and query string when performing any request, regardless of security.
		/// </summary>
		/// <remarks>
		///     Warning:
		///     This policy will leak potentially-private information from HTTPS resource URLs to insecure origins.
		///     Carefully consider the impact of this setting.
		/// </remarks>
		UnsafeUrl,
	}
}
