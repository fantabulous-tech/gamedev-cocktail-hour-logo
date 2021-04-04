using UnityEngine;

public class Spawner : MonoBehaviour {
    [SerializeField] private GameObject[] m_Items;
    [SerializeField] private float m_Delay = 0.5f;
    [SerializeField] private float m_SpawnOffset = 1;

    private float m_NextSpawn;
    private int m_NextIndex;
    private Transform m_Transform;

    private void Start() {
        m_NextSpawn = Time.time + m_Delay;
        m_Transform = transform;
    }

    private void Update() {
        if (Time.time < m_NextSpawn) {
            return;
        }

        float offset = Random.Range(-m_SpawnOffset, m_SpawnOffset);
        Destroy(Instantiate(m_Items[m_NextIndex], m_Transform.position + Vector3.left*offset, m_Transform.rotation), 20);
        m_NextSpawn = Time.time + m_Delay;
        m_NextIndex = GetNextIndex(m_NextIndex, m_Items.Length);
    }

    private static int GetNextIndex(int current, int length) {
        current++;

        if (current >= length) {
            current = 0;
        }

        return current;
    }
}