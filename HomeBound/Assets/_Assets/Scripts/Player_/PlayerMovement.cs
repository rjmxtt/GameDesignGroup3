using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    Animator anim;

    //Rotation 
    Vector2 positionOnScreen;
    Vector2 mouseOnScreen;
    Quaternion targetRotation;

    void Start()
    {
        anim = GameObject.FindWithTag("Player").GetComponent<Animator>();
        anim.SetBool("idle", true); 
    }

    void Update()
    {
        // Foward translate
        transform.eulerAngles = new Vector3(0, Camera.main.transform.eulerAngles.y, 0);

        if (Input.GetKey("w"))
        {    
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.position += transform.TransformDirection(targetRotation * Vector3.forward) * Time.deltaTime * movementSpeed * 2.5f;
                anim.SetBool("run", true);
            } 
            else 
            {
                anim.SetBool("run", false);
            }

            transform.position += transform.TransformDirection(targetRotation * Vector3.forward) * Time.deltaTime * movementSpeed;
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
            anim.SetBool("run", false);
        }


        // Non-forward translate 
        if (Input.GetKey("s"))
        {
            transform.position -= transform.TransformDirection(targetRotation * Vector3.forward) * Time.deltaTime * movementSpeed;
            anim.SetBool("walk", true);
        }
        if (Input.GetKey("a"))
        {
            transform.position += transform.TransformDirection(targetRotation * Vector3.left) * Time.deltaTime * movementSpeed;
            anim.SetBool("walk", true);
        }
        if (Input.GetKey("d"))
        {
            transform.position -= transform.TransformDirection(targetRotation * Vector3.left) * Time.deltaTime * movementSpeed;
            anim.SetBool("walk", true);
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //GetComponent<Rigidbody>().AddForce(Vector3.up * 300);
            anim.SetTrigger("jump");
        }

        // Rotate - point to curser
        positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
        targetRotation = Quaternion.Euler(new Vector3(0f, -angle, 0f));
        transform.rotation = targetRotation;
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b) 
    {
        return ((Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg) + 90);
    }

    public Quaternion getRotation()
    {
        return targetRotation;
    }
}
