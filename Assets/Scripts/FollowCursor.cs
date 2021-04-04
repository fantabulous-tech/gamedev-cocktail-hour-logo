using UnityEngine;

public class FollowCursor : MonoBehaviour {
    [SerializeField] private Camera m_Camera;
    [SerializeField] private Rigidbody2D m_Rigidbody2D;

    private void Start() {
        Cursor.visible = false;
    }

    private void Update() {
        Vector3 position = m_Camera.ScreenToWorldPoint(Input.mousePosition);
        position.Scale(new Vector3(1, 1, 0));
        m_Rigidbody2D.MovePosition(position);
    }
}