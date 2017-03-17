using Planetbase;
namespace CommunityUtils
{
	public class Mod : ICUMod, IMod
	{
		public byte versionMajor => 1;
		public byte versionMinor => 3;
		public byte versionRevision => 0;
		public string versionAddtional => "-pre";

		public void Init() {
			CUtils.sayActivated(this);
		}

		public void Update() { }
	}
}