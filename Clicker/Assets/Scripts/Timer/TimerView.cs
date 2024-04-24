using TMPro;
using UnityEngine;

namespace Timer
{
    public class TimerView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI time;

        public void SetTimeText(int hours, int minutes, int seconds) =>
            time.text = $"{hours}h {minutes}m {seconds}s";
    }
}