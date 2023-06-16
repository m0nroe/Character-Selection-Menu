using IngameStateMachine;
using States;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private StateMachine _stateMachine;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        var states = new IState[]
        {
            GetComponent<LobbyState>(),
            GetComponent<GameState>()
        };
        
        _stateMachine = new StateMachine(states);
        _stateMachine.Initialize();
        _stateMachine.Enter<LobbyState>();
    }
}