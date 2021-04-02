using Leopotam.Ecs;
using UnityEngine;

namespace TicToe
{
    public class ControlSystem : IEcsRunSystem
    {
        private SceneData _sceneData = null;

        public void Run()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var camera = _sceneData.Camera;
                var ray = camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out var hit))
                {
                    var cellView = hit.collider.GetComponent<CellView>();

                    if (cellView)
                    {
                        cellView.entity.Get<Clicked>();
                    }
                }
            }
        }
    }
}