using System.Collections.Generic;
using UnityEngine;

namespace _clone.Scripts.Games.Memory.Test
{
    public class GridGenerator
    {
        private readonly Cell cellPrefab;
        private readonly Transform parent;
        private readonly List<Cell> pool = new();

        public List<Cell> Cells { get; } = new();

        public GridGenerator(Cell cellPrefab, Transform parent)
        {
            this.parent = parent;
            this.cellPrefab = cellPrefab;
        }

        public void Generate(Vector2 gridSize)
        {
            var poolIndex = 0;

            for (var x = 0; x < gridSize.x; x++)
            {
                for (var y = 0; y < gridSize.y; y++)
                {
                    Cell cell;

                    if (pool.Count >= gridSize.x + gridSize.y)
                    {
                        cell = pool[poolIndex++];
                        cell.gameObject.SetActive(true);
                    }
                    else
                    {
                        cell = Object.Instantiate(cellPrefab, parent);
                        pool.Add(cell);
                    }

                    cell.SetPosition(x, y);
                    Cells.Add(cell);
                }
            }
        }

        public void Clean()
        {
            foreach (var item in pool)
            {
                item.Clear();
            }

            Cells.Clear();
        }
    }
}