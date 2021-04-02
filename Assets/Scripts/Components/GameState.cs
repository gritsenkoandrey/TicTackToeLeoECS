using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

namespace TicToe
{
    public class GameState
    {
        public SignType currentType = SignType.Zero;
        public readonly Dictionary<Vector2Int, EcsEntity> cells = new Dictionary<Vector2Int, EcsEntity>();
    }
}