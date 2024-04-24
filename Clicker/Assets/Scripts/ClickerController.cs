using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;
using SaveSystem;

namespace Clicker
{
    public class ClickerController : APlayerPrefsSaver, IPointerDownHandler, IPointerUpHandler
    {
        private const string POINT_KEY = "Points";

        [SerializeField] private float pointMult;

        private ClickerView _view;
        private float _points;
        private float _pointsPerPress;
        private bool isDown;

        [Inject]
        public void Construct(ClickerView clickerView)
        {
            _view = clickerView;
            SaveKey = POINT_KEY;
        }

        void Start()
        {
            _view.SetText($"{_points:F2}");
        }

        private void Update()
        {
            if (isDown)
                _pointsPerPress += Time.deltaTime;

        }

        public void OnPointerDown(PointerEventData eventData) =>
            isDown = true;

        public void OnPointerUp(PointerEventData eventData)
        {
            isDown = false;
            _points += pointMult * _pointsPerPress;
            _pointsPerPress = 0;
            _view.SetText($"{_points:F2}");
        }

        public override void SetLoadedData(object data) =>
            _points = float.Parse(data.ToString());

        public override object GetDataForSave() => _points;
    }
}