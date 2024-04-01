namespace School.Jenga
{
	public class StoneBlockProfile : BlockProfile
	{
		public override BlockType Type => BlockType.Stone;

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