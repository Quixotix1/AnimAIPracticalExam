using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform camAnchor;
    public Animator playerAnimator;

    public float speed;

    private void Start()
    {
        if (playerAnimator == null)
            playerAnimator = GetComponent<Animator>();
    }

    private bool canJump = false;

    private float jumpTime = 0f;

    private void Update()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");

        Vector3 forward = Vector3.Normalize(new Vector3(camAnchor.transform.forward.x, 0f, camAnchor.transform.forward.z));
        Vector3 right = Vector3.Normalize(new Vector3(camAnchor.transform.right.x, 0f, camAnchor.transform.right.z));

        Vector3 motion = forward * vertical + right * horizontal;

        playerAnimator.SetBool("Walking", motion != Vector3.zero);
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (!playerAnimator.GetBool("Crouching")) playerAnimator.SetTrigger("StartCrouch");
            playerAnimator.SetBool("Crouching", !playerAnimator.GetBool("Crouching"));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canJump) playerAnimator.SetBool("Jumping", true);
        }
        if (playerAnimator.GetBool("Jumping")) jumpTime += Time.deltaTime;
        if (jumpTime > 3f) playerAnimator.SetBool("Jumping", false);

        transform.position += motion * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "JumpArea") canJump = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "JumpArea") canJump = false;
    }
}

