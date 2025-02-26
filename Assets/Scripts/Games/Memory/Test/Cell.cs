using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _clone.Scripts.Games.Memory.Test
{
    public class Cell : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Image graphics;

        public event Action<Cell> OnCellClicked;

        public Vector2Int Pos { get; private set; }

        public void SetPosition(int x, int y)
        {
            Pos = new Vector2Int(x, y);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnCellClicked?.Invoke(this);
        }
        
        public void Clear()
        {
            UnhighlightCell();
            gameObject.SetActive(false);
            OnCellClicked = null;
        }

        public void UnhighlightCell() => graphics.color = Color.white;

        public void HighlightCorrectCell() => graphics.color = Color.green;

        public void HighlightIncorrectCell() => graphics.color = Color.red;
    }
}