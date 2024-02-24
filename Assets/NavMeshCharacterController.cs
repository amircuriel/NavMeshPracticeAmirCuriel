using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class NavMeshCharacterController : MonoBehaviour
{
    [SerializeField] CharacterAnimationController animationController;
    [SerializeField] private bool isHuman = true;
    [SerializeField] private Transform finishLine;
    [SerializeField] private TMPro.TMP_Text winText;

    public int HP { get; set; }
    public int HP { get; set; }




    private NavMeshAgent _agent;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        hit = new RaycastHit();
    }

    RaycastHit hit;


    void Update()
    {
        if (Input.GetMouseButton(0) && isHuman || Input.GetMouseButton(1) && !isHuman)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hit))
                _agent.destination = hit.point;
        }

        animationController.SetSpeed(_agent.velocity.magnitude);

        if (Vector3.Distance(transform.position, finishLine.position) < 0.6f)
        {
            winText.gameObject.SetActive(true);
        }
    }


}
