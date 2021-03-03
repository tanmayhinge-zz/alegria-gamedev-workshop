using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    public static GameManager instance;
    public Vector2 playerIntialPosition;
    private GameObject enemies;
    private GameObject player;
    void Awake(){
    
    	if(instance == null){
    		instance = this;
    	}
    	
    	Time.timeScale = 1f;
    }

    void Start()
    {
        enemies = GameObject.FindGameObjectWithTag("Enemy");
        player = GameObject.FindWithTag("Player");
    }
	
    public void PlayerWin(){
    
    	Time.timeScale = 0;
    	StartCoroutine(RestartGame());
    
    }
    public void PlayerDied(){
    	
    	Time.timeScale = 0;
    	StartCoroutine(RestartGame());
    
    }
    
    IEnumerator RestartGame(){
    	yield return new WaitForSecondsRealtime(2f);
    	UnityEngine.SceneManagement.SceneManager.LoadScene(
    	UnityEngine.SceneManagement.SceneManager.GetActiveScene().name); 	
    	 
    
    }
}
