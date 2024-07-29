using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Wood : MonoBehaviour
{
    public float Speed;

    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        _transform.Rotate(0,0,Speed*Time.deltaTime);   
    }
}
