using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Player_Movement : MonoBehaviour
{
    public float speed = 0;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public Button Respawn;
    public GameObject winTextObject;

    // Start is called before the first frame update
    void Start()
    {
        Respawn.gameObject.SetActive(false);
        rb = GetComponent<Rigidbody>();
        winTextObject.SetActive(false);

    }
    public void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerKiller"))
        {
            Respawn.gameObject.SetActive(true);
            speed = 0;
        }

        if (other.gameObject.CompareTag("slow"))
        {
            rb.drag = 10;
        }

        if (other.gameObject.CompareTag("NextLevel"))
        {
            int y = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(y + 1);
        }
        if (other.gameObject.CompareTag("Finish"))
        {
          winTextObject.SetActive(true);
        }
    }
    public void respwan()
    {
        transform.position = Vector3.zero;
        speed = 20;
        Respawn.gameObject.SetActive(false);
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("slow"))
        {
            rb.drag = 3;

        }
    }
}
