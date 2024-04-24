using Clicker;
using SaveSystem;
using Timer;
using UnityEngine;
using Zenject;

namespace Core
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private ClickerView clickerView;
        [SerializeField] private TimerView timerView;
        [SerializeField] private ClickerController clickerController;
        [SerializeField] private TimerController timerController;

        public override void InstallBindings()
        {
            Container.Bind<ClickerView>().FromInstance(clickerView).AsSingle().NonLazy();
            Container.Bind<TimerView>().FromInstance(timerView).AsSingle().NonLazy();

            Container.Bind<ClickerController>().FromInstance(clickerController).AsSingle().NonLazy();
            Container.Bind<TimerController>().FromInstance(timerController).AsSingle().NonLazy();

            Container.Bind<ISaveController>().To<SaveController>().AsSingle().NonLazy();
        }
    }
}