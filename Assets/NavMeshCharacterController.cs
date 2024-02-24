using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public enum DamageSource
{
    Arrow,
    Lava,
    FallDamage,
    Misc
}

[System.Serializable]
public struct DamageEventData
{
    public DamageSource damageSource;
    public int damage;
    public IDamageable damagedEntity;

    public DamageEventData(DamageSource source, int damage, IDamageable entity)
    {
        damageSource = source;
        this.damage = damage; 
        damagedEntity = entity;
    }
}

public interface IDamageable
{
    public void TakeDamage(DamageEventData eventData);
}

[DisallowMultipleComponent]
public class NavMeshCharacterController : MonoBehaviour, IDamageable
{
    [SerializeField] private bool isHuman = true;
    private int HP = 3;

    public UnityAction<int> onDamaged; //connect with the animation controller
    public UnityAction<float> onMove;
    public UnityEvent onDeath;


    private NavMeshAgent _agent;

    void Start()
    {
        EventManager.Instance.damageEvent += TakeDamage;


        _agent = GetComponent<NavMeshAgent>();
        hit = new RaycastHit();
    }

    RaycastHit hit;


    void Update()
    {
        if (HP > 0)
        {
            if (Input.GetMouseButton(0) && isHuman || Input.GetMouseButton(1) && !isHuman)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray.origin, ray.direction, out hit))
                    _agent.destination = hit.point;
            }
            onMove?.Invoke(_agent.velocity.magnitude);
        }
    }

    public void TakeDamage(DamageEventData eventData)
    {
        if (eventData.damagedEntity == (IDamageable)this)
        {
            HP -= eventData.damage;
            onDamaged.Invoke(HP);
            _agent.ResetPath();
            if (HP <= 0)
            {
                onDeath?.Invoke();
            }
        }
    }
}
