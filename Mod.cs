namespace CUtils
{
	public class Mod : ICUMod
	{
		public byte versionMajor => 2;
		public byte versionMinor => 0;
		public byte versionRevision => 0;
		public string versionAddtional => "-pre";

		public void Init() {
			Mods.sayActivated(this);
		}

		public void Update() { }
	}
}
