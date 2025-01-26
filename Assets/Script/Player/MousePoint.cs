using System;
using UnityEngine;

public class MousePoint : MonoBehaviour
{
    private Camera camera;
    private Vector3 mousePos;

    private void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void Update()
    {
        mousePos = camera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
