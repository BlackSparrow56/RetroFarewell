using System;
using UnityEngine;
using UnityEngine.UI;
using Utils.Extensions;

namespace Game.Markers
{
    public abstract class MarkerBase : MonoBehaviour
    {
        [SerializeField] private AnimationCurve curve;

        [SerializeField] private Image markerImage;

        public Transform Target
        {
            get;
            set;
        }

        public Sprite Sprite
        {
            get => markerImage.sprite;
            set => markerImage.sprite = value;
        }

        public virtual void SetRange(float range)
        {
            markerImage.color = markerImage.color.SetAlpha(curve.Evaluate(range));
        }
    }
}
