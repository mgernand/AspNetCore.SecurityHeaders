namespace AspNetCore.SecurityHeaders
{
	using System.Collections.Generic;
	using JetBrains.Annotations;

	/// <summary>
	///     An options class for an allow-list of the header value.
	/// </summary>
	/// <remarks>
	///     See: https://developer.chrome.com/docs/privacy-sandbox/permissions-policy/
	/// </remarks>
	[PublicAPI]
	public sealed class AllowListOptions
	{
		/// <summary>
		///     Initializes a new instance of the <see cref="AllowListOptions" /> type.
		/// </summary>
		public AllowListOptions(AllowListValue defaultValue)
		{
			this.Value = defaultValue;
			this.Origins = new List<string>();
		}

		/// <summary>
		///     Flag, indicating that the value should be written.
		/// </summary>
		public bool WriteEnabled { get; set; }

		/// <summary>
		///     Gets or sets the allow-list value.
		/// </summary>
		public AllowListValue Value { get; set; }

		/// <summary>
		///     Gets the allowed origins.
		/// </summary>
		public IList<string> Origins { get; }
	}
}
