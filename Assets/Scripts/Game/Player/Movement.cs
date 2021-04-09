﻿using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Game.Player.Structs;
using Utils.Extensions;

namespace Game.Player
{
    [AddComponentMenu("Game/Player/Movement")]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private List<DirectionInfo> directionsInfo;

        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private Animator animator;

        private readonly List<Vector2> _buffer = new List<Vector2>();

        private Vector2 Direction => _buffer.Sum();

        private void InputLogic()
        {
            foreach (var info in directionsInfo)
            {
                if (Input.GetKey(info.keyCode))
                {
                    if (!_buffer.Contains(info.direction))
                    {
                        _buffer.Add(info.direction);
                    }
                }
                else
                {
                    _buffer.Remove(info.direction);
                }
            }
        }

        private void MovementLogic()
        {
            rb.velocity = (Direction * speed) * Time.deltaTime;
        }

        private void AnimationLogic()
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

        private void Update()
        {
            InputLogic();
            MovementLogic();
            AnimationLogic();
        }
    }
}
