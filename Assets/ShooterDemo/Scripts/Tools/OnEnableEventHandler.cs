using UnityEngine;
using UnityEngine.Events;

public class OnEnableEventHandler : MonoBehaviour
{
    [SerializeField] UnityEvent unityEvent;
    private void OnEnable()
    {
        unityEvent?.Invoke();
    }
}
