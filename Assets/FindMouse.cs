using UnityEngine;

public class FindMouse : MonoBehaviour
{
    private Camera camera;
    private Input _input;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _input = GameObject.FindGameObjectWithTag("Player").GetComponent<Input>();
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = camera.ScreenToWorldPoint(new Vector3(_input.lookVector.x, _input.lookVector.y, 10));
    }
}
