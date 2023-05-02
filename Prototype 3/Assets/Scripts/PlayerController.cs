using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
   
    public AudioClip jumpSound;

    public AudioClip crashSound;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        //Atribui o componente Rigidbody do player a variável playerRB
        playerRb = GetComponent<Rigidbody>();
        //Atribui o componente Animation do player a variável playerAnim
        playerAnim = GetComponent<Animator>();
        //Atribui o componente AudioSource do player a variável playerAudio
        playerAudio = GetComponent<AudioSource>();

        //playerRb.AddForce(Vector3.up * 500);
        Physics.gravity *= gravityModifier;

   
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(0, transform.position.y, 0);
        
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver){
            playerAudio.PlayOneShot(jumpSound,1.0f);
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
        }
        
    }

    public void OnCollisionEnter(Collision other) {
           

        if(other.gameObject.CompareTag("Ground")){
            isOnGround = true;
            dirtParticle.Play();
        }

        if(other.gameObject.CompareTag("Obstacle")){
            gameOver = true;
            playerAudio.PlayOneShot(crashSound,1.0f);
            Debug.Log("Fim de Jogo");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
        }

    }
}
