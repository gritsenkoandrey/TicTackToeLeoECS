using Leopotam.Ecs;
using UnityEngine;

namespace TicToe
{
    public class InitializeFieldSystem : IEcsInitSystem
    {
        private Configuration _configuration = null;
        private EcsWorld _world = null;
        private GameState _gameState = null;

        public void Init()
        {
            for (int x = 0; x < _configuration.levelWidth; x++)
            {
                for (int y = 0; y < _configuration.levelHeight; y++)
                {
                    var cellEntity = _world.NewEntity();
                    cellEntity.Get<Cell>();

                    var position = new Vector2Int(x, y);
                    cellEntity.Get<Position>().value = position;

                    _gameState.cells[position] = cellEntity;
                }
            }

            _world.NewEntity().Get<UpdateCameraEvent>();
        }
    }
}