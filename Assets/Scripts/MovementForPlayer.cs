using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement: MonoBehaviour
{
  public float speed = 0;

  private Rigidbody rb;

  private float movementX;
  private float movementY;


  
    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody>();
    }
    public void OnMove (InputValue movementValue)
    {
        Vector2 movementVector = momentvalue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement*speed);
    }
}
