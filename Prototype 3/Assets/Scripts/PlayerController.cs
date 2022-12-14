using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb;
    private Animator playerAnim;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;

    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        //Atribui o componente Rigidbody do player a variável playerRB
        playerRb = GetComponent<Rigidbody>();
        //Atribui o componente Animation do player a variável playerAnim
        playerAnim = GetComponent<Animator>();
        
        //playerRb.AddForce(Vector3.up * 500);
        Physics.gravity *= gravityModifier;

   
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space) && isOnGround){

            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
        }
        
    }

    public void OnCollisionEnter(Collision other) {
           

        if(other.gameObject.CompareTag("Ground")){
            isOnGround = true;
        }

        if(other.gameObject.CompareTag("Obstacle")){
            gameOver = true;
            Debug.Log("Fim de Jogo");
        }

    }
}
