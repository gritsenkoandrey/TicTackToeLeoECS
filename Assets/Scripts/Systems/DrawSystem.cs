using Leopotam.Ecs;

namespace TicToe
{
    public class DrawSystem : IEcsRunSystem
    {
        private EcsFilter<Cell>.Exclude<Taken> _freeCells = null;
        private EcsFilter<Winner> _winner = null;
        private SceneData _sceneData = null;

        public void Run()
        {
            if (_freeCells.IsEmpty() && _winner.IsEmpty())
            {
                _sceneData.UI.loseScreen.Show(true);
            }
        }
    }
}