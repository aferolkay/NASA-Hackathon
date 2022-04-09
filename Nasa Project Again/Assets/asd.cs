using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asd : MonoBehaviour
{
   int speed =5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag=="water"){
            transform.Translate(speed*Time.deltaTime,0,0);
            Example();
            transform.Translate(-speed*Time.deltaTime,0,0);
            
}
}
	 IEnumerator Example(){
	 	yield return new WaitForSeconds(2);
	}
}
