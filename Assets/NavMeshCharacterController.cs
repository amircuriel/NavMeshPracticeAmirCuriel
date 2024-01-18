using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshCharacterController : MonoBehaviour
{
    [SerializeField] private bool isHuman = true;
    [SerializeField] private Transform finishLine;
    [SerializeField] private TMPro.TMP_Text winText;
    private NavMeshAgent _agent;
    private Animator _animator;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        if (isHuman)
        {
            _animator = GetComponent<Animator>();
        }
        hit = new RaycastHit();
    }

    RaycastHit hit;


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isHuman || Input.GetMouseButtonDown(1) && !isHuman)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hit))
                _agent.destination = hit.point;
        }

        if (isHuman)
        {
            _animator.SetFloat("Speed", _agent.velocity.magnitude);
        }

        if (Vector3.Distance(transform.position, finishLine.position) < 0.6f)
        {
            winText.gameObject.SetActive(true);
        }
    }
}
