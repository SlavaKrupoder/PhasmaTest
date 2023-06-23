using TMPro;
using UnityEngine;
using SF = UnityEngine.SerializeField;


namespace PopUps
{
    public class Timer : MonoBehaviour
    {
        [SF]private TextMeshProUGUI _timerText;
        [SF] private TextMeshProUGUI _onTopBoardText;
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
                _timerText.text = UpdateTimerText();
                _onTopBoardText.text = UpdateTimerText();
            }
        }

        public void StartStopTimer()
        {
            _isRunning = !_isRunning;
            _onTopBoardText.gameObject.SetActive(_isRunning);
        }

        public void ResetTimer()
        {
            Reset();
            UpdateTimerText();
        }

        private void Reset()
        {
            _elapsedTime = 0f;
            _timerText.text = string.Format("00:00:000");
            _onTopBoardText.text = string.Format("00:00:000");
        }

        private string UpdateTimerText()
        {
            int minutes = Mathf.FloorToInt(_elapsedTime / 60f);
            int seconds = Mathf.FloorToInt(_elapsedTime % 60f);
            int milliseconds = Mathf.FloorToInt((_elapsedTime * 1000) % 1000);

            return string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
        }
    }
}
