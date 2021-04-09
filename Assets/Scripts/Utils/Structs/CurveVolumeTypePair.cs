using System;
using UnityEngine;
using Utils.Enums;

namespace Utils.Structs
{
    [Serializable]
    public struct CurveVolumeTypePair 
    {
        public AnimationCurve curve;
        public ESoundVolumeType volumeType;
    }
}
