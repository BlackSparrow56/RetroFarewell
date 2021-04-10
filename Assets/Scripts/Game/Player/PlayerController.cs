using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{
    [AddComponentMenu("Game/Player/PlayerController")]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerMovement movement;
        [SerializeField] new private PlayerCamera camera;

        public PlayerMovement Movement => movement;
        public PlayerCamera Camera => camera;
    }
}
