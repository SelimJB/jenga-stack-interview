namespace School.Jenga
{
	public class WoodBlockProfile : BlockProfile
	{
		public override BlockType Type => BlockType.Wood;

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