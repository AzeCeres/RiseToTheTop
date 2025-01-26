using System;
using UnityEngine;

public class MousePoint : MonoBehaviour
{
    private Camera camera;
    private Vector3 direction;
    private Input _input;
    [SerializeField] private Transform mousePos;
    private void Awake()
    {
        _input = GetComponent<Input>();
    }
    private void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void Update()
    {
        direction =  mousePos.position - transform.position;
        //if (_input.usedMouseLast)
        //{
        //    
        //}
        //else
        //{
        //    direction = transform.position - new Vector3(_input.lookVector.x, _input.lookVector.y, 0);
        //}
        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        
        
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, direction);
    }
}
