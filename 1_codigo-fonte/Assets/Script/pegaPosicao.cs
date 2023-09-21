using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 


//deve ta no player


public class pegaPosicao : MonoBehaviour {
    string cenaAtual;

	void Awake () {

        cenaAtual = SceneManager.GetActiveScene().name;


    }
    void Start() {

        if (PlayerPrefs.HasKey(cenaAtual + "X") && PlayerPrefs.HasKey(cenaAtual + "Y") && PlayerPrefs.HasKey(cenaAtual + "Z")){

            transform.position = new Vector3(PlayerPrefs.GetFloat(cenaAtual + "X"), PlayerPrefs.GetFloat(cenaAtual + "Y"), PlayerPrefs.GetFloat(cenaAtual + "Z"));

        }

        if (Input.GetKeyDown(KeyCode.R)){

            transform.position = new Vector3(-0.89f, -4.27f, -1f);

        }

    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {

            transform.position = new Vector3(-0.89f, -4.27f, -1f);

        }
    }
	
	// salva a posição do  jogador,  pega e salva na memoria.
	public void SalvaLocal () {
        PlayerPrefs.SetFloat(cenaAtual + "X", transform.position.x );
        PlayerPrefs.SetFloat(cenaAtual + "Y", transform.position.y);
        PlayerPrefs.SetFloat(cenaAtual + "Z", transform.position.z);

    }

    public void ZeraPosi(){

        PlayerPrefs.SetFloat(cenaAtual + "X", -0.89f);
        PlayerPrefs.SetFloat(cenaAtual + "Y", -4.27f);
        PlayerPrefs.SetFloat(cenaAtual + "Z", -1f);

    }

    
}