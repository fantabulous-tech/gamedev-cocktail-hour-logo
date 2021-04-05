using UnityEngine;

public class FadeAndDestroy : MonoBehaviour {
    [SerializeField] private AnimationCurve m_FadeCurve = AnimationCurve.EaseInOut(0, 1, 1, 0);
    [SerializeField] private float m_Lifetime = 10;
    [SerializeField] private SpriteRenderer[] m_SpriteRenderers;

    private float m_Time;

    private float Progress => Mathf.Clamp01((Time.time - m_Time)/m_Lifetime);

    private void Reset() {
        m_SpriteRenderers = GetComponentsInChildren<SpriteRenderer>();
    }

    private void Start() {
        m_Time = Time.time;
        UpdateColors();
        Destroy(gameObject, m_Lifetime);
    }

    private void LateUpdate() {
        UpdateColors();
    }

    private void UpdateColors() {
        Color c = new Color(1, 1, 1, m_FadeCurve.Evaluate(Progress));

        foreach (SpriteRenderer spriteRenderer in m_SpriteRenderers) {
            spriteRenderer.color = c;
        }
    }
}