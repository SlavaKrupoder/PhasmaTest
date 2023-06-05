using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _timerText;
    private float _elapsedTime;
    private bool _isRunning;

    private void Start()
    {
        ResetTimer();
    }

    private void Update()
    {
        if (_isRunning)
        {
            _elapsedTime += Time.deltaTime;
            UpdateTimerText();
        }
    }

    public void StartStopTimer()
    {
        _isRunning = !_isRunning;
    }

    public void ResetTimer()
    {
        Reset();
        UpdateTimerText();
    }

    private void Reset()
    {
        _elapsedTime = 0f;
        _isRunning = false;
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(_elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(_elapsedTime % 60f);
        int milliseconds = Mathf.FloorToInt((_elapsedTime * 1000) % 1000);

        _timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }
}
