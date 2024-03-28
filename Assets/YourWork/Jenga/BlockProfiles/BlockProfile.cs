using UnityEngine;

namespace Jenga
{
	/* Use composition over inheritance to allow for more flexibility in the future
		Use abstract class over scriptable objects because it seems there will 
		be a lot of Component & Scene based logic in the future
	*/
	public abstract class BlockProfile : MonoBehaviour
	{
		[SerializeField] private BlockType blockType;
		public BlockType Type => blockType;

		public abstract void ApplyBehavior();
		public abstract void RemoveBehavior();
	}
}