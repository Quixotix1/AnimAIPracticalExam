using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private bool m_EnableDebug;
    [SerializeField] private GameObject m_Player;

    [SerializeField] private float m_HitAngle;

    private void Start()
    {
        if (m_HitAngle < 0f)
        {
            Debug.LogWarning("Hit angle cannot be negative.");
            m_HitAngle = Mathf.Abs(m_HitAngle);
        }
        if (m_HitAngle == 0f)
        {
            Debug.LogWarning("Hit angle is not set.");

            TryGetComponent(out Light playerLight);
            if (playerLight != null)
                m_HitAngle = playerLight.spotAngle / 2f;
        }

        if (m_Player == null)
            Debug.Log("I hate unity and i hate everything.");
    }

    void Update()
    {
        Vector3 target = m_Player.transform.position;
        target.y += 1;

        Physics.Raycast(transform.position, target - transform.position, out RaycastHit hitInfo);

        if (m_EnableDebug)
        {
            if (hitInfo.transform == null)
                Debug.Log("I can see the player! (ignore the error message :) )");
            if (hitInfo.transform.gameObject == m_Player)
                Debug.DrawRay(transform.position, target - transform.position, Color.red);
            else
                Debug.DrawRay(transform.position, target - transform.position);
        }
    }
}
