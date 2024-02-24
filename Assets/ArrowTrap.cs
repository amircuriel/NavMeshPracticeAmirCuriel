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
            Arrow arrow = Instantiate(Arrow, transform.position, Quaternion.Inverse(transform.localRotation)).AddComponent<Arrow>();
            arrow.DamageEventData = new DamageEventData(DamageSource.Arrow, Damage, idamageable);
        }
    }
}

public class Arrow : MonoBehaviour
{
    public DamageEventData DamageEventData;
    public float arrowSpeed = 7f;
    private bool hasHit = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * Time.deltaTime * arrowSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamageable idamageable = collision.gameObject.GetComponent<IDamageable>();
        if (idamageable != null)
        {
            if (!hasHit)
            {
                EventManager.Instance.EntityDamaged(DamageEventData);
            }
            hasHit = true;
        }
        Destroy(this.gameObject);
    }
}
