using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    public NavMeshAgent Agent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit ray;
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(camRay.origin, camRay.direction, out ray, 1000f))
            {
                if (ray.transform)
                {
                    if (ray.transform.gameObject.layer == LayerMask.NameToLayer("Floor"))
                    {
                        Agent.SetDestination(ray.point);
                    }
                }
            }
        }
    }
}
