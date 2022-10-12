namespace AspNetCore.SecurityHeaders
{
	using JetBrains.Annotations;

	/// <summary>
	///     An options class for the 'Permissions-Policy' header.
	/// </summary>
	/// <remarks>
	///     See: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Feature-Policy
	/// </remarks>
	[PublicAPI]
	public sealed class PermissionsPolicyOptions : HeaderOptionsBase
	{
		/// <summary>
		///     Initializes a new instance of the <see cref="PermissionsPolicyOptions" /> type.
		/// </summary>
		public PermissionsPolicyOptions()
		{
			this.Accelerometer = new AllowListOptions(AllowListValue.Self);
			this.AmbientLightSensor = new AllowListOptions(AllowListValue.Self);
			this.Autoplay = new AllowListOptions(AllowListValue.Self);
			this.Battery = new AllowListOptions(AllowListValue.Self);
			this.Camera = new AllowListOptions(AllowListValue.Self);
			this.DisplayCapture = new AllowListOptions(AllowListValue.Self);
			this.DocumentDomain = new AllowListOptions(AllowListValue.All);
			this.EncryptedMedia = new AllowListOptions(AllowListValue.Self);
			this.ExecutionWhileNotRendered = new AllowListOptions(AllowListValue.Self);
			this.ExecutionWhileOutOfViewport = new AllowListOptions(AllowListValue.Self);
			this.Fullscreen = new AllowListOptions(AllowListValue.Self);
			this.Gamepad = new AllowListOptions(AllowListValue.Self);
			this.Geolocation = new AllowListOptions(AllowListValue.Self);
			this.Gyroscope = new AllowListOptions(AllowListValue.Self);
			this.LayoutAnimations = new AllowListOptions(AllowListValue.Self);
			this.LegacyImageFormats = new AllowListOptions(AllowListValue.Self);
			this.Magnetometer = new AllowListOptions(AllowListValue.Self);
			this.Microphone = new AllowListOptions(AllowListValue.Self);
			this.Midi = new AllowListOptions(AllowListValue.Self);
			this.NavigationOverride = new AllowListOptions(AllowListValue.Self);
			this.OversizedImages = new AllowListOptions(AllowListValue.All);
			this.Payment = new AllowListOptions(AllowListValue.Self);
			this.PictureInPicture = new AllowListOptions(AllowListValue.All);
			this.PublicKeyCredentialsGet = new AllowListOptions(AllowListValue.Self);
			this.SpeakerSelection = new AllowListOptions(AllowListValue.Self);
			this.SyncXhr = new AllowListOptions(AllowListValue.All);
			this.UnoptimizedImages = new AllowListOptions(AllowListValue.Self);
			this.UnsizedMedia = new AllowListOptions(AllowListValue.All);
			this.Usb = new AllowListOptions(AllowListValue.Self);
			this.ScreenWakeLock = new AllowListOptions(AllowListValue.Self);
			this.WebShare = new AllowListOptions(AllowListValue.Self);
			this.XrSpatialTracking = new AllowListOptions(AllowListValue.Self);
		}

		/// <summary>
		///     Gets or set the accelerometer value.
		/// </summary>
		public AllowListOptions Accelerometer { get; set; }

		/// <summary>
		///     Gets or set the ambient-light-sensor value.
		/// </summary>
		public AllowListOptions AmbientLightSensor { get; set; }

		/// <summary>
		///     Gets or set the autoplay value.
		/// </summary>
		public AllowListOptions Autoplay { get; set; }

		/// <summary>
		///     Gets or set the battery value.
		/// </summary>
		public AllowListOptions Battery { get; set; }

		/// <summary>
		///     Gets or set the camera value.
		/// </summary>
		public AllowListOptions Camera { get; set; }

		/// <summary>
		///     Gets or set the display-capture value.
		/// </summary>
		public AllowListOptions DisplayCapture { get; set; }

		/// <summary>
		///     Gets or set the document-domain value.
		/// </summary>
		public AllowListOptions DocumentDomain { get; set; }

		/// <summary>
		///     Gets or set the encrypted-media value.
		/// </summary>
		public AllowListOptions EncryptedMedia { get; set; }

		/// <summary>
		///     Gets or set the execution-while-not-rendered value.
		/// </summary>
		public AllowListOptions ExecutionWhileNotRendered { get; set; }

		/// <summary>
		///     Gets or set the execution-while-out-of-viewport value.
		/// </summary>
		public AllowListOptions ExecutionWhileOutOfViewport { get; set; }

		/// <summary>
		///     Gets or set the fullscreen value.
		/// </summary>
		public AllowListOptions Fullscreen { get; set; }

		/// <summary>
		///     Gets or set the gamepad value.
		/// </summary>
		public AllowListOptions Gamepad { get; set; }

		/// <summary>
		///     Gets or set the geolocation value.
		/// </summary>
		public AllowListOptions Geolocation { get; set; }

		/// <summary>
		///     Gets or set the gyroscope value.
		/// </summary>
		public AllowListOptions Gyroscope { get; set; }

		/// <summary>
		///     Gets or set the layout-animations value.
		/// </summary>
		public AllowListOptions LayoutAnimations { get; set; }

		/// <summary>
		///     Gets or set the legacy-image-formats value.
		/// </summary>
		public AllowListOptions LegacyImageFormats { get; set; }

		/// <summary>
		///     Gets or set the magnetometer value.
		/// </summary>
		public AllowListOptions Magnetometer { get; set; }

		/// <summary>
		///     Gets or set the microphone value.
		/// </summary>
		public AllowListOptions Microphone { get; set; }

		/// <summary>
		///     Gets or set the midi value.
		/// </summary>
		public AllowListOptions Midi { get; set; }

		/// <summary>
		///     Gets or set the navigation-override value.
		/// </summary>
		public AllowListOptions NavigationOverride { get; set; }

		/// <summary>
		///     Gets or set the oversized-images value.
		/// </summary>
		public AllowListOptions OversizedImages { get; set; }

		/// <summary>
		///     Gets or set the payment value.
		/// </summary>
		public AllowListOptions Payment { get; set; }

		/// <summary>
		///     Gets or set the picture-in-picture value.
		/// </summary>
		public AllowListOptions PictureInPicture { get; set; }

		/// <summary>
		///     Gets or set the publickey-credentials-get value.
		/// </summary>
		public AllowListOptions PublicKeyCredentialsGet { get; set; }

		/// <summary>
		///     Gets or set the speaker-selection value.
		/// </summary>
		public AllowListOptions SpeakerSelection { get; set; }

		/// <summary>
		///     Gets or set the sync-xhr value.
		/// </summary>
		public AllowListOptions SyncXhr { get; set; }

		/// <summary>
		///     Gets or set the unoptimized-images value.
		/// </summary>
		public AllowListOptions UnoptimizedImages { get; set; }

		/// <summary>
		///     Gets or set the unsized-media value.
		/// </summary>
		public AllowListOptions UnsizedMedia { get; set; }

		/// <summary>
		///     Gets or set the usb value.
		/// </summary>
		public AllowListOptions Usb { get; set; }

		/// <summary>
		///     Gets or set the screen-wake-lock value.
		/// </summary>
		public AllowListOptions ScreenWakeLock { get; set; }

		/// <summary>
		///     Gets or set the web-share value.
		/// </summary>
		public AllowListOptions WebShare { get; set; }

		/// <summary>
		///     Gets or set the xr-spatial-tracking value.
		/// </summary>
		public AllowListOptions XrSpatialTracking { get; set; }
	}
}
