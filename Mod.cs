namespace CommunityUtils
{
	public class Mod : ICUMod
	{
		public byte versionMajor => 1;
		public byte versionMinor => 1;
		public byte versionRevision => 0;
		public string versionAddtional => "";

		public void Init() {
			CUtils.sayActivated(this);
		}

		public void Update() { }
	}
}
