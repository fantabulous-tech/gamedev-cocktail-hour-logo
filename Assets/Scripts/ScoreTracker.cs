using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class ScoreTracker : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI m_HighScoreDisplay;
    [SerializeField] private TextMeshProUGUI m_CurrentScoreDisplay;
    [SerializeField] private float m_PunchDuration = 0.5f;
    [SerializeField] private float m_PunchScale = 0.1f;
    [SerializeField] private int m_PunchVibrato = 5;
    [SerializeField] private float m_PunchElasticity = 1;

    private string m_CurrentType;
    private int m_CurrentScore;

    private string m_HighType;
    private int m_HighScore;

    private void Start() {
        UpdateDisplay();
    }

    public void OnObjectEnter(GameObject go) {
        if (go.name != m_CurrentType) {
            m_CurrentScore = 0;
            m_CurrentType = go.name;
        } else {
            Punch(m_CurrentScoreDisplay.transform);
        }

        m_CurrentScore++;

        if (m_CurrentScore > m_HighScore) {
            m_HighType = m_CurrentType;
            m_HighScore = m_CurrentScore;
            Punch(m_HighScoreDisplay.transform);
        }

        UpdateDisplay();
    }

    public void OnObjectExit(GameObject go) {
        if (m_CurrentType == go.name) {
            m_CurrentScore = Math.Max(0, m_CurrentScore - 1);
        }

        UpdateDisplay();
    }

    private void Punch(Transform t) {
        t.DOKill();
        t.localScale = Vector3.one;
        t.DOPunchScale(Vector3.one*m_PunchScale, m_PunchDuration, m_PunchVibrato, m_PunchElasticity);
    }

    private void UpdateDisplay() {
        m_CurrentScoreDisplay.text = m_CurrentScore == 0 ? "" : $"{m_CurrentScore:N0} {m_CurrentType}" + (m_CurrentScore > 1 ? "s" : "");
        m_HighScoreDisplay.text = m_HighScore == 0 ? "" : $"{m_HighScore:N0} {m_HighType}" + (m_HighScore > 1 ? "s" : "");
    }
}