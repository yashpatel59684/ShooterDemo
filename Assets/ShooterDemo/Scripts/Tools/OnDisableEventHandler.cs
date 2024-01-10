using UnityEngine;
using UnityEngine.Events;

public class OnDisableEventHandler : MonoBehaviour
{
    [SerializeField] UnityEvent unityEvent;
    private void OnDisable()
    {
        unityEvent?.Invoke();
    }
}
