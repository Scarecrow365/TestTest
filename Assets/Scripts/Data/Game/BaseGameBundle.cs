using System;
using _clone.Scripts.Games;
using UnityEngine;

namespace _clone.Scripts.Data.Game
{
    public abstract class BaseGameBundle : ScriptableObject
    {
        [field: SerializeField] public BaseGame GamePrefab { get; private set; }
        [field: SerializeField] public PreGameData PreGameData { get; private set; }
        
        public abstract string Id { get; }
    }

    [Serializable]
    public struct PreGameData
    {
        public Sprite logo;
        public string name;
        public string description;
    }
}