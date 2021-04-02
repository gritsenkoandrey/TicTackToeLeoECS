using Leopotam.Ecs;

namespace TicToe
{
    public class CheckWinSystem : IEcsRunSystem
    {
        private EcsFilter<Position, Taken, CheckWinEvent> _filter = null;
        private GameState _gameState = null;
        private Configuration _configuration = null;

        public void Run()
        {
            foreach (var index in _filter)
            {
                if (!_filter.IsEmpty())
                {
                    ref var position = ref _filter.Get1(index);

                    var chainLength =  _gameState.cells.GetLongestChain(position.value);

                    if (chainLength >= _configuration.chainLength)
                    {
                        _filter.GetEntity(index).Get<Winner>();
                    }
                }
            }
        }
    }
}