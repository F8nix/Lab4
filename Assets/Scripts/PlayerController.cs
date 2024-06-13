using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public float speed = 5f;
  public float mouseSensitivity = 1f;
  public new Transform camera;
  public bool showCursor = false;
  public float jumpForce = 5f;
  Rigidbody rb;
  // Start is called before the first frame update
  void Start()
  {
    rb = GetComponent<Rigidbody>();
  }

  // Update is called once per frame
  void Update()
  {
    HandleCursor();
    Jump();
    CameraNPlayerMovement();
  }

  private void CameraNPlayerMovement()
  {
    var horizontal = Input.GetAxis("Horizontal");
    var vertical = Input.GetAxis("Vertical");
    transform.Translate(speed * Time.deltaTime * new Vector3(horizontal, 0, vertical));

    var mouseX = Input.GetAxis("Mouse X");
    var mouseY = Input.GetAxis("Mouse Y");

    transform.Rotate(Vector3.up, mouseX * mouseSensitivity);
    camera.transform.Rotate(Vector3.right, -mouseY * mouseSensitivity);
    //no camera clamp implemented - could be upside down
  }

  void HandleCursor()
  {
    if (showCursor)
    {
      Cursor.visible = true;
      Cursor.lockState = CursorLockMode.None;
    }
    else
    {
      Cursor.visible = false;
      Cursor.lockState = CursorLockMode.Locked;
    }
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      showCursor = !showCursor;
    }
  }

  void Jump()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
  }
}
