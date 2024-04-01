using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public CharacterInfo PlayerInfo;
    public Equipments Equipments;
    public Inventory Inventory;
    public Skills Skills;

    public GameObject PlayerGO;
    public InputController Controller;

    private Vector3 LastPos;
    private void Awake()
    {
        
    }

    private void Start()
    {
        
    }


    private void FixedUpdate()
    {
        UpdateSpeed();
    }

    private void UpdateSpeed()
    {
        var currentPos = transform.position;
        Controller.Animator.SetFloat("MoveSpeed",Vector3.Magnitude(currentPos - LastPos));
        LastPos = currentPos;
    }


}