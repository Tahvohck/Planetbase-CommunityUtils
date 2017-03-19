using Planetbase;

namespace CommunityUtils
{
	/// <summary>
	/// Extended mod interface (Community Utils Mod). Adds additional information to the mod class.
	/// Semantic versioning: http://semver.org/
	/// </summary>
	public interface ICUMod
	{
		/// <summary>
		/// API version number. Changes to this number indicate a break in backwards-compatibility.
		/// </summary>
		byte versionMajor { get; }

		/// <summary>
		/// Minor version number. Changes to this number indicate backwards-compatible changes.
		/// Must reset on <see cref="ICUMod.versionMajor"/> updates.
		/// </summary>
		byte versionMinor { get; }

		/// <summary>
		/// Bugfix number. Changes to this number are for bugfixes only.
		/// Must reset on <see cref="ICUMod.versionMajor"/> or <see cref="ICUMod.versionMinor"/> updates.
		/// </summary>
		byte versionRevision { get; }

		/// <summary>
		/// Additional information about the version. Appended directly to the version string, so any dashes or spaces must be explicit.
		/// </summary>
		string versionAddtional { get; }
	}
}
