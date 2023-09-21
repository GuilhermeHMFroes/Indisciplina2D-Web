using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class contCartilha : MonoBehaviour {

    public static contCartilha instance;

    public GameObject dados;
           
    public Text txtCartilha;
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

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //dados.GetComponent<passa_dados>().item;

	}

 
}
