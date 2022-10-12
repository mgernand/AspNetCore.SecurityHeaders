namespace AspNetCore.SecurityHeaders
{
	using JetBrains.Annotations;

	/// <summary>
	///     An options class for the 'Referrer-Policy' header.
	/// </summary>
	/// <remarks>
	///     See: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Referrer-Policy
	/// </remarks>
	[PublicAPI]
	public sealed class ReferrerPolicyOptions : HeaderOptionsBase
	{
		/// <summary>
		///     Gets or sets the value for the header.
		/// </summary>
		public ReferrerPolicyValue Value { get; set; } = ReferrerPolicyValue.StrictOriginWhenCrossOrigin;
	}
}
