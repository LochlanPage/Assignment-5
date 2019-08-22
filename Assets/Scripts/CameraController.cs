using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    float Speed = 0.5f;

    [SerializeField]
    Vector3 minPos;

    [SerializeField]
    Vector3 maxPos;

    void Update()
    {
        float xAxisValue = Input.GetAxis("Horizontal") * Speed;
        float zAxisValue = Input.GetAxis("Vertical") * Speed;

        transform.position = new Vector3(transform.position.x + xAxisValue, transform.position.y, transform.position.z + zAxisValue);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minPos.x, maxPos.x),
        Mathf.Clamp(transform.position.y, minPos.y, maxPos.y),
        Mathf.Clamp(transform.position.z, minPos.z, maxPos.z));
    }
    // Ask about how to implement acceleration...
}