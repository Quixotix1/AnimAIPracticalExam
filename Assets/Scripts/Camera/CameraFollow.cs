using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    private void Start()
    {
        if (target == null)
        {
            Debug.LogWarning("Camera target was not properly initialized.");
            target = FindAnyObjectByType<PlayerLook>().transform;
        }
    }

    private void LateUpdate()
    {
        transform.position = target.position;
        transform.rotation = target.rotation;
    }
}