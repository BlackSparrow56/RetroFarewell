using System;

namespace Utils.Structs
{
    [Serializable]
    public struct Pair<K, V>
    {
        public K key;
        public V value;
    }
}
