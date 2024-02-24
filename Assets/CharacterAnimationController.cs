using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CharacterAnimationController : MonoBehaviour
{
    private Animator _animator;
    private NavMeshAgent _navMeshAgent;

    [SerializeField] private float animationSpeedMultiplier = 3.0f;
    [SerializeField] private int _hP = 3;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _navMeshAgent = GetComponentInParent<NavMeshAgent>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
           
            TakeDamage(1);
        }

        if (_navMeshAgent != null)
        {
            float speed = _navMeshAgent.velocity.magnitude;
            SetSpeed(speed);
        }
        
        _animator.SetInteger("HP", _hP);
    }

    public void SetSpeed(float speed)
    {
        _animator.SetFloat("Velocity", speed * animationSpeedMultiplier);
        
    }

    public void Jump()
    {
        
    }

    public void CharacterHit()
    {

            _animator.SetTrigger("Hit");
        
    }

    private void TakeDamage(int damage)
    {
        
        _hP -= damage;
        
        CharacterHit();
    }
}