using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using System.Net;
using UnityEngine.Audio;

namespace UnityStandardAssets._2D
{
    
    
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private Animation anim;
        public Image healthBar;
        public Image PoisonedAsıl;
        
        private int counter =0;
        private float poison_level=0;
        private string counter_str;
        float health =100.0f;
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;


        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
                
            }
            if (poison_level>0){
            health-=0.1f;
            healthBar.fillAmount = health/100f;
            poison_level-=0.1f;
            PoisonedAsıl.fillAmount=poison_level/100f;
            }
            if(health<=0){
                
                die();
                         }


        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump);
            m_Jump = false;
        }
        void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag=="end"){
            FindObjectOfType<AudioManager>().Play("Ending");
            Destroy(col.gameObject);

        }
        if(col.gameObject.tag=="smoke"){

                if(health>0){     
            Debug.Log("col happend");
            
            counter=counter+1;
            Debug.Log(counter);
            health-=5f;
            healthBar.fillAmount = health/100f;
            Destroy(col.gameObject);}}
        if(col.gameObject.tag=="nodie"){
            if(health>0){     
            Debug.Log("col happend");
            
            counter=counter+1;
            Debug.Log(counter);
            health-=10;
            healthBar.fillAmount = health/100f;}
        }
        if(col.gameObject.tag=="enemy"){
            if(health>0){     
            Debug.Log("col happend");
            Destroy(col.gameObject);
            counter=counter+1;
            Debug.Log(counter);
            health-=10;
            healthBar.fillAmount = health/100f;}
        }
        if(col.gameObject.tag=="poison"){
            poison_level+=20;
            PoisonedAsıl.fillAmount=poison_level/100f;
            Destroy(col.gameObject);
            
    }
        if(col.gameObject.tag=="fallLevel"){
            die();
        }
}
    void die(){
            //anim.Play("Assets/Standard Assets/2D/Animations/RobotBoyCrouch.anim");
            Destroy(gameObject,3);
        
    }
        
    }
}
    