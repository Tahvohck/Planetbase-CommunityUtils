using Planetbase;

#pragma warning disable CS1591

namespace CommunityUtils
{
	public class Mod : ICUMod, IMod
	{
		public override string versionAddtional => "-pre";

		public void Init() {
			CUtils.sayActivated(this);
		}

		public void Update() { }
	}
}