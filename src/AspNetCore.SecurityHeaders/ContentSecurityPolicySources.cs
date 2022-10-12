namespace AspNetCore.SecurityHeaders
{
	using System;
	using JetBrains.Annotations;

	/// <summary>
	///     An options class for a CSP source value.
	/// </summary>
	/// <remarks>
	///     See: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/Sources#sources
	/// </remarks>
	[PublicAPI]
	public static class ContentSecurityPolicySources
	{
		/// <summary>
		///     Refers to the origin from which the protected document is being served, including
		///     the same URL scheme and port number.
		/// </summary>
		public const string Self = "'self'";

		/// <summary>
		///     Allows the use of <c>eval()</c> and other unsafe methods for creating code from strings.
		/// </summary>
		public const string UnsafeEval = "'unsafe-eval'";

		/// <summary>
		///     Allows the loading and execution of WebAssembly modules without the need to also allow
		///     unsafe JavaScript execution via 'unsafe-eval'.
		/// </summary>
		public const string WasmUnsafeEval = "'wasm-unsafe-eval'";

		/// <summary>
		///     Allows enabling specific inline event handlers. If you only need to allow inline event
		///     handlers and not inline &lt;script&gt; elements or javascript: URLs, this is a safer method
		///     than using the 'unsafe-inline' expression.
		/// </summary>
		public const string UnsafeHashes = "'unsafe-hashes'";

		/// <summary>
		///     Allows the use of inline resources, such as inline &lt;script&gt; elements, javascript:
		///     URLs, inline event handlers, and inline &lt;style&gt; elements.
		/// </summary>
		public const string UnsafeInline = "'unsafe-inline'";

		/// <summary>
		///     Refers to the empty set; that is, no URLs match.
		/// </summary>
		public const string None = "'none'";

		/// <summary>
		///     The 'strict-dynamic' source expression specifies that the trust explicitly given to a script
		///     present in the markup, by accompanying it with a nonce or a hash, shall be propagated to all
		///     the scripts loaded by that root script. At the same time, any allow-list or source expressions
		///     such as 'self' or 'unsafe-inline' are ignored.
		/// </summary>
		public const string StrictDynamic = "'strict-dynamic'";

		/// <summary>
		///     Requires a sample of the violating code to be included in the violation report.
		/// </summary>
		public const string ReportSample = "'report-sample'";

		/// <summary>
		///     An allow-list for specific inline scripts using a cryptographic nonce (number used once). The
		///     server must generate a unique nonce value each time it transmits a policy. It is critical to
		///     provide an unguessable nonce, as bypassing a resource's policy is otherwise trivial. Specifying
		///     nonce makes a modern browser ignore 'unsafe-inline' which could still be set for older browsers
		///     without nonce support.
		/// </summary>
		/// <param name="base64Value"></param>
		/// <returns></returns>
		public static string Nonce(string base64Value)
		{
			if(string.IsNullOrWhiteSpace(base64Value))
			{
				throw new ArgumentNullException(nameof(base64Value));
			}

			return $"'nonce-{base64Value}'";
		}

		/// <summary>
		///     A sha256, sha384 or sha512 hash of scripts or styles. This value consists of the algorithm
		///     used to create the hash followed by a hyphen and the base64-encoded hash of the script or
		///     style. When generating the hash, exclude &lt;script&gt; or &lt;style&gt; tags and note that capitalization
		///     and whitespace matter, including leading or trailing whitespace.
		/// </summary>
		/// <param name="hashAlgorithm"></param>
		/// <param name="base64Value"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static string HashAlgorithm(string hashAlgorithm, string base64Value)
		{
			if(string.IsNullOrWhiteSpace(hashAlgorithm))
			{
				throw new ArgumentNullException(nameof(hashAlgorithm));
			}

			if(hashAlgorithm is not ("sha256" or "sha384" or "sha512"))
			{
				throw new ArgumentException("The hash algorithm must be 'sha256', 'sha384' or 'sha512'.", nameof(hashAlgorithm));
			}

			if(string.IsNullOrWhiteSpace(base64Value))
			{
				throw new ArgumentNullException(nameof(base64Value));
			}

			return $"'{hashAlgorithm}-{base64Value}'";
		}
	}
}
