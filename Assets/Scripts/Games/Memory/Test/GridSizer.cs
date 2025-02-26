using UnityEngine;
using UnityEngine.UI;

namespace _clone.Scripts.Games.Memory.Test
{
    public class GridSizer
    {
        private readonly Vector2 spacing;
        private readonly Vector2 cellSize;
        private readonly Vector2 gridSize;        
        private readonly Vector2 parentSize;

        private readonly RectTransform root;
        private readonly GridLayoutGroup gridLayout;

        public GridSizer(GridLayoutGroup gridLayout, RectTransform root, Vector2 gridSize, Vector2 parentSize)
        {
            this.root = root;
            this.gridSize = gridSize;
            this.gridLayout = gridLayout;
            this.parentSize = parentSize;

            spacing = this.gridLayout.spacing;
            cellSize = this.gridLayout.cellSize;
        }

        public void Resize()
        {
            ResizeCountInRow();
            AdjustCellSize();
            CenterGrid();
        }

        private void ResizeCountInRow()
        {
            var constraintCount = Mathf.RoundToInt((gridSize.x + gridSize.y) / 2);
            constraintCount = Mathf.Clamp(constraintCount, 2, 5);
            gridLayout.constraintCount = constraintCount;
        }

        private void AdjustCellSize()
        {
            var availableWidth = parentSize.x - (gridSize.x - 1) * spacing.x;
            var availableHeight = parentSize.y - (gridSize.y - 1) * spacing.y;

            var cellWidth = availableWidth / gridSize.x;
            var cellHeight = availableHeight / gridSize.y;

            cellWidth = Mathf.Min(cellWidth, cellSize.x);
            cellHeight = Mathf.Min(cellHeight, cellSize.y);

            var spacingX = (parentSize.x - cellWidth * gridSize.x) / (gridSize.x - 1);
            var spacingY = (parentSize.y - cellHeight * gridSize.y) / (gridSize.y - 1);

            spacingX = Mathf.Min(spacingX, spacing.x);
            spacingY = Mathf.Min(spacingY, spacing.y);

            gridLayout.spacing = new Vector2(spacingX, spacingY);
            gridLayout.cellSize = new Vector2(cellWidth, cellHeight);
        }

        private void CenterGrid()
        {
            root.anchorMin = new Vector2(0.5f, 0.5f);
            root.anchorMax = new Vector2(0.5f, 0.5f);
            root.pivot = new Vector2(0.5f, 0.5f);
            root.anchoredPosition = Vector2.zero;
        }
    }
}