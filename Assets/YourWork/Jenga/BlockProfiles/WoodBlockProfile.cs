namespace School.Jenga
{
	public class WoodBlockProfile : BlockProfile
	{
		public override BlockType Type => BlockType.Wood;

		public override void ApplyBehavior()
		{
			rigidbody.isKinematic = false;
		}

		public override void RemoveBehavior()
		{
			rigidbody.isKinematic = true;
		}
	}
}