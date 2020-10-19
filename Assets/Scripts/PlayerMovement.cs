using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody playerRB;

    public float moveSpeed;

    private Vector2 moveInput;
    private Vector2 mouseInput;

    public float mouseSensitivity = 1f;

    public Transform viewCam;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Player Movement
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector3 horizontalMovement = transform.up * -moveInput.x;

        Vector3 verticalMovement = transform.right * -moveInput.y;

        playerRB.velocity = (horizontalMovement + verticalMovement) * moveSpeed;

        // Player mouse look
        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y") * mouseSensitivity);

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z + mouseInput.x);

        viewCam.localRotation = Quaternion.Euler(viewCam.localRotation.eulerAngles + new Vector3(0f, mouseInput.y, 0f));
    }
}
