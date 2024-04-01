using System.Collections.Generic;
using UnityEngine;

namespace School.Jenga
{
	[System.Serializable]
	public class Floor
	{
		public List<Block> blocks = new List<Block>();
		public bool isRotated;
		public int floorNumber;

		public int BlockCount => blocks.Count;

		public Floor(int floorNumber = 0, bool isRotated = false)
		{
			if (blocks.Count > 3)
				throw new System.Exception("A floor can't have more than 3 blocks");

			this.floorNumber = floorNumber;
			this.isRotated = isRotated;
		}

		public bool AddBlock(Block block)
		{
			if (blocks.Count >= 3)
				return false;

			blocks.Add(block);
			return true;
		}

		public void PositionBlocks()
		{
			var currentPosition = Vector3.zero;
			for (var i = 0; i < blocks.Count; i++)
			{
				var block = blocks[i];
				var blockPosition = currentPosition;

				var horizontalPosition = (i - 1) * (block.Width + block.EmptySpaceWidth / 2f);
				var verticalPosition = floorNumber * block.Height;

				if (isRotated)
				{
					blockPosition += new Vector3(0, verticalPosition, horizontalPosition);
					block.transform.Rotate(0, 90, 0);
				}
				else
				{
					blockPosition += new Vector3(horizontalPosition, verticalPosition, 0);
				}

				block.transform.position = blockPosition;
			}
		}
	}
}