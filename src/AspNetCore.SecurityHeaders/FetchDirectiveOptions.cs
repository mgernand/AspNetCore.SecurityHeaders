namespace AspNetCore.SecurityHeaders
{
	using System.Collections.Generic;
	using JetBrains.Annotations;

	/// <summary>
	///     An options class for a fetch directive of the header value.
	/// </summary>
	[PublicAPI]
	public sealed class FetchDirectiveOptions
	{
		/// <summary>
		///     Initializes a new instance of the <see cref="FetchDirectiveOptions" /> type.
		/// </summary>
		public FetchDirectiveOptions()
		{
			this.Sources = new List<string>();
		}

		/// <summary>
		///     Flag, indicating that the value should be written.
		/// </summary>
		public bool WriteEnabled { get; set; }

		/// <summary>
		///     Gets the source values.
		/// </summary>
		public IList<string> Sources { get; }
	}
}
