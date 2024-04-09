using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateControl : MonoBehaviour
{
Animator animator;
// Start is called before the first frame update
void Start()
{
animator = GetComponent<Animator>();
}

 // Update is called once per frame
 void Update()
 {
    bool Runforward = Input.GetKey("w");

    if (Runforward)
    {
    animator.SetBool("Runforward", true);
    }
    if (!Runforward)
    {
    animator.SetBool("Runforward", false);
    }




   }

}
