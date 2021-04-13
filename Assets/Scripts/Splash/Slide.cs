using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace Splash
{
    [AddComponentMenu("Splash/Slide")]
    public class Slide : MonoBehaviour
    {
        [SerializeField] private List<Graphic> graphics;

        private void Start()
        {
            graphics.ForEach(value => value.CrossFadeAlpha(0f, 0f, true));
        }
    }
}
