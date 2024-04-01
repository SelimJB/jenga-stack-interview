namespace School.Jenga
{
	public class GlassBlockBahavior : BlockProfile
	{
		public override BlockType Type => BlockType.Glass;

		public override void ApplyBehavior()
		{
			gameObject.SetActive(false);
		}

		public override void RemoveBehavior()
		{
			gameObject.SetActive(true);
		}
	}
}