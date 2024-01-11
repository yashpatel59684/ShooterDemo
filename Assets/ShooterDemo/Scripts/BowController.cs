using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class BowController : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] Animator animator;
    [SerializeField] Transform projectileSpawnPos;
    [SerializeField] float force = 20f;
    [SerializeField] float burstSpeed=50f;
    private bool m_Charging;
    public void OnFire(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
            case InputActionPhase.Canceled:
                /*if (context.interaction is SlowTapInteraction)
                {
                    StartCoroutine(BurstFire((int)(burstSpeed)));
                }
                else
                {
                }*/
                m_Charging = false;
                if (context.phase.IsInProgress()) break;
                animator.SetBool("Default",true);
                animator.Play("Bow");
                Fire((int)((timeRemaining - (int)timeRemaining) * 100));
                timeRemaining = 1;
                break;

            case InputActionPhase.Started:
                if (context.interaction is SlowTapInteraction) m_Charging = true;
                timeRemaining = 0;
                animator.SetBool("Default",false);
                animator.Play("Bow Play");
                break;
        }
    }
    public void OnGUI()
    {
        if (m_Charging)
            GUI.Label(new Rect(100, 100, 200, 100), "Charging...");
    }
     float timeRemaining = 1;
    void Update()
    {
        if (timeRemaining < 1)
        {
            timeRemaining += Time.deltaTime;
        }
    }
    private void Fire(float givenForce=1)
    {
        givenForce /= 100;
        var transform = projectileSpawnPos;
        var newProjectile = Instantiate(projectile);
        newProjectile.transform.position = transform.position ;
        newProjectile.transform.rotation = transform.rotation;
        int size = 1;
        newProjectile.transform.localScale *= size;
        if (newProjectile.TryGetComponent(out Rigidbody rigidbody))
        {
            rigidbody.isKinematic = false;
            rigidbody.mass = Mathf.Pow(size, 3);
            Debug.Log(transform.forward * force * givenForce);
            rigidbody.AddForce(transform.forward * force * givenForce, ForceMode.Impulse);
        }
    }
/*    private IEnumerator BurstFire(int burstAmount)
    {
        for (var i = 0; i < burstAmount; ++i)
        {
            Fire();
            yield return new WaitForSeconds(0.1f);
        }
    }*/
}
