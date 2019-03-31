using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    private GameObject player;
    private Vector3 offsetPosition;
    private Quaternion playerRot;

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        offsetPosition = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(1))
        {
            playerRot = player.transform.rotation;
            offsetUpdate();
            transform.position = player.transform.position + offsetPosition;
            transform.rotation = Quaternion.Euler(20, playerRot.eulerAngles.y, 0);           
        }
        else
        {
            transform.position = player.transform.position + offsetPosition;
        }
    }

    private void offsetUpdate() 
    {
        float z = -(Mathf.Cos(playerRot.eulerAngles.y * Mathf.Deg2Rad) * 3.5f);
        float x = -(Mathf.Sin(playerRot.eulerAngles.y * Mathf.Deg2Rad) * 3.5f);

        offsetPosition = new Vector3(x, 3.5f, z);
    }
   
}
