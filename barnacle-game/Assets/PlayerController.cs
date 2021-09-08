using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{

    Animator animator;
    Joystick joystick;//Bu ne inspector tarafından ne kod tarafından tanımlanıyor. Bu tanımlı olmadığı için xAxis yAxis cekemiyor. 

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetBool("walking", true);// update sürekli calıstığı için bunu böyle yazmak doğru değil

        float xAxis = joystick.Horizontal;
        float yAxis = joystick.Vertical;
        Vector3 direction = new Vector3(xAxis, 0f, yAxis).normalized;//joystick tanımlanırsa direction gelir ama bu sadece hareket etmesi gereken yönün vector3 değeridir. Bu değere göre hareket ettirmen gerek karakteri. keys: transform.translate veya character controller componenti (simplemove metoduyla birlikte)

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
