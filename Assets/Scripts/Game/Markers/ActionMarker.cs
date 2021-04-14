using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Markers
{
    [AddComponentMenu("Game/Markers/ActionMarker")]
    public class ActionMarker : MarkerBase
    {
        [SerializeField] private float actionRange;

        public Action onMarkerDisappear = () => { };

        public bool SelfDestroy
        {
            get;
            set;
        }

        public override void SetRange(float range)
        {
            base.SetRange(range);
            if (range <= actionRange)
            {
                onMarkerDisappear.Invoke();
                if (SelfDestroy)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
