using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    //private LevelManager levelScript; /* ref to levelManager which will set up level */ 
    private int level;
    private int score;
    private int health; 
    private GameObject[] inventory;

    private void Awake()
    {
        if (instance = null) instance = this;
        else if (instance != null) Destroy(gameObject);

        DontDestroyOnLoad(gameObject); /* sets this not to be destroyed when reloading scene */
                                       // levelScript = GetComponet<BoardManager>(); 

        InitGame(); 
    }

    void InitGame() 
    { 
        //levelScript.SetupScene(level, score, health, inventory);
    }

}
