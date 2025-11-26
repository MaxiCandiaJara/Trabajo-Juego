using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    
    public float speed;
    public float jump;

    public Rigidbody2D rb;
    public Animator an;

    float x;
    bool grounded = false;
    bool inpunch = false;
    bool death = false;
    int vidas = 5;
    public int llaves = 0;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
        an.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        if (!death){

            x = Input.GetAxis("Horizontal");
            Mover();
            Animar();
        }

        if (death)
        {
            
            x = 0;
        

        }




    }



    void Mover()
    {

        if (!inpunch){
            if (grounded)
            {
            rb.linearVelocityX = x * speed;
            }
            if (!grounded)
            {
            rb.linearVelocityX = x * (speed/1.5f);
            }
        }
  

        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if(grounded)
            {
                rb.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
                an.SetTrigger("Jump");
            }

        }

    }

    void Animar()
    {   
        an.SetBool("Grounded", grounded);
        an.SetFloat("AirSpeedY", rb.linearVelocityY);

        if(x > 0)
        {     
            transform.localScale = new Vector3(1,1,1);
        }

        if(x < 0)
        {
            transform.localScale = new Vector3(-1,1,1);
        }

        if(x != 0)
        {
            an.SetInteger("AnimState", 1);  
        } 

        if(x == 0)     
        {
            an.SetInteger("AnimState", 0);
        }

        if (vidas <= 0 && death == false)
        {
            
            death = true;
            an.SetTrigger("Death");
        }

        

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Floor")
        {
            grounded = true;
        }

        if(collision.tag == "Key")
        {
            
            Destroy(collision.gameObject);
            llaves += 1;


        }



    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Floor")
        {
            grounded = false;
        }
    }


    public void Golpe()
    {
        
        an.SetTrigger("Hurt");
        inpunch = true;
        vidas -= 1;
        Invoke("Recuperarse", 0.25f);


    }

    void Recuperarse()
    {
        
        inpunch = false;

    }



}
