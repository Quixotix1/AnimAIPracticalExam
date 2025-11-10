using UnityEngine;

public class CameraLookAtObj : MonoBehaviour
{
    public Transform obj;

    void Update()
    {
        if (obj != null)
        {
            Vector3 dir = (obj.position - transform.position).normalized;


            transform.forward = dir;
        }
    }
}
