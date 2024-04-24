using UnityEngine;
using Zenject;
using SaveSystem;

namespace Timer
{
    public class TimerController : AJsonSaver
    {
        private const string TIME_KEY = "TimePlayed";

        private TimerView _view;
        private float _elapsedTime;

        [Inject]
        public void Construct(TimerView timerView)
        {
            _view = timerView;
            SaveKey = TIME_KEY;
        }

        void Update()
        {
            _elapsedTime += Time.deltaTime;
            ConvertToTime();
        }

        public override void SetLoadedData(object data) =>
            _elapsedTime = float.Parse(data.ToString());

        public override object GetDataForSave() => _elapsedTime;

        private void ConvertToTime()
        {
            int hours = Mathf.FloorToInt(_elapsedTime /3600f);
            int minutes = Mathf.FloorToInt((_elapsedTime - hours * 3600f) / 60f);
            int seconds = Mathf.FloorToInt((_elapsedTime - hours * 3600f) - (minutes * 60f));

            _view.SetTimeText(hours, minutes, seconds);
        }
    }
}