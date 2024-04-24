using Clicker;
using SaveSystem;
using Timer;
using UnityEngine;
using Zenject;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        private ISaveController _saveController;

        [Inject]
        public void Construct(ClickerController clickerController, TimerController timerController, ISaveController saveController)
        {
            _saveController = saveController;
            saveController.AddListener(timerController);
            saveController.AddListener(clickerController);
            saveController.LoadAll();
        }

        private void OnDestroy()
        {
            _saveController.SaveAll();
        }
    }
}