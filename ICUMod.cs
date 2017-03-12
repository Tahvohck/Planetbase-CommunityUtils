using Planetbase;

namespace CommunityUtils
{
	/// <summary>
	/// Extended mod interface (Community Utils Mod). Adds additional information to the mod class.
	/// </summary>
	public interface ICUMod : IMod
	{
		/// <summary>
		/// Major version number. Changes to this number indicate API changes and break backwards-compatibility.
		/// </summary>
		byte versionMajor { get; }

		/// <summary>
		/// Minor version number. Changes to this number indicate additional functionality and should remain backwards-compatible.
		/// </summary>
		byte versionMinor { get; }

		/// <summary>
		/// Revision number. Changes to this number indicate under-the-hood code changes.
		/// Should reset on <see cref="ICUMod.versionMajor"/> or <see cref="ICUMod.versionMinor"/> updates.
		/// </summary>
		byte versionRevision { get; }

		/// <summary>
		/// Additional information about the version. Appended directly to the version string, so any dashes or spaces must be explicit.
		/// </summary>
		string versionAddtional { get; }
	}
}
