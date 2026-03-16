using UnityEngine;

public class EventHandler : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;

    void OnEnable()
    {
        CountdownTimer.onGameEnd += HandleGameEnd;
    }

    void OnDisable()
    {
        CountdownTimer.onGameEnd -= HandleGameEnd;
    }

    public void HandleGameEnd()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("Game Over");
    }
}
