using Planetbase;

namespace CommunityUtils
{
	/// <summary>
	/// Extended mod interface (Community Utils Mod). Adds additional information to the mod class.
	/// Semantic versioning: http://semver.org/
	/// </summary>
	public abstract class ICUMod
	{
		/// <summary>
		/// API version number. Changes to this number indicate a break in backwards-compatibility.
		/// </summary>
		public byte versionMajor => (byte)GetType().Assembly.GetName().Version.Major;

		/// <summary>
		/// Minor version number. Changes to this number indicate backwards-compatible changes.
		/// Must reset on <see cref="ICUMod.versionMajor"/> updates.
		/// </summary>
		public byte versionMinor => (byte)GetType().Assembly.GetName().Version.Minor;

		/// <summary>
		/// Bugfix number. Changes to this number are for bugfixes only.
		/// Must reset on <see cref="ICUMod.versionMajor"/> or <see cref="ICUMod.versionMinor"/> updates.
		/// </summary>
		public byte versionRevision => (byte)GetType().Assembly.GetName().Version.Build;

		/// <summary>
		/// Additional information about the version. Appended directly to the version string, so any dashes or spaces must be explicit.
		/// </summary>
		public abstract string versionAddtional { get; }
	}
}
