using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Game.Events;
using Game.Events.Instructions.Enums;
using Game.Player.Structs;
using Utils.Extensions;
using Zenject;

namespace Game.Player
{
    [AddComponentMenu("Game/Player/PlayerMovement")]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Vector2 tileSize;

        [SerializeField] private float speed;
        [SerializeField] private List<DirectionInfo> directionsInfo;

        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private Animator animator;

        private readonly List<Vector2> _buffer = new List<Vector2>();

        private Vector2 Direction => directionsInfo.FirstOrDefault(value => value.direction == Normalize(_buffer.Sum())).direction;
        private Vector2 RealDirection => (Direction.magnitude == 1) ? Direction * tileSize : Direction * tileSize / 2;

        public bool CanMove
        {
            get;
            set;
        } = true;

        private Executor _executor;

        [Inject]
        private void Construct(Executor executor)
        {
            _executor = executor;
        }

        private Vector2 Normalize(Vector2 vector)
        {
            if (vector.x > 1)
            {
                vector.x = 1;
            }

            if (vector.y > 1)
            {
                vector.y = 1;
            }

            return vector;
        }

        private void MovementLogic(out bool rested)
        {
            var direction = RealDirection * speed * Time.deltaTime;

            var cast = rb.Cast(direction, new ContactFilter2D() { layerMask = LayerMask.GetMask("Obstacles") }, new RaycastHit2D[1], direction.magnitude) == 0;
            if (cast)
            {
                transform.position += (Vector3) direction;
            }

            rested = !cast;
        }

        private void AnimationLogic(bool rested)
        {
            if (!rested)
            {
                if (Direction != Vector2.zero)
                {
                    var animationName = $"Go{directionsInfo.FirstOrDefault(value => value.direction == Direction).name}";
                    if (!animator.GetCurrentAnimatorStateInfo(0).IsName(animationName))
                    {
                        animator.Play(animationName);
                    }
                }
                else
                {
                    animator.SetTrigger("Idle");
                }
            }
            else
            {
                animator.SetTrigger("Idle");
            }
        }

        private void Update()
        {
            if (CanMove)
            {
                MovementLogic(out bool rested);
                AnimationLogic(rested);
            }
            else
            {
                animator.SetTrigger("Idle");
            }
        }

        private void OnEnable()
        {
            foreach (var info in directionsInfo)
            {
                _executor.AddKeyInstruction(info.keyCode, EKeyState.Holded, HoldedAction);
                _executor.AddKeyInstruction(info.keyCode, EKeyState.Untouched, UntouchedAction);

                void HoldedAction()
                {
                    if (!_buffer.Contains(info.direction))
                    {
                        _buffer.Add(info.direction);
                    }
                }

                void UntouchedAction()
                {
                    _buffer.Remove(info.direction);
                }
            }
        }

        private void OnDisable()
        {
            foreach (var info in directionsInfo)
            {
                _executor.RemoveKeyInstruction(info.keyCode, EKeyState.Holded);
                _executor.RemoveKeyInstruction(info.keyCode, EKeyState.Untouched);
            }
        }
    }
}
