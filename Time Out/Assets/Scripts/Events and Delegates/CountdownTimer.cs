using UnityEngine;
using System.Collections;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    [Header("Timer Settings")]
    [SerializeField] float timer = 10f;
    [SerializeField] float timeToDecrease = 1f;
    [SerializeField] TextMeshProUGUI timerText;

    public delegate void HandleGameEnd();
    public static event HandleGameEnd onGameEnd;

    void Start()
    {
        StartCoroutine(StartTimer());
    }

    IEnumerator StartTimer()
    {
        float remainingTime = timer;
        while(timer > 0)
        {
            timerText.text = "Time : " + Mathf.Ceil(timer).ToString();
            yield return new WaitForSeconds(timeToDecrease);
            timer--;
        }

        timerText.text = "Timer: 0";
        onGameEnd.Invoke();
    }
}