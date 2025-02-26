using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _clone.Scripts.Games.Memory.PathMemoryGame
{
    public class Tile : MonoBehaviour
    {
        // public event Action<Tile> TilePressed;
        // public event Action<Tile> TileReleased;
        // public event Action<Tile> TileDraggedOver;
        //
        // [SerializeField] private List<Color> titleColors;
        // [SerializeField] private Image sprite;
        // [SerializeField] private Image pathSprite;
        // [SerializeField] private Color correctColor;
        // [SerializeField] private PathTile pathTile;
        //
        // private bool isForgivingInput;
        // private bool isAccurateInput;
        //
        // private TweenRotation rotationTween;
        // private UnityUI.TweenColor colorTween;
        // private TweenScale scaleTween;
        // private TweenAlpha alphaTween;
        // private EventTrigger eventTrigger;
        //
        // private const string DefaultTile = "Tile";
        // private const string ShowPathTile = "Tile_orange";
        // private const string CorrectPathTile = "Tile_green";
        // private const string IncorrectPathTile = "Tile_red";
        //
        // public bool InputAllowed
        // {
        //     get => isForgivingInput || isAccurateInput;
        //     set
        //     {
        //         if (!value)
        //         {
        //             isForgivingInput = false;
        //             isAccurateInput = false;
        //         }
        //         else
        //         {
        //             EnableForgivingInput();
        //         }
        //     }
        // }
        //
        // public int Size
        // {
        //     get => (int)GetComponent<RectTransform>().rect.width;
        //     set
        //     {
        //         if (Math.Abs(GetComponent<RectTransform>().rect.width - value) < 0.1f)
        //             return;
        //
        //         GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, value);
        //     }
        // }
        //
        // private void Awake()
        // {
        //     rotationTween = GetComponent<TweenRotation>();
        //
        //     colorTween = sprite.GetComponent<UnityUI.TweenColor>();
        //
        //     scaleTween = GetComponent<TweenScale>();
        //     
        //     eventTrigger = GetComponent<EventTrigger>(); 
        //     eventTrigger ??= gameObject.AddComponent<EventTrigger>();
        // }
        //
        // private void Start()
        // {
        //     scaleTween.to = new Vector3(1.1f, 1.1f, 1.0f);
        //
        //     CreateTrigger(EventTriggerType.PointerDown, (bed) => { OnTilePressed(this); });
        //     CreateTrigger(EventTriggerType.PointerUp, (bed) => { OnTileReleased(this); });
        //     CreateTrigger(EventTriggerType.PointerEnter, (bed) =>
        //     {
        //         if (Input.touchCount > 0 || Input.GetMouseButton(0))
        //         {
        //             OnTileDraggedOver(this);
        //         }
        //     });
        // }
        //
        // private void CreateTrigger(EventTriggerType type, UnityEngine.Events.UnityAction<BaseEventData> e)
        // {
        //     EventTrigger.Entry entry = new() { eventID = type };
        //     entry.callback.AddListener(e);
        //
        //     eventTrigger.triggers.Add(entry);
        // }
        //
        // private void OnTilePressed(Tile tile) => TilePressed?.Invoke(tile);
        //
        // private void OnTileReleased(Tile tile) => TileReleased?.Invoke(tile);
        //
        // private void OnTileDraggedOver(Tile tile) => TileDraggedOver?.Invoke(tile);
        //
        // private void Set(Image spr, string name)
        // {
        //     Color newTitleColor;
        //
        //     switch (name)
        //     {
        //         case "Tile":
        //             newTitleColor = titleColors[0];
        //             break;
        //         
        //         case "Tile_green":
        //             newTitleColor = titleColors[1];
        //             break;
        //         
        //         case "Tile_orange":
        //             newTitleColor = titleColors[2];
        //             break;
        //         
        //         case "Tile_red":
        //             newTitleColor = titleColors[3];
        //             break;
        //         
        //         default:
        //             newTitleColor = titleColors[0];
        //             break;
        //     }
        //
        //     spr.color = newTitleColor;
        // }
        //
        // public void EnableAccurateInput()
        // {
        //     isAccurateInput = true;
        //     isForgivingInput = false;
        // }
        //
        // private void EnableForgivingInput()
        // {
        //     isAccurateInput = false;
        //     isForgivingInput = true;
        // }
        //
        // public void Highlight()
        // {
        //     colorTween.to = correctColor;
        //     colorTween.PlayForward();
        // }
        //
        // public void StopHighlight()
        // {
        //     if (colorTween.enabled)
        //     {
        //         colorTween.enabled = false;
        //         sprite.color = Color.white;
        //     }
        // }
        //
        // public void MarkIncorrect()
        // {
        //     Set(sprite, IncorrectPathTile);
        // }
        //
        // public IEnumerator DisplayAndFadePath(RotateDirection flipDirection, RotateDirection prevFlipDirection, float fadeDelay)
        // {
        //     pathTile.ShowNode(flipDirection, prevFlipDirection, false, false);
        //
        //     Set(sprite, ShowPathTile);
        //
        //     pathSprite.CrossFadeAlpha(1.0f, 0.25f, false);
        //
        //     yield return new WaitForSeconds(0.25f + fadeDelay);
        //
        //     pathSprite.CrossFadeAlpha(0.0f, 0.25f, false);
        //
        //     yield return new WaitForSeconds(0.25f);
        //     Set(sprite, DefaultTile);
        // }
        //
        // public void Rotate(RotateDirection flipDirection, RotateDirection prevFlipDirection, bool failed = false)
        // {
        //     Vector3 rotationHalf;
        //     Vector3 rotationFull;
        //
        //     RotateDirection direction = flipDirection == RotateDirection.None
        //         ? prevFlipDirection
        //         : flipDirection;
        //
        //     switch (direction)
        //     {
        //         case RotateDirection.Left:
        //             rotationHalf = new Vector3(0.0f, 90.0f, 0.0f);
        //             rotationFull = new Vector3(0.0f, 180.0f, 0.0f);
        //             break;
        //
        //         case RotateDirection.Right:
        //             rotationHalf = new Vector3(0.0f, -90.0f, 0.0f);
        //             rotationFull = new Vector3(0.0f, -180.0f, 0.0f);
        //             break;
        //
        //         case RotateDirection.Up:
        //             rotationHalf = new Vector3(90.0f, 0.0f, 0.0f);
        //             rotationFull = new Vector3(180.0f, 0.0f, 0.0f);
        //             break;
        //
        //         case RotateDirection.Down:
        //             rotationHalf = new Vector3(-90.0f, 0.0f, 0.0f);
        //             rotationFull = new Vector3(-180.0f, 0.0f, 0.0f);
        //             break;
        //
        //         default:
        //             return;
        //     }
        //
        //     rotationTween.from = Vector2.zero;
        //     rotationTween.to = rotationHalf;
        //     rotationTween.ResetToBeginning();
        //     rotationTween.PlayForward();
        //
        //     EventDelegate showPath = new EventDelegate(() =>
        //     {
        //         pathTile.ShowNode(flipDirection, prevFlipDirection, !failed, true);
        //
        //         Set(sprite, failed ? ShowPathTile : CorrectPathTile);
        //         pathSprite.CrossFadeAlpha(1, 0, false);
        //
        //         rotationTween.from = rotationHalf;
        //         rotationTween.to = rotationFull;
        //         rotationTween.ResetToBeginning();
        //         rotationTween.PlayForward();
        //     });
        //     showPath.oneShot = true;
        //     rotationTween.AddOnFinished(showPath);
        // }
        //
        // public void ResetTile()
        // {
        //     StopHighlight();
        //     colorTween.ResetToBeginning();
        //     Set(sprite, DefaultTile);
        //     sprite.color = Color.white;
        //
        //     rotationTween.from = Vector2.zero;
        //     rotationTween.to = Vector2.zero;
        //     rotationTween.ResetToBeginning();
        //     transform.localRotation = Quaternion.Euler(Vector2.zero);
        //
        //     InputAllowed = false;
        //
        //     pathSprite.sprite = null;
        //     pathSprite.CrossFadeAlpha(0, 1, false);
        //     pathSprite.transform.localRotation = Quaternion.Euler(Vector2.zero);
        // }
    }
}