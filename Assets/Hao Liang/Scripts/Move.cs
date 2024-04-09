using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Move : MonoBehaviour
{

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

    void OnTriggerEnter(Collider other)
        {
     // Check if the object the player collided with has the "PickUp" tag.
     if (other.gameObject.CompareTag("PickUp"))
            {
     // Deactivate the collided object (making it disappear).
                other.gameObject.SetActive(false);

            }

           
        }

       



}

