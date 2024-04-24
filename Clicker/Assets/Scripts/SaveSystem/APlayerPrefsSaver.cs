using System;
using UnityEngine;

namespace SaveSystem
{
    public abstract class APlayerPrefsSaver : MonoBehaviour, ISavable
    {
        public string SaveKey { get; set; }

        public virtual object Load(Type dataType)
        {
            if (SaveKey == null)
                throw new Exception("Key not assigned");

            if (dataType == typeof(int))
                return PlayerPrefs.GetInt(SaveKey, 0);
            else if (dataType == typeof(float))
                return PlayerPrefs.GetFloat(SaveKey, 0);
            else if (dataType == typeof(string))
                return PlayerPrefs.GetString(SaveKey, "");

            throw new Exception("Type not supported");
        }

        public virtual void Save(object data)
        {
            if(SaveKey == null)
                throw new Exception("Key not assigned");

            if (data.GetType() == typeof(int))
            {
                PlayerPrefs.SetInt(SaveKey, (int)data);
                return;
            }
            else if (data.GetType() == typeof(float))
            {
                PlayerPrefs.SetFloat(SaveKey, (float)data);
                return;
            }
            else if (data.GetType() == typeof(string))
            {
                PlayerPrefs.SetString(SaveKey, (string)data);
                return;
            }

            throw new Exception("Type not supported");
        }

        public abstract void SetLoadedData(object data);

        public abstract object GetDataForSave();
    }
}
