using UnityEngine;

public class FollowCursor : MonoBehaviour {
    [SerializeField] private Camera m_Camera;
    [SerializeField] private Rigidbody2D m_Rigidbody2D;

    private void Update() {
        Vector3 positon = m_Camera.ScreenToWorldPoint(Input.mousePosition);
        positon.Scale(new Vector3(1, 1, 0));
        m_Rigidbody2D.MovePosition(positon);
    }
}