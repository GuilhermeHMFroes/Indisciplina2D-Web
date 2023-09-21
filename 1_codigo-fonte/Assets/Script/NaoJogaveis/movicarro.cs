using System.Collections;
using System.Collections.Generic;

using UnityEngine;



public class movicarro : MonoBehaviour {
    int carro = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(carro == 1)
        {
            GetComponent<SpriteRenderer>().flipX = true;

            transform.Translate(new Vector2(0.2f,0));


        } else if(carro == 0)
        {

            GetComponent<SpriteRenderer>().flipX = false;

            transform.Translate(new Vector2(-0.2f, 0));


        }




    }

    void OnCollisionEnter2D(Collision2D outro) {

        if (outro.gameObject.CompareTag("batecarro")) {
           
            carro = 1;

        }else if (outro.gameObject.CompareTag("batecarro1")) {

            carro = 0;


        }


    }



}
