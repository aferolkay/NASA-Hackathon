using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using System.Net;
namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        
        public Image healthBar;
        private bool displayMessage =true;
        private int counter =0;
        private string counter_str;
        int health =100;
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;


        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
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
        Debug.Log("Collision");
        if(col.gameObject.tag=="enemy"){
            if(health>0){     
            Debug.Log("col happend");
            Destroy(col.gameObject);
            counter=counter+1;
            Debug.Log(counter);
            health-=20;
            healthBar.fillAmount = health/100f;}

            if(Input.GetKeyDown(KeyCode.LeftControl)){
                healthBar.fillOrigin=(int)Image.OriginHorizontal.Right;
                
           
            }
            if(health<=0){
                Debug.Log("you died");
                Destroy(gameObject);
            }
            

        }
    }
    }
}
     


