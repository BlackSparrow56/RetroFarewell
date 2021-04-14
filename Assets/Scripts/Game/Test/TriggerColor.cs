using UnityEngine;
using Utils;

public class TriggerColor : MonoBehaviour
{
    [SerializeField] private float duration;

    [SerializeField] private Color activeColor;
    [SerializeField] private Color passiveColor;

    [SerializeField] private SpriteRenderer triggerRenderer;
    
    public void Enter()
    {
        Set(activeColor);
    }

    public void Exit()
    {
        Set(passiveColor);
    }

    private void Set(Color color)
    {
        Color tempColor = triggerRenderer.color;

        StopAllCoroutines();
        StartCoroutine(Coroutines.Graduate(SetProgress, duration, false));

        void SetProgress(float progress)
        {
            triggerRenderer.color = Color.Lerp(tempColor, color, progress);
        }
    }
}
