using Leopotam.Ecs;

namespace TicToe
{
    public class AnalyzeClickSystem : IEcsRunSystem
    {
        private EcsFilter<Cell, Clicked>.Exclude<Taken> _filter = null;
        private GameState _gameState = null;
        private SceneData _sceneData = null;

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var ecsEntity = ref _filter.GetEntity(index);

                ecsEntity.Get<Taken>().value = _gameState.currentType;
                ecsEntity.Get<CheckWinEvent>();

                _gameState.currentType = _gameState.currentType == SignType.Cross ? SignType.Zero : SignType.Cross;
                _sceneData.UI.gameHUD.SetTurn(_gameState.currentType);
            }
        }
    }
}