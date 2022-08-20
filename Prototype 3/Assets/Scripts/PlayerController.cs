using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;

    // Start is called before the first frame update
    void Start()
    {
        //Atribui o componente Rigidbody do player a variável playerRB
        playerRb = GetComponent<Rigidbody>();
        //playerRb.AddForce(Vector3.up * 500);
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space) && isOnGround){

            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
        
    }

    public void OnCollisionEnter(Collision other) {
             isOnGround = true;
    }
}
