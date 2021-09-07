using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //çalışıp çalışmadığını kontrol etmek için
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("Falling");
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        bool fire = Input.GetButtonDown("Fire1");

        animator.SetFloat("Forward", v);
        animator.SetFloat("Strafe", h);
        animator.SetBool("Fire", fire);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            animator.SetTrigger("Falling");
        }
    }
}
