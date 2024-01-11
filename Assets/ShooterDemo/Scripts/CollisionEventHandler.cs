using UnityEngine;
using UnityEngine.Events;

public class CollisionEventHandler : MonoBehaviour
{

    [SerializeField] string tagType;
    public UnityEvent<Collision> onCollisionEnter, onCollisionStay, onCollisionExit;
    public UnityEvent<Collider> onTriggerEnter, onTriggerStay, onTriggerExit;
    private void Start()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (!tagType.Equals(collision.gameObject.tag)) return;
        // Call the OnCollisionEnter event.
        onCollisionEnter?.Invoke(collision);
    }

    void OnCollisionStay(Collision collision)
    {
        if (!tagType.Equals(collision.gameObject.tag)) return;
        // Call the OnCollisionStay event.
        onCollisionStay?.Invoke(collision);
    }

    void OnCollisionExit(Collision collision)
    {
        if (!tagType.Equals(collision.gameObject.tag)) return;
        // Call the OnCollisionExit event.
        onCollisionExit?.Invoke(collision);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (!tagType.Equals(collider.gameObject.tag)) return;
        // Call the OnTriggerEnter event.
        onTriggerEnter?.Invoke(collider);
    }

    void OnTriggerStay(Collider collider)
    {
        if (!tagType.Equals(collider.gameObject.tag)) return;
        // Call the OnTriggerStay event.
        onTriggerStay?.Invoke(collider);
    }

    void OnTriggerExit(Collider collider)
    {
        if (!tagType.Equals(collider.gameObject.tag)) return;
        // Call the OnTriggerExit event.
        onTriggerExit?.Invoke(collider);
    }
}
