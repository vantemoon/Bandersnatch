﻿// This code is part of the Fungus library (http://fungusgames.com) maintained by Chris Gregan (http://twitter.com/gofungus).
// It is released for free under the MIT open source license (https://github.com/snozbot/fungus/blob/master/LICENSE)

using UnityEngine;

namespace CGTUnity.Fungus.SaveSystem
{
    /// <summary>
    /// A container for a single SaveData instance, for encoding and later decoding.
    /// The data and its associated type are stored as string properties.
    /// The data would typically be a JSON string representing a saved object.
    /// </summary>
    [System.Serializable]
    public class SaveDataItem : SaveData
    {
        [SerializeField] protected string dataType = "";
        [SerializeField] protected string data = "";

        #region Public methods

        /// <summary>
        /// Gets the type of the data.
        /// </summary>
        public virtual string DataType { get { return dataType; } }

        /// <summary>
        /// Gets the data.
        /// </summary>
        public virtual string Data { get { return data; } }

        public SaveDataItem() {}

        public SaveDataItem(string dataType, string data)
        {
            this.dataType = dataType;
            this.data = data;
        }
        
        /// <summary>
        /// Factory method to create a new SaveDataItem.
        /// </summary>
        public static SaveDataItem Create(string dataType, string data)
        {
            var item = new SaveDataItem();
            item.dataType = dataType;
            item.data = data;

            return item;
        }

        public static SaveDataItem CreateFrom<T>(T saveData) where T : SaveData
        {
            var saveType = typeof(T);
            var dataAsJson = JsonUtility.ToJson(saveData, true);

            var newItem = new SaveDataItem(saveType.Name, dataAsJson);

            return newItem;
        }

        #endregion
    }
}