using UnityEngine;

public class Spawner : MonoBehaviour {
    [SerializeField] private float m_SpawnDelay = 0.5f;
    [SerializeField] private float m_SpawnOffset = 3;
    [SerializeField] private GameObject[] m_Items;

    private float m_NextSpawn;
    private int m_NextIndex;
    private Transform m_Transform;

    private void Start() {
        m_NextSpawn = Time.time + m_SpawnDelay;
        m_Transform = transform;
    }

    private void Update() {
        if (Time.time < m_NextSpawn) {
            return;
        }

        float offset = Random.Range(-m_SpawnOffset, m_SpawnOffset);
        GameObject prefab = m_Items[m_NextIndex];
        GameObject instance = Instantiate(prefab, m_Transform.position + Vector3.left*offset, m_Transform.rotation);
        instance.name = prefab.name;
        m_NextSpawn = Time.time + m_SpawnDelay;
        m_NextIndex = GetNextIndex(m_NextIndex, m_Items.Length);
    }

    private static int GetNextIndex(int current, int length) {
        current++;
        return current >= length ? 0 : current;
    }
}