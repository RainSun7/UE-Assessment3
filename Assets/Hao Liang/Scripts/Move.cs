using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Move : MonoBehaviour
{

    private Rigidbody rb;
    private int count;
    public float moveSpeed = 5f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;

        if (moveDirection.magnitude > 1f)
        {
            moveDirection.Normalize();
        }

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.Self);
    }

    public TextMeshProUGUI countText;

    public GameObject winTextObject;

    void Start()
       {
        rb = GetComponent<Rigidbody>();

        count = 0;

        SetCountText();

        winTextObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
        {
     // Check if the object the player collided with has the "PickUp" tag.
     if (other.gameObject.CompareTag("PickUp"))
            {
     // Deactivate the collided object (making it disappear).
                other.gameObject.SetActive(false);

                count = count + 1;

                SetCountText();

            }    
        }
        void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

 if (count >= 5)
        {
            winTextObject.SetActive(true);
        }
    }
}



