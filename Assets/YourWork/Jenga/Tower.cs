using System.Collections.Generic;
using System.Linq;
using School.Data;
using UnityEngine;

namespace School.Jenga
{
	public class Tower : MonoBehaviour
	{
		[SerializeField] private List<GameObject> towerPrefab;
		[SerializeField] private TowerLabel towerLabel;
		[SerializeField] private TowerOrbitController towerOrbitController;

		private List<Floor> floors = new List<Floor>();
		private List<Block> blocks;

		public TowerLabel TowerLabel => towerLabel;
		public TowerOrbitController OrbitController => towerOrbitController;
		public int FloorCount => floors.Count;
		public float Height => blocks.Count > 0 ? floors.Count * blocks.First().Height : 0f;

		private GameObject GetRandomBlockPrefab()
		{
			return towerPrefab[Random.Range(0, towerPrefab.Count)];
		}

		private GameObject GetBlockPrefab(BlockType type)
		{
			var blockPrefab = towerPrefab.Find(prefab => prefab.GetComponent<Block>().Profile.Type == type);

			if (blockPrefab == null)
			{
				throw new System.Exception($"Block prefab not found for type {type}");
			}

			return blockPrefab;
		}

		public List<Block> CreateRandomBlocks(int count)
		{
			var blocks = new List<Block>();
			for (var i = 0; i < count; i++)
			{
				var block = Instantiate(GetRandomBlockPrefab(), transform).GetComponent<Block>();
				blocks.Add(block);
				block.GetComponent<Renderer>().material.color = Random.ColorHSV(); // WIP
			}

			return blocks;
		}

		// TODO : move ?
		public IEnumerable<Block> CreateBlocks(IEnumerable<Concept> concepts)
		{
			var blocks = new List<Block>();
			foreach (var concept in concepts)
			{
				var type = (BlockType)concept.mastery;
				var block = Instantiate(GetBlockPrefab(type), transform).GetComponent<Block>();
				blocks.Add(block);
				block.Concept = concept;
			}

			return blocks;
		}

		public void CreateTower(IEnumerable<Block> blocks)
		{
			this.blocks = blocks.ToList();
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

		public void ApplyBlockBehaviors()
		{
			foreach (var block in blocks)
			{
				block.Profile.ApplyBehavior();
			}
		}

		public void Reset()
		{
			foreach (var block in blocks)
			{
				block.Profile.RemoveBehavior();
			}

			PositionBlocks();
		}
	}
}