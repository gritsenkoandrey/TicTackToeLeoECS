using Leopotam.Ecs;

namespace TicToe
{
    public class WinSystem : IEcsRunSystem
    {
        private EcsFilter<Winner, Taken> _filter = null;
        private SceneData _sceneData = null;

        public void Run()
        {
            if (!_sceneData.UI.winScreen.gameObject.activeInHierarchy)
            {
                foreach (var index in _filter)
                {
                    ref var winnerType = ref _filter.Get2(index);
                    _sceneData.UI.winScreen.Show(true);
                    _sceneData.UI.winScreen.SetWinner(winnerType.value);
                }
            }
        }
    }
}