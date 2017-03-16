using Planetbase;

namespace CUtils
{
	/// <summary>
	/// Extended mod interface (Community Utils Mod). Adds additional information to the mod class.
	/// </summary>
	public interface ICUMod : IMod
	{
		/// <summary>
		/// Major version number. Changes to this number indicate large-scale code changes, often full rewrites, and break backwards-compatibility.
		/// </summary>
		byte versionMajor { get; }

		/// <summary>
		/// Minor version number. Changes to this number indicate API changes and break backwards-compatibility.
		/// </summary>
		byte versionMinor { get; }

		/// <summary>
		/// Revision number. Changes to this number indicate changes that do not break backwards-compatibility.
		/// Should reset on <see cref="ICUMod.versionMajor"/> or <see cref="ICUMod.versionMinor"/> updates.
		/// </summary>
		byte versionRevision { get; }

		/// <summary>
		/// Additional information about the version. Appended directly to the version string, so any dashes or spaces must be explicit.
		/// </summary>
		string versionAddtional { get; }
	}
}
