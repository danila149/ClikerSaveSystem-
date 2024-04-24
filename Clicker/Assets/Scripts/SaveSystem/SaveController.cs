using System.Collections.Generic;
using Zenject;

namespace SaveSystem
{
    public class SaveController : ISaveController
    {
        private List<ISavable> _savables;

        [Inject]
        public SaveController()
        {
            _savables = new List<ISavable>();
        }

        public void AddListener(ISavable savable)
        {
            if (!_savables.Contains(savable))
                _savables.Add(savable);
        }

        public void RemoveListener(ISavable savable)
        {
            if (_savables.Contains(savable))
                _savables.Remove(savable);
        }

        public void LoadAll()
        {
            foreach (ISavable savable in _savables)
            {
                savable.SetLoadedData(savable.Load(savable.GetDataForSave().GetType()));
            }
        }

        public void SaveAll()
        {
            foreach (ISavable savable in _savables)
                savable.Save(savable.GetDataForSave());
        }
    }
}
