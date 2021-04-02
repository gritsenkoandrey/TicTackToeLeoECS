using Leopotam.Ecs;
using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TicToe
{
    public class CreateTakenViewSystem : IEcsRunSystem
    {
        private EcsFilter<Taken, CellViewRef>.Exclude<TakenRef> _filter = null;
        private Configuration _configuration = null;

        public void Run()
        {
            foreach (var index in _filter)
            {
                var position = _filter.Get2(index).value.transform.position;
                var takenType = _filter.Get1(index).value;

                SignView signView = null;

                switch (takenType)
                {
                    case SignType.Cross:
                        signView = _configuration.crossView;
                        break;
                    case SignType.Zero:
                        signView = _configuration.zeroView;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                var instance = Object.Instantiate(signView, position, Quaternion.identity);
                _filter.GetEntity(index).Get<TakenRef>().value = instance;
            }
        }
    }
}