using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Game.Player.Structs;
using Utils.Extensions;

namespace Game.Player
{
    [AddComponentMenu("Game/Player/Movement")]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private List<DirectionInfo> directionsInfo;

        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private Animator animator;

        private List<Vector2> _buffer = new List<Vector2>();

        private void InputLogic()
        {
            foreach (var info in directionsInfo)
            {
                if (Input.GetKeyDown(info.keyCode))
                {
                    _buffer.Add(info.direction);
                }
                else if (Input.GetKeyUp(info.keyCode))
                {
                    _buffer.Remove(info.direction);
                }
            }
        }

        private void MovementLogic()
        {
            rb.AddForce(_buffer.Sum());
        }

        private void AnimationLogic()
        {
            var direction = _buffer.Sum();
            animator.SetInteger("X", (int) direction.x);
            animator.SetInteger("Y", (int) direction.y);

            if (direction != Vector2.zero)
            {
                var animationName = $"Go{directionsInfo.FirstOrDefault(value => value.direction == direction).name}";
                animator.Play(animationName);
            }
        }

        private void Update()
        {
            InputLogic();
            MovementLogic();
            AnimationLogic();
        }
    }
}
