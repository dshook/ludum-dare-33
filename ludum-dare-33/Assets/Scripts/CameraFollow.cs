using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float smoothing = 5f;

    Transform cameraTransform;
    Vector3 offset = new Vector3(0, 0, -10);

    void Start()
    {
        cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    void Update()
    {
        Vector3 targetCamPos = transform.position + offset;
        cameraTransform.position = Vector3.Lerp(cameraTransform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
