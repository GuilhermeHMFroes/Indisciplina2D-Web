using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class saiPatio : MonoBehaviour
{

    bool libera = false;
    public GameObject Player;
    public string ProximaCena;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (libera == true && Input.GetKeyDown(KeyCode.V))
        {
            //CHAMA OUTRA SCENE
            SceneManager.LoadScene("Fase_1");

        }
    }
    void OnTriggerEnter2D()
    {
        libera = true;
        //
    }
    void OnTriggerExit2D()
    {
        libera = false;
      
    }



    //MOSTRANDO TEXTO NA TELA 

    void OnGUI()
    {


        if (libera == true)
        {

            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 50, 200, 30), "APERTE 'V'");
        }
    }


}