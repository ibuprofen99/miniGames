using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    private Animator animator;
    float velZ = 0.0f;
    float velX = 0.0f;
    public float accel = 2.0f;
    public float decel = 2.0f;
    public float maxWalkVel = 0.5f;
    public float maxRunVel = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool forward = Input.GetKey(KeyCode.W);
        bool left = Input.GetKey(KeyCode.A);
        bool right = Input.GetKey(KeyCode.D);
        bool run = Input.GetKey(KeyCode.LeftShift);

        float currentMaxVel = run ? maxRunVel : maxWalkVel;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Jump");
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetTrigger("Crouch");
        }

        if (forward && velZ < currentMaxVel && !run)
        {
            velZ += Time.deltaTime * accel;
        }

        if (left && velX > -currentMaxVel && !run)
        {
            velX -= Time.deltaTime * accel;
        }

        if (right && velX < currentMaxVel && !run)
        {
            velX += Time.deltaTime * accel;
        }

        if (!forward && velZ > 0.0f)
        {
            velZ -= Time.deltaTime * decel;
        }

        if (!forward && velZ < 0.0f)
        {
            velZ = 0.0f;
        }

        if (!left && velX < 0.0f)
        {
            velX += Time.deltaTime * decel;
        }

        if (!right && velX > 0.0f)
        {
            velX -= Time.deltaTime * decel;
        }

        if (!left && !right && velX != 0.0f && (velX > -0.05f && velX < 0.05f))
        {
            velX = 0.0f;
        }

        // lock forward
        if (forward && run)
        {
            velZ = currentMaxVel;
        }
        else if (forward && velZ > currentMaxVel)
        {
            velZ -= Time.deltaTime * decel;

            if (velZ > currentMaxVel && velZ < (currentMaxVel + 0.05f))
            {
                velZ = currentMaxVel;
            }
        }
        else if (forward && velZ < currentMaxVel && velZ > (currentMaxVel - 0.05f))
        {
            velZ = currentMaxVel;
        }
        // lock left
        if (left && run)
        {
            velX = -currentMaxVel;
        }
        else if (left && velX < -currentMaxVel)
        {
            velX += Time.deltaTime * decel;

            if (velX < -currentMaxVel && velX < (-currentMaxVel - 0.05f))
            {
                velX = -currentMaxVel;
            }
        }
        else if (left && velX > -currentMaxVel && velX < (-currentMaxVel + 0.05f))
        {
            velX = -currentMaxVel;
        }
        // lock right
        if (right && run)
        {
            velX = currentMaxVel;
        }
        else if (right && velX > currentMaxVel)
        {
            velX -= Time.deltaTime * decel;

            if (velX > currentMaxVel && velX < (currentMaxVel + 0.05f))
            {
                velX = currentMaxVel;
            }
        }
        else if (right && velX < currentMaxVel && velX > (currentMaxVel - 0.05f))
        {
            velX = currentMaxVel;
        }

        animator.SetFloat("Velocity Z", velZ);
        animator.SetFloat("Velocity X", velX);
        
    }
}
