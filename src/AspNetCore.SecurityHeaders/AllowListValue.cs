namespace AspNetCore.SecurityHeaders
{
	using JetBrains.Annotations;

	/// <summary>
	///     An enum providing the value for an allow-list item.
	/// </summary>
	/// <remarks>
	///     See: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Feature-Policy
	///     See: https://developer.chrome.com/docs/privacy-sandbox/permissions-policy/
	/// </remarks>
	[PublicAPI]
	public enum AllowListValue
	{
		/// <summary>
		///     The feature will be allowed in this document, and all nested browsing contexts
		///     (iframes) regardless of their origin.
		/// </summary>
		All,

		/// <summary>
		///     The feature will be allowed in this document, and in all nested browsing contexts
		///     (iframes) in the same origin. The feature is not allowed in cross-origin documents
		///     in nested browsing contexts.
		/// </summary>
		Self,

		/// <summary>
		///     The feature will be allowed in this iframe, as long as the document loaded into it
		///     comes from the same origin as the URL in the iframe's src attribute.
		/// </summary>
		Src,

		/// <summary>
		///     The feature is disabled in top-level and nested browsing contexts.
		/// </summary>
		None
	}
}
