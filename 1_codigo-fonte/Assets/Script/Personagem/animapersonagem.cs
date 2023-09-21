using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class animapersonagem : MonoBehaviour {

    public static animapersonagem instance;

    //public int item = 0;

    //Animação 
    public bool face = true;
    public Transform play;
    public float vel = 3f; //velocidade andando
    public float vel1 = 7f;//velocidade correndo
    public float forca = 6f;//foca pulo
    public Rigidbody2D playerRB;
    public int liberapulo = 1;
    public Animator anim;
    public bool vivo = true;
    public int choro = 6;

    /// ///////////////////////
    public delegate void Action();
    public static event Action OnGetCoin;
    ///////////////////////////////////

    

  

    // passa dados
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        play = GetComponent<Transform>(); //pegando o componete de Transform
        playerRB = GetComponent<Rigidbody2D>();// pegando componete do player 
        anim = GetComponent<Animator>(); //pegando o componete de anição,  para trocar as animações
        
    }

    // Update is called once per frame
    void Update()
    {


        if (vivo == true)
        {
            if (Input.GetKey(KeyCode.RightArrow) && !face && !Input.GetKey(KeyCode.LeftArrow))
            {
                Flip();

            }
            else if (Input.GetKey(KeyCode.LeftArrow) && face && !Input.GetKey(KeyCode.RightArrow))
            {
                Flip();

            }

        }



        //MOVIMENTO E ANIMAÇÕES DO JOGADOR 
        if (vivo == true)
        {//correndo
            if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.C) && (liberapulo == 1))
            {

                transform.Translate(new Vector2(vel1 * Time.deltaTime, 0));
                anim.SetBool("Parado", false);
                anim.SetBool("Andar", false);
                anim.SetBool("Correr", true);
              //  anim.SetBool("Pulo ", false);

                print("oi");
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.C) && (liberapulo == 1))
            {
                transform.Translate(new Vector2(-vel1 * Time.deltaTime, 0));
                anim.SetBool("Parado", false);
                anim.SetBool("Andar", false);
                anim.SetBool("Correr", true);
              //  anim.SetBool("Pulo ", false);

             //andando
            }else if (liberapulo == 0 && Input.GetKey(KeyCode.RightArrow)) {
                transform.Translate(new Vector2(7f * Time.deltaTime, 0));
            }
            else if (liberapulo == 0 && Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(new Vector2(-7f * Time.deltaTime, 0));
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.C) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.Space))
            {
                transform.Translate(new Vector2(-vel * Time.deltaTime, 0));
                anim.SetBool("Parado", false);
                anim.SetBool("Andar", true);
                anim.SetBool("Correr", false);
            }
            else if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.C) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.Space))
            {
                transform.Translate(new Vector2(vel * Time.deltaTime, 0));
                anim.SetBool("Parado", false);
                anim.SetBool("Andar", true);
                anim.SetBool("Correr", false);
            }
        

         //parado 
            else if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && ( liberapulo == 1)  || Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow)
                        || Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.Space)  || Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.Space)

                    )
            {
                anim.SetBool("Parado", true);
                anim.SetBool("Andar", false);
                anim.SetBool("Correr", false);
                anim.SetBool("Pulo", false);

            }
            //PULO CORRENDO PARA A ESQUERDA 

            if (Input.GetKey(KeyCode.Space) && (liberapulo > 0) && Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.C))
            {

                playerRB.AddForce(new Vector2(0, forca), ForceMode2D.Impulse);
                liberapulo = 0;
               anim.SetBool("Parado", false);
                anim.SetBool("Pulo", true);
                anim.SetBool("Andar", false);
                anim.SetBool("Correr", false);

            } //PULLO QUANDO CORRENDO PARA A DIREITA
            else if (Input.GetKey(KeyCode.Space) && (liberapulo > 0) && Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.C))
            {

                playerRB.AddForce(new Vector2(0, forca), ForceMode2D.Impulse);
                liberapulo = 0;
                
                anim.SetBool("Pulo", true);
                anim.SetBool("Correr", false);

            }
            else if (Input.GetKey(KeyCode.Space) && (liberapulo > 0) ) //PULO PARADO 
            {
                playerRB.AddForce(new Vector2(0, forca), ForceMode2D.Impulse);
                liberapulo = 0;
                anim.SetBool("Parado", false);
                anim.SetBool("Pulo", true);
            }
            //pulo andando
           
        }


        //CONDIÇÃO PARA IR PARA A PROXIMA FASE
        if (choro == 0 ) {

             SceneManager.LoadScene("lab_info");


        }

    }
    void Flip() //FAZ O PLAYER VIRAR PARA ESQUERDA OU PARA A DIREITA
    {
        face = !face;
        Vector3 scala = play.localScale;
        scala.x *= -1;
        play.localScale = scala;

    }

    void OnCollisionEnter2D(Collision2D chao)//FAZ ZERAR O PULO E ATIVA A ANIMAÇÃO DE PARADO
    {

        if (chao.gameObject.CompareTag("chao"))
        {
            anim.SetBool("Parado", true);
            anim.SetBool("Pulo", false);
            anim.SetBool("Correr", false);
            anim.SetBool("Andar", false);
            liberapulo = 1;

        }

    }

    //coleta intens, recebe os dados colatos pelo script  de *passa_ dados*

    void OnTriggerEnter2D(Collider2D outro) {
        if (outro.gameObject.CompareTag("cartilha")) {
            if (OnGetCoin != null)
            {
                OnGetCoin();
                Destroy(outro.gameObject);
            }
        }else if (outro.gameObject.CompareTag("objetivo") && passa_dados.item> 0){
            //decrementando cartilha
            passa_dados.item--;
            choro--;
            Destroy(outro.gameObject);

        }

    }


   
}
