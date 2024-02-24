using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    public int Damage = 1;
    public GameObject Arrow;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamageable idamageable = other.gameObject.GetComponent<IDamageable>();
        if (idamageable != null)
        {
            Vector3 direction = other.transform.position - transform.position;
            Arrow arrow = Instantiate(Arrow, Vector3.zero, transform.rotation, transform).AddComponent<Arrow>();
            arrow.DamageEventData = new DamageEventData(DamageSource.Arrow, Damage, idamageable);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}

public class Arrow : MonoBehaviour
{
    public DamageEventData DamageEventData;
    public float arrowSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * Time.deltaTime * arrowSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamageable idamageable = collision.gameObject.GetComponent<IDamageable>();
        if (idamageable != null)
        {
            EventManager.Instance.EntityDamaged(DamageEventData);
        }
        Destroy(this);
    }
}
