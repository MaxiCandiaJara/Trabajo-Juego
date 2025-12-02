using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    
    public float speed;
    public float jump;

    public Rigidbody2D rb;
    public Animator an;

    public AudioSource au;
    public AudioClip[] effects;

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
        au.GetComponent<AudioSource>();
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
                AudioClip efecto = BuscarCancion("Jump");

                au.clip = efecto;
                au.Play();
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
            
            AudioClip efecto = BuscarCancion("Death");

            au.clip = efecto;
            au.Play();
            
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
            
            AudioClip efecto = BuscarCancion("Key");

            au.clip = efecto;
            au.Play();

        }



    }
    
    private AudioClip BuscarCancion(string nombreCancion)
    {
        foreach (AudioClip cancion in effects)
        {
            if (cancion != null && cancion.name.Equals(nombreCancion, System.StringComparison.OrdinalIgnoreCase))
            {
                return cancion;
            }
        }
        return null;
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
        if(!death){

            AudioClip efecto = BuscarCancion("Pain");
            au.clip = efecto;
            au.Play();

            an.SetTrigger("Hurt");
            inpunch = true;
            vidas -= 1;
            Invoke("Recuperarse", 0.25f);
        }
    


    }

    void Recuperarse()
    {
        
        inpunch = false;

    }



}
