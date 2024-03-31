using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InputController : MonoBehaviour
{
    public NavMeshAgent Agent;
    public Dictionary<KeyCode, Action> InputActionMaps = new ();

    private void Awake()
    {
        LoadDefaultInputSettings();
    }
    
    void Update()
    {
        InputCheck();
    }
    
    private void InputCheck()
    {
        foreach (var pair in InputActionMaps)
        {
            if (Input.GetKeyDown(pair.Key))
            {
                pair.Value.Invoke();
            }
        }
    }

    private void LoadDefaultInputSettings()
    {
        InputActionMaps.Add(KeyCode.Mouse1,MoveToMousePosition);
        InputActionMaps.Add(KeyCode.Q,()=>Debug.Log("Skill1 ==> Q"));
        InputActionMaps.Add(KeyCode.W,()=>Debug.Log("Skill2 ==> W"));
        InputActionMaps.Add(KeyCode.E,()=>Debug.Log("Skill3 ==> E"));
        InputActionMaps.Add(KeyCode.R,()=>Debug.Log("Skill4 ==> R"));
        InputActionMaps.Add(KeyCode.T,()=>Debug.Log("Skill5 ==> T"));
        InputActionMaps.Add(KeyCode.Alpha1,()=>Debug.Log("Util1 ==> 1"));
        InputActionMaps.Add(KeyCode.Alpha2,()=>Debug.Log("Util2 ==> 2"));
        InputActionMaps.Add(KeyCode.Alpha3,()=>Debug.Log("Util3 ==> 3"));
        InputActionMaps.Add(KeyCode.Alpha4,()=>Debug.Log("Util4 ==> 4"));
        InputActionMaps.Add(KeyCode.Alpha5,()=>Debug.Log("Util5 ==> 5"));
        InputActionMaps.Add(KeyCode.Tab,()=>Debug.Log("Minimap ==> Tab"));
        InputActionMaps.Add(KeyCode.C,()=>Debug.Log("PlayerStats ==> C"));
        InputActionMaps.Add(KeyCode.I,()=>Debug.Log("Inventory ==> I"));
        InputActionMaps.Add(KeyCode.P,()=>Debug.Log("Portal ==> P"));
        InputActionMaps.Add(KeyCode.Escape,()=>Debug.Log("Quit ==> Escape"));
    }
    
    private void MoveToMousePosition()
    {
        RaycastHit ray;
        var camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
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
