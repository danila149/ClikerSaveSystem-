namespace SaveSystem
{
    public interface ISaveController
    {
        public void AddListener(ISavable savable);
        public void RemoveListener(ISavable savable);
        public void SaveAll();
        public void LoadAll();
    }
}
