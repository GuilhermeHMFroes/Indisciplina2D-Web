using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sai_patio : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("Player"))
        {

            //print("io");
            SceneManager.LoadScene("fase_1");
            

        }



    }
}
