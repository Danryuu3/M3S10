using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private float horizontal;
    private float velocidad = 5f;
    private bool saltar = true;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        transform.position += Vector3.right * horizontal * velocidad * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (saltar)
            {
                saltar = false; 
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, 8f), ForceMode2D.Impulse);

            }
        }

            //if (horizontal > 0)
            //        {
            //
            //         
            //transform.localScale = new Vector3(1f, 1f, 1f);
            //
            //          
            //}
            //
            //if (horizontal < 0)
            //        {
            //
            //            
            //transform.localScale = new Vector3(-1f, -1f, -1f);
            //
            //         
            //}
        }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Plataform"))
        {
            
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