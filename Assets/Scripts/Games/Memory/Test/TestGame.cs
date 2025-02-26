using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace _clone.Scripts.Games.Memory.Test
{
    public class TestGame : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText; 
        [SerializeField] private GameGrid gameGrid;

        private int score;
        private readonly List<Cell> playerPath = new ();

        private void Start()
        {
            scoreText.text = score.ToString();
            Launch();
        }

        private void Launch()
        {
            CreateGrid();
            StartCoroutine(ShowPath());
        }

        private void CreateGrid()
        {
            gameGrid.CreateGrid();
            gameGrid.SetSubscribers(OnCellClicked);
        }

        private IEnumerator ShowPath()
        {
            Debug.Log("Start show path");
            DeactivateInput();
            yield return new WaitForSeconds(1f);

            gameGrid.GeneratePath();

            for (var index = 0; index < gameGrid.Path.Count; index++)
            {
                HighlightCorrectCell(gameGrid.Path[index]);
                yield return new WaitForSeconds(1f);
                UnhighlightCell(gameGrid.Path[index]);
                yield return new WaitForSeconds(0.5f);
            }
            
            Debug.Log("finish show path");
            ActivateInput();
        }

        void OnCellClicked(Cell cell)
        {
            playerPath.Add(cell);

            var index = playerPath.Count - 1;

            if (gameGrid.Path.Count > index)
            {
                if (playerPath[index] == gameGrid.Path[index]) HighlightCorrectCell(cell);
                else HighlightIncorrectCell(cell);
            }

            CheckPath();
        }

        void CheckPath()
        {
            var isCorrect = false;

            if (gameGrid.Path.Count == playerPath.Count)
            {
                isCorrect = true;
                for (var i = 0; i < playerPath.Count; i++)
                {
                    if (playerPath[i].Pos != gameGrid.Path[i].Pos)
                        continue;

                    isCorrect = false;
                    break;
                }
            }

            if (isCorrect)
            {
                score += 10;
                scoreText.text = "Score: " + score;
            }
            else
            {
                Debug.Log("Game Over!");
            }

            Clean();
            Launch();
        }

        private void Clean()
        {
            gameGrid.Clear();
            playerPath?.Clear();
        }

        private void ActivateInput() => gameGrid.EnableInput();
        private void DeactivateInput() => gameGrid.DisableInput();
        
        private void UnhighlightCell(Cell cell) => gameGrid.UnhighlightCell(cell);
        private void HighlightCorrectCell(Cell cell) => gameGrid.HighlightCorrectCell(cell);
        private void HighlightIncorrectCell(Cell cell) => gameGrid.HighlightIncorrectCell(cell);
    }
}