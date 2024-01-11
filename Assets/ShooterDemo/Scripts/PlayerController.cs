using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;
    [SerializeField] Transform camTransform;
    private Vector3 m_Rotation;
    private Vector3 m_Look;
    private Vector3 m_Move;
    public void OnMove(InputAction.CallbackContext context)
    {
        m_Move = context.ReadValue<Vector2>();
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        m_Look = context.ReadValue<Vector2>();
    }
    public void Update()
    {
        Look(m_Look);
        Move(m_Move);
    }
    private void Move(Vector2 direction)
    {
        if (direction.sqrMagnitude < 0.01) return;
        var scaledMoveSpeed = moveSpeed * Time.deltaTime;
        var move = Quaternion.Euler(0, transform.eulerAngles.y, 0) * new Vector3(direction.x, 0, direction.y);
        transform.position += move * scaledMoveSpeed;
    }
    private void Look(Vector2 rotate)
    {
        if (rotate.sqrMagnitude < 0.01) return;
        var scaledRotateSpeed = rotateSpeed * Time.deltaTime;
        m_Rotation.y += rotate.x * scaledRotateSpeed;
        m_Rotation.x = Mathf.Clamp(m_Rotation.x - rotate.y * scaledRotateSpeed, -89, 89);
        transform.localEulerAngles = new Vector3(0, m_Rotation.y, 0);
        camTransform.localEulerAngles = new Vector3(m_Rotation.x, 0, m_Rotation.z);
    }
}
