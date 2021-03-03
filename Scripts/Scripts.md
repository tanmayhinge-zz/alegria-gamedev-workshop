## Android Game Scripts

1.Enemy.cs

```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float moveSpeed = 4f;
    
    [SerializeField]
    private bool moveLeft;

    void Update()
    {
        if(moveLeft){
        	Vector2 temp = transform.position;
        	temp.x-=moveSpeed*Time.deltaTime;
        	transform.position=temp;
        }
        else{
        	Vector2 temp = transform.position;
        	temp.x += moveSpeed*Time.deltaTime;
        	transform.position=temp;        
        }
    }
    
    void OnTriggerEnter2D(Collider2D target){
    	
    	if(target.tag=="Bounce"){
    		
    		moveLeft = !moveLeft;
    	
    	}
    
    }
}

```

2.Player.cs

```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{

    public float moveSpeed = 1f;
    
    void FixedUpdate(){
    	
    	Vector2 temp = transform.position;
    	
    	if(Input.GetAxis("Horizontal")>0 || CrossPlatformInputManager.GetAxis("Horizontal")>0){
    	
    		 temp.x += moveSpeed * Time.deltaTime;
    	
    	}
    	else if(Input.GetAxis("Horizontal")<0 || CrossPlatformInputManager.GetAxis("Horizontal")<0){
    	
    		temp.x -= moveSpeed * Time.deltaTime;
    	
    	}
    	if(Input.GetAxis("Vertical")>0 || CrossPlatformInputManager.GetAxis("Vertical")>0){
    	
    		 temp.y+=moveSpeed*Time.deltaTime;
    	
    	} 
    	else if(Input.GetAxis("Vertical")<0 || CrossPlatformInputManager.GetAxis("Vertical")<0){
    		temp.y -= moveSpeed * Time.deltaTime;
    	}
    	
    	transform.position = temp;
    }

    void OnTriggerEnter2D(Collider2D target){
    
    	if(target.tag == "Enemy"){
    	
    		GameManager.instance.PlayerDied();
    	
    	}
    	
    	if(target.tag == "Goal"){
    		
    		GameManager.instance.PlayerWin();
    		Debug.Log("Win");
    	
    	}
    
    }
}
```

3.GameManager.cs

```cs
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
```
