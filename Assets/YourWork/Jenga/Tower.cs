using System.Collections.Generic;
using School.Data;
using UnityEngine;

namespace School.Jenga
{
	public class Tower : MonoBehaviour
	{
		[SerializeField] private GameObject blockPrefab;
		private List<Floor> floors = new List<Floor>();

		public int FloorCount => floors.Count;

		public List<Block> CreateRandomBlocks(int count)
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

		// TODO : move ?
		public IEnumerable<Block> CreateBlocks(IEnumerable<Concept> concept)
		{
			var blocks = new List<Block>();
			foreach (var c in concept)
			{
				var block = Instantiate(blockPrefab, transform).GetComponent<Block>();
				blocks.Add(block);
				block.GetComponent<Renderer>().material.color = Random.ColorHSV(); // WIP
			}

			return blocks;
		}

		// TODO : move ?
		public void CreateTower(IEnumerable<Block> blocks)
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

		public void PositionBlocks()
		{
			foreach (var floor in floors)
			{
				floor.PositionBlocks();
			}
		}
	}
}