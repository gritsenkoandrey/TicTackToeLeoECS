using Leopotam.Ecs;
using UnityEngine;

namespace TicToe
{
    public class SetCameraSystem : IEcsRunSystem
    {
        private EcsFilter<UpdateCameraEvent> _filter = null;
        private Configuration _configuration = null;
        private SceneData _sceneData = null;

        public void Run()
        {
            if (!_filter.IsEmpty())
            {
                var height = _configuration.levelHeight;

                var camera = _sceneData.Camera;
                camera.orthographic = true;
                camera.orthographicSize = height / 2.0f + (height - 1) * _configuration.offset.y / 2;

                _sceneData.CameraTransform.position = new Vector3(
                    _configuration.levelWidth / 2.0f + (_configuration.levelWidth - 1) * _configuration.offset.x / 2,
                    height / 2.0f + (height - 1) * _configuration.offset.y / 2);
            }
        }
    }
}