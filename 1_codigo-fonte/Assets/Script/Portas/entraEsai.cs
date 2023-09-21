using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class entraEsai : MonoBehaviour {

    bool libera = false;
    public GameObject Player;
    public string ProximaCena;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if ( libera == true && Input.GetKeyDown(KeyCode.V)) {
            //acessando script do jogador
            Player.GetComponent<pegaPosicao>().SalvaLocal();
           SceneManager.LoadScene("Fase_01_biblioteca");

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
        Player.GetComponent<pegaPosicao>().ZeraPosi();
    }
     


    //mostrando  msg na tela
    void OnGUI() {


        if(libera == true){

            GUI.Label(new Rect(Screen.width/2 - 50, Screen.height/2 + 50, 200, 30), "APERtE 'V'");
        }
    }


}
