using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public float moveSpeed = 4f;
    
    [SerializeField] // to make private fields visible in editor
    private bool moveLeft; // bool is true or false

    void Update()
    {
        if(moveLeft){
        	// vector holds the position, vector2(x,y) - 2D vector3(x,y,z)-3D 
        	Vector2 temp = transform.position; // current position of enemy
        	temp.x -= moveSpeed*Time.deltaTime; // d = s*t
        	transform.position=temp;
        }
        else{
        	Vector2 temp = transform.position; //current position of enemy
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
