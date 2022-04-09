using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishCollision : MonoBehaviour
{
    int speed=10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed*Time.deltaTime,0,0);

    }
 private void Flip()
        {
            // Switch the way the player is labelled as facing
            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
         void OnCollisionEnter2D(Collision2D col){
            if(col.gameObject.tag=="wall"){
                Flip();
                speed=-speed;
    }

}}
