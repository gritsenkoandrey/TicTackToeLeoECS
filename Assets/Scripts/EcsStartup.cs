using Leopotam.Ecs;
using UnityEngine;

namespace TicToe
{
    sealed class EcsStartup : MonoBehaviour
    {
        private EcsWorld _world = null;
        private EcsSystems _systems = null;

        public Configuration configuration = null;
        public SceneData sceneData = null;

        void Start ()
        {
            // void can be switched to IEnumerator for support coroutines.
            
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif

            var gameState = new GameState();
            sceneData.UI.gameHUD.SetTurn(gameState.currentType);

            _systems
                 // register your systems here, for example:
                 .Add(new InitializeFieldSystem())
                 .Add(new CreateCellViewSystem())
                 .Add(new SetCameraSystem())
                 .Add(new ControlSystem())
                 .Add(new AnalyzeClickSystem())
                 .Add(new CreateTakenViewSystem())
                 .Add(new CheckWinSystem())
                 .Add(new WinSystem())
                 .Add(new DrawSystem())

                 // register one-frame components (order is important), for example:
                 .OneFrame<UpdateCameraEvent>()
                 .OneFrame<Clicked>()
                 .OneFrame<CheckWinEvent>()

                 // inject service instances here (order doesn't important), for example:
                 .Inject(configuration)
                 .Inject(sceneData)
                 .Inject(gameState)

                .Init ();
        }

        void Update ()
        {
            _systems?.Run ();
        }

        void OnDestroy ()
        {
            if (_systems != null)
            {
                _systems.Destroy ();
                _systems = null;
                _world.Destroy ();
                _world = null;
            }
        }
    }
}