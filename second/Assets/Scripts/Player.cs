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
    		// Debug.Log("okay");
    	
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
