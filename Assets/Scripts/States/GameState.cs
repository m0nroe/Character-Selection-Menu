using System.Collections;
using IngameStateMachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour, IState
{
    public void Dispose()
    {
    }

    public void Initialize(StateMachine stateMachine)
    {
    }

    public void OnEnter()
    {
        SceneManager.LoadScene(GlobalConstants.GAME_SCENE_NAME);

        //StartCoroutine(StartGame());
    }

    private IEnumerator StartGame()
    {
        SceneManager.LoadScene(GlobalConstants.GAME_SCENE_NAME);

        yield return null;
    }

    public void OnExit()
    {
    }
}