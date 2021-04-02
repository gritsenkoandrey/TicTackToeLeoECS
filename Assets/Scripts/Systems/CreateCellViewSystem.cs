using Leopotam.Ecs;
using UnityEngine;

namespace TicToe
{
    public class CreateCellViewSystem : IEcsRunSystem
    {
        private EcsFilter<Cell, Position>.Exclude<CellViewRef> _filter = null;
        private Configuration _configuration = null;

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var position = ref _filter.Get2(index);

                var cellView = Object.Instantiate(_configuration.cellView);

                cellView.transform.position = new Vector3
                    (position.value.x + _configuration.offset.x * position.value.x,
                    position.value.y + _configuration.offset.y * position.value.y);

                cellView.entity = _filter.GetEntity(index);

                _filter.GetEntity(index).Get<CellViewRef>().value = cellView;
            }
        }
    }
}