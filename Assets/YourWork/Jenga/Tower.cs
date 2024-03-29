using System.Collections.Generic;
using UnityEngine;

namespace Jenga
{
	public class Tower : MonoBehaviour
	{
		[SerializeField] private GameObject blockPrefab;
		private List<Floor> floors = new List<Floor>();

		public int FloorCount => floors.Count;

		public void Start()
		{
			var blocks = CreateRandomBlocks(34);
			CreateTower(blocks);
			PositionBlocks();
		}

		private List<Block> CreateRandomBlocks(int count)
		{
			var blocks = new List<Block>();
			for (var i = 0; i < count; i++)
			{
				var block = Instantiate(blockPrefab, transform).GetComponent<Block>();
				blocks.Add(block);
				block.GetComponent<Renderer>().material.color = Random.ColorHSV(); // WIP
			}

			return blocks;
		}

		private void CreateTower(List<Block> blocks)
		{
			var isRotated = false;
			var floor = new Floor(0, isRotated);
			floors.Add(floor);

			foreach (var block in blocks)
			{
				if (floor.AddBlock(block)) continue;

				isRotated = !isRotated;
				floor = new Floor(FloorCount, isRotated);
				floors.Add(floor);
				floor.AddBlock(block);
			}
		}

		private void PositionBlocks()
		{
			foreach (var floor in floors)
			{
				floor.PositionBlocks();
			}
		}
	}
}