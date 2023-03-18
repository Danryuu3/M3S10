using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private float horizontal;
    private float velocidad = 5f;
    private bool saltar = true;
    public Animator animator;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        transform.position += Vector3.right * horizontal * velocidad * Time.deltaTime;
        if(horizontal!=0){
            animator.SetBool("Caminando", true);
        }else{
            animator.SetBool("Caminando", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (saltar)
            {
                saltar = false; 
                animator.SetBool("Saltando", true);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, 8f), ForceMode2D.Impulse);

            }
        }
        

           
        }
    private void FixedUpdate() {
        movimiento();
    }
    private void movimiento(){
        if (horizontal > 0)
            {
                transform.localScale = new Vector3(4f, 4f, 4f);
            }
            
            if (horizontal < 0)
            {
            transform.localScale = new Vector3(-4f, 4f, 4f);
            
                    
            }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Plataform"))
        {
            animator.SetBool("Saltando", false);
            
            saltar = true;
        }

        if (collision.collider.CompareTag("Enemigo"))
        {

            SceneManager.LoadScene(0);
        }

        if (collision.collider.CompareTag("Final"))
        {

            panel.SetActive(true);
        }
    }
}