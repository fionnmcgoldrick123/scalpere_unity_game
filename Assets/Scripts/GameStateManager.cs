using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance {get; private set;}

    private GameState currentState = GameState.Normal;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void SetState(GameState newState)
    {
        currentState = newState;

        switch (newState)
        {
            case GameState.Normal:
                //TODO: NormalState
                Debug.Log("Normal State Selected");
                break;

            case GameState.FocusShot:
                //TODO: FocusShotState
                Debug.Log("FocusShot State Selected");
                break;
            
        }
    }
}
