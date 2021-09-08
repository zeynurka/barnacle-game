using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{

    Animator animator;
    Joystick joystick;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetBool("walking", true);

        float xAxis = joystick.Horizontal;
        float yAxis = joystick.Vertical;
        Vector3 direction = new Vector3(xAxis, 0f, yAxis).normalized;

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            animator.SetBool("falling", true);
        }
        else
        {
            animator.SetBool("falling", false);
        }
    }


}
