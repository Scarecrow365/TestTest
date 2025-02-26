using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace _clone.Scripts.Games.Memory.Test
{
    public class GameGrid : MonoBehaviour
    {
        [SerializeField] private Cell cellPrefab;
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private GridLayoutGroup gridLayout;
        [SerializeField] private Vector2 gridSize;
        [SerializeField] private int pathCount;

        private GridSizer gridSizer;
        private GridGenerator gridGenerator;
        
        public List<Cell> Path { get; } = new();

        private void Awake()
        {
            InitGridSizer();
            InitGridGenerator();
        }

        public void EnableInput() => canvasGroup.interactable = true;
        public void DisableInput() => canvasGroup.interactable = false;
        public void UnhighlightCell(Cell inputCell) => TryGetCell(inputCell)?.UnhighlightCell();
        public void HighlightCorrectCell(Cell inputCell) => TryGetCell(inputCell)?.HighlightCorrectCell();
        public void HighlightIncorrectCell(Cell inputCell) => TryGetCell(inputCell)?.HighlightIncorrectCell();

        public void CreateGrid()
        {
            gridGenerator.Clean();
            gridGenerator.Generate(gridSize);
            gridSizer.Resize();
        }

        public void SetSubscribers(Action<Cell> onCellClicked)
        {
            foreach (var cell in gridGenerator.Cells)
            {
                cell.OnCellClicked += onCellClicked;
            }
        }

        public void GeneratePath()
        {
            var startIndex = UnityEngine.Random.Range(0, 2);
            Path.Add(gridGenerator.Cells[startIndex]);

            for (var i = 1; i < pathCount; i++)
            {
                var nextStep = GetNextStep(gridGenerator.Cells[startIndex]);
                Path.Add(nextStep);
            }
        }

        public void Clear()
        {
            Path?.Clear();
            gridGenerator.Clean();
        }

        private void InitGridSizer()
        {
            var rectTransform = GetComponent<RectTransform>();
            var parentRect = transform.parent.GetComponent<RectTransform>();
            var parentSize = new Vector2(parentRect.rect.width, parentRect.rect.height);
            gridSizer = new GridSizer(gridLayout, rectTransform, gridSize, parentSize);
        }
        
        private void InitGridGenerator()
        {
            gridGenerator = new GridGenerator(cellPrefab, transform);
        }

        private Cell GetNextStep(Cell currentCell)
        {
            Cell nextCell;
            do
            {
                var direction = UnityEngine.Random.Range(0, 4);
                var nextPosition = currentCell.Pos + new Vector2Int(
                    (direction == 0) ? 1 : (direction == 1) ? -1 : 0,
                    (direction == 2) ? 1 : (direction == 3) ? -1 : 0
                );

                nextCell = gridGenerator.Cells.Find(cell => cell.Pos == nextPosition);
            } while (nextCell == null);

            return nextCell;
        }
        
        private Cell TryGetCell(Cell inputCell) => gridGenerator.Cells.FirstOrDefault(cell => cell == inputCell);
    }
}