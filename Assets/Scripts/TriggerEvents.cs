using UnityEngine;
using UnityEngine.Events;

public class TriggerEvents : MonoBehaviour {
    public UnityEvent<GameObject> OnEnter;
    public UnityEvent<GameObject> OnExit;

    private void OnTriggerEnter2D(Collider2D other) {
        OnEnter.Invoke(other.gameObject);
    }

    private void OnTriggerExit2D(Collider2D other) {
        OnExit.Invoke(other.gameObject);
    }
}