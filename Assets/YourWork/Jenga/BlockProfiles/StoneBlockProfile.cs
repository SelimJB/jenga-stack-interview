namespace School.Jenga
{
	public class StoneBlockProfile : BlockProfile
	{
		public override BlockType Type => BlockType.Stone;

		public override void ApplyBehavior()
		{
			blockRigidBody.isKinematic = false;
		}

		public override void RemoveBehavior()
		{
			blockRigidBody.isKinematic = true;
		}
	}
}