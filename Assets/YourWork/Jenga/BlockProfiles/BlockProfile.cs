using UnityEngine;

namespace School.Jenga
{
	/* Use composition over inheritance to allow for more flexibility in the future
		Use abstract class over scriptable objects because it seems there will 
		be a lot of Component & Scene based logic in the future
	*/
	public abstract class BlockProfile : MonoBehaviour
	{
		[SerializeField] protected Rigidbody blockRigidBody;
		public abstract BlockType Type { get; }
		public abstract void ApplyBehavior();
		public abstract void RemoveBehavior();
		
	}
}