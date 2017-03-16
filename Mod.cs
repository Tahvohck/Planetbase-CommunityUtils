namespace CUtils
{
	public class Mod : ICUMod
	{
		public byte versionMajor => 1;
		public byte versionMinor => 2;
		public byte versionRevision => 0;
		public string versionAddtional => "-pre";

		public void Init() {
			Mods.sayActivated(this);
		}

		public void Update() { }
	}
}
