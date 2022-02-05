using UnityEngine;

public class cameraController : MonoBehaviour
{
    private Transform target;
    private Vector3 offset;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("CameraPos").transform;
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        target = GameObject.FindGameObjectWithTag("CameraPos").transform;
        Vector3 newPosition = new Vector3(target.position.x, target.position.y, offset.z + target.position.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, 0.6f);
    }
}