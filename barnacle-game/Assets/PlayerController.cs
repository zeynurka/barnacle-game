using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{

    Animator animator;
    Joystick joystick;
    CharacterController charController;
    void Start()
    {
        charController = GetComponent<CharacterController>();//getcomponent scriptin calıstığı objede var olduğuna emin olduğun componentleri cekmek ve scripteki değişkene atamak için kullanılıyor. Olduğuna emin olmadığın componentler için farklı bir metot var o dursun şimdilik charcontroller olduğuna eminiz
        joystick = FindObjectOfType<Joystick>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        float xAxis = joystick.Horizontal;//joystick x ekseninde ne kadar hareket ediyor (tam hatırlamıyorum -1 1 arası değer dönüyordu sanırım)
        float yAxis = joystick.Vertical;//joystick y ekseninde ne kadar hareket ediyor
        Vector3 direction = new Vector3(xAxis, 0f, yAxis).normalized;//Bu joystick hareketini bir doğru olarak alıp onu bilinen fizikte bir vektörün normalini almayı otomatik yapan .normalized işlemine tutuyoruz.
        Debug.Log(direction);
        //transform.Rotate(new Vector3(joystick.Vertical, 0, joystick.Horizontal)); dediğim gibi bu bi tık düzeltirsek calısır ama sıkıntı cıkar bir npc (bu oyunlardaki vatandas yapay zeka, hyper casual dan örneklerde önümüzde sag sol yapan bir karakter olsaydı belki root motion kullanılabilirdi) için kullanabilirsin belki

        charController.SimpleMove(direction.normalized * 10f);//bu metot ise içine yazdığı vector doğrultusunda hareket ettirmesi gerekiyor. Normal vektör yaptığımızda yanındaki 10 carpanı karakterin hızını gösteriyor. Bunu public bir değişkene atayıp inspectorden değiştirmek daha saglıklı o hale getirip uygun bir hız belirlemen gerekir animasyona göre
        

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
