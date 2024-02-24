using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CharacterAnimationController : MonoBehaviour
{
    private Animator _animator;
    private NavMeshAgent _navMeshAgent;
    private NavMeshCharacterController _characterController;

    [SerializeField] private float animationSpeedMultiplier = 3.0f;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _navMeshAgent = GetComponentInParent<NavMeshAgent>();
        _characterController = GetComponent<NavMeshCharacterController>();
        _characterController.onMove += SetSpeed;
        _characterController.onDamaged += CharacterHit;
    }

    public void SetSpeed(float speed)
    {
        _animator.SetFloat("Velocity", speed * animationSpeedMultiplier);
    }

    public void CharacterHit(int remainingHP)
    {
        _animator.SetTrigger("Hit");
        _animator.SetInteger("HP", remainingHP);
    }
}