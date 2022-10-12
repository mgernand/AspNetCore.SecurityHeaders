namespace AspNetCore.SecurityHeaders
{
	using JetBrains.Annotations;

	/// <summary>
	///     An options base class for the header options.
	/// </summary>
	[PublicAPI]
	public abstract class HeaderOptionsBase
	{
		/// <summary>
		///     Flag, indicating that the header should be written.
		/// </summary>
		public bool WriteEnabled { get; set; } = true;
	}
}
