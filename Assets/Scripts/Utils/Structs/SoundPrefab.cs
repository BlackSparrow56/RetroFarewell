using System;
using UnityEngine;
using Utils.Enums;

namespace Utils.Structs
{
    /// <summary>
    /// Структура для поиска префаба по типу.
    /// </summary>
    [Serializable]
    public struct SoundPrefab
    {
        public GameObject prefab;
        public ESoundVolumeType type;
    }
}
