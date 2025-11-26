using UnityEngine;

public class DamageController : MonoBehaviour
{   

    public float fuerzaX;
    public float fuerzaY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "Player")
        {
            
            Rigidbody2D player = collision.GetComponent<Rigidbody2D>();

            float impulso = (player.transform.position.x < transform.position.x) ? -1 : 1;



            player.AddForce(new Vector2(impulso * fuerzaX, fuerzaY), ForceMode2D.Impulse);

            collision.GetComponent<PlayerController>().Golpe();

        }


    }


}
