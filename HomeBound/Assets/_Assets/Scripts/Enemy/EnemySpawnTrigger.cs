using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnTrigger : MonoBehaviour
{
    public GameObject enemy;
    public EnemySpawnPoint spawnPoint;
    //future capacity for multiple to spawn

    private void OnTriggerEnter( Collider col )
    {
         if(col.gameObject.tag == "Player")
        {
            Vector3 position = spawnPoint.transform.position;
            Quaternion rotation = spawnPoint.transform.rotation;

            Instantiate(enemy, position, rotation);

            Destroy(this.gameObject);
        }
    }
}
