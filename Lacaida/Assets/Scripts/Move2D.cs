using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move2D : MonoBehaviour
{

    public float speed = 7;
    //La variable fuerza se declara para poder medir con que fuerza el salto
    public int force = 6;
    private bool voltearse = true;
    private Rigidbody2D rb;
    public GameObject gameOverText, restartButton;
    public GameObject cora1, cora2, cora3;
    public int vidadeljugador = 3;
    int playerLayer, enemyLayer;
    bool coroutineAllowed = true;
    Color color;
    Renderer rend;





    // Start is called before the first frame update
    void Start()
    {
        playerLayer = this.gameObject.layer;
        enemyLayer = LayerMask.NameToLayer("Enemy");
        Physics2D.IgnoreLayerCollision(playerLayer, enemyLayer, false);
        cora1 = GameObject.Find("cora1");
        cora2 = GameObject.Find("cora2");
        cora3 = GameObject.Find("cora3");
        cora1.gameObject.SetActive(true);
        cora2.gameObject.SetActive(true);
        cora3.gameObject.SetActive(true);
        rend = GetComponent<Renderer>();
        color = rend.material.color;

        gameOverText.SetActive(false);
        restartButton.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.005f)
            Saltar();
    }
    private void Saltar()
    {
        rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Flip(moveHorizontal);


        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb.AddForce(movement * speed);
    }
    public void Flip(float horizontal)
    {
        if (horizontal > 0 && !voltearse || horizontal < 0 && voltearse)
        {
            voltearse = !voltearse;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            vidadeljugador -= 1;
            switch (vidadeljugador)
            {
                case 2:
                    cora3.gameObject.SetActive(false);
                    if (coroutineAllowed)
                        StartCoroutine("Immortal");
                    break;
                case 1:
                    cora2.gameObject.SetActive(false);
                    if (coroutineAllowed)
                        StartCoroutine("Immortal");
                    break;
                case 0:
                    cora1.gameObject.SetActive(false);
                    if (coroutineAllowed)
                        StartCoroutine("Immortal");
                    break;
            }
            if (vidadeljugador < 1)
            {
                gameOverText.SetActive(true);
                restartButton.SetActive(true);
                gameObject.SetActive(false);
            }
           
        }

    }
    IEnumerator Immortal()
    {
        coroutineAllowed = false;
        Physics2D.IgnoreLayerCollision(playerLayer, enemyLayer, true);
        color.a = 0.5f;
        rend.material.color = color;
        yield return new WaitForSeconds(3f);
        Physics2D.IgnoreLayerCollision(playerLayer, enemyLayer, false);
        color.a = 1f;
        rend.material.color = color;
        coroutineAllowed = true;
    }
}
