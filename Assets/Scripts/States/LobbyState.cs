using IngameStateMachine;
using SimpleEventBus.Disposables;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace States
{
    public class LobbyState : MonoBehaviour, IState
    {
        private StateMachine _stateMachine;
        private CompositeDisposable _subscriptions;

        public void Dispose()
        {
        }

        public void Initialize(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void OnEnter()
        {
            _subscriptions = new CompositeDisposable
            {
                EventStreams.Game.Subscribe<StartGameEvent>(StartGameHandler)
            };
            SceneManager.LoadScene(GlobalConstants.LOBBY_SCENE_NAME);
        }

        public void OnExit()
        {
            _subscriptions?.Dispose();
        }

        private void StartGameHandler(StartGameEvent eventData)
        {
            _stateMachine.Enter<GameState>();
        }
    }
}