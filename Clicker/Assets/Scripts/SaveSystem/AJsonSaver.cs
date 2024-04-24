using Newtonsoft.Json;
using System;
using System.IO;
using UnityEngine;

namespace SaveSystem
{
    public abstract class AJsonSaver : MonoBehaviour, ISavable
    {
        public string SaveKey { get; set; }

        public virtual object Load(Type dataType)
        {
            string _filePath = Application.persistentDataPath + SaveKey + ".json";
            if (!File.Exists(_filePath))
            {
                File.Create(_filePath);
                return 0;
            }

            using (StreamReader file = File.OpenText(_filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                return serializer.Deserialize(file, typeof(object));
            }
        }

        public virtual void Save(object data)
        {
            string _filePath = Application.persistentDataPath + SaveKey + ".json";

            if (!File.Exists(_filePath))
                File.Create(_filePath);

            using (StreamWriter file = File.CreateText(_filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, data);
            }
        }

        public abstract void SetLoadedData(object data);

        public abstract object GetDataForSave();
    }
}
