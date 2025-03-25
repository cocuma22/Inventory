using Unity.VisualScripting;
using UnityEngine;

/*
    This script provides jumping and movement in Unity 3D - Gatsby
*/

public class Player : MonoBehaviour
{
    Rigidbody _rb;
    public float moveSpeed = 5f;
    float _moveHorizontal;
    float _moveForward;

    [SerializeField] HealthManager _healthManager;
    [SerializeField] ShieldManager _shieldManager;
    [SerializeField] Vector3 _restartPosition;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
    }

    void Update()
    {
        _moveHorizontal = Input.GetAxisRaw("Horizontal");
        _moveForward = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector3 movement = (transform.right * _moveHorizontal + transform.forward * _moveForward).normalized;
        Vector3 targetVelocity = movement * moveSpeed;

        // apply movement to the Rigidbody
        Vector3 velocity = _rb.velocity;
        velocity.x = targetVelocity.x;
        velocity.z = targetVelocity.z;
        _rb.velocity = velocity;

        //when the player exits the platform, it loses one life (if the is no shield effect active)
        if (this.gameObject.transform.position.y < -20)
        {
            this.gameObject.transform.position = _restartPosition;

            if (!_shieldManager.isShieldEffectActive)
            {
                _healthManager.RemoveLife();
            }
        }
    }
}
