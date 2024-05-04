using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewController : MonoBehaviour
{
    //public CharacterControllerScrewGame CCSG; // Reference the CharacterControllerScrewGame script
    private Animator animator;
    private bool isJumping = false;
    private bool isCrouching = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            animator.SetBool("Jump", true);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && !isCrouching)
        {
            isCrouching = true;
            animator.SetBool("Crouch", true);
        }
    }

    // You might want to reset the bools when the keys are released
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = false;
            animator.SetBool("Jump", false);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCrouching = false;
            animator.SetBool("Crouch", false);
        }
    }
}
