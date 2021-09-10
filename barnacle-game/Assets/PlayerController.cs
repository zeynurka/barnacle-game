using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
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

        charController.SimpleMove(direction.normalized * 5f); //bu metot ise içine yazdığı vector doğrultusunda hareket ettirmesi gerekiyor. Normal vektör yaptığımızda yanındaki 10 carpanı karakterin hızını gösteriyor. Bunu public bir değişkene atayıp inspectorden değiştirmek daha saglıklı o hale getirip uygun bir hız belirlemen gerekir animasyona göre
        //float speed;

        float angle = 0;
        if (joystick.Horizontal > 0)
        {
            angle = 90;
            angle -= 90 * joystick.Vertical;
        }
        else
        {
            angle = -90;
            angle += 90 * joystick.Vertical;
        }  

        Vector3 v = new Vector3(0, angle, 0);
        transform.localRotation = Quaternion.Euler(v);


    //transform.Rotate(new Vector3(joystick.Vertical, 0, joystick.Horizontal)); dediğim gibi bu bi tık düzeltirsek calısır ama sıkıntı cıkar bir npc (bu oyunlardaki vatandas yapay zeka, hyper casual dan örneklerde önümüzde sag sol yapan bir karakter olsaydı belki root motion kullanılabilirdi) için kullanabilirsin belki

    //transform.Rotate(0, yAxis, 0);


    //burada falling - dying geçişini nasıl kontrol edebilirim? !!: Belirli bir süre gectikten sonra hala falling ise bunu true yapabilirsin
    /*
    keys:
        StartCoroutine();
        IEnumerator metotadi(istersenparametre)
        {
            //blabla
            yield return WaitForSeconds(süre);
        }
    bunlar ile belirli bir sürenin gectigini kontrol edebiliyorsun
    */


        //if ()
        //{
        //    animator.SetBool("dying",true);
        //}

    }
   
    /// <summary>
    /// Character controller varsa onun colliderinin carpısmasını tetiklemek için bu metot kullanılıyor. istersen bunu karıstırmayın collider ekle kafan karısmasın. sorun cıkarsa bu metota geri gecersin cok bir farkı yok.
    /// </summary>
    /// <param name="hit"></param>
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log(hit.gameObject.name);
        if (hit.gameObject.tag == "Enemy")
        {
            animator.SetBool("falling", true);
        }
        else
        {
            animator.SetBool("falling", false);
        }
    }
    //çarpışma kontrolü burada yazdığım gibi çalışmıyor(cevabı yukarda) koşula uymadan direkt fallinge geçiyor /// burası için ekstra sildigin capsule collideri tekrar eklersen calısır.
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
