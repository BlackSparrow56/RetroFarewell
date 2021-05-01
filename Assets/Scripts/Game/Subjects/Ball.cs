using UnityEngine;

namespace Game.Subjects
{
    [AddComponentMenu("Game/Subjects/Ball")]
    public class Ball : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        public void Kick()
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("BallAnimation"))
            {
                animator.Play("BallAnimation");
            }
        }
    }
}
