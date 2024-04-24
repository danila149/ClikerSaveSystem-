using System;

namespace SaveSystem
{
    public interface ISavable
    {
        public void Save(object data);

        public object Load(Type dataType);

        public void SetLoadedData(object data);
        public object GetDataForSave();
    }
}