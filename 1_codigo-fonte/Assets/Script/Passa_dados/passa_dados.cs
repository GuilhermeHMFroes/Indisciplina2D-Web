using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class passa_dados : MonoBehaviour {

    public static passa_dados instance;

    public static int item = 0;
    public Text txtCartilha;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Update() {

        txtCartilha.text = item.ToString();

    }

    void OnEnable()
    {
        animapersonagem.OnGetCoin += OnPlayerGetCoin;
       
    }

    void OnPlayerGetCoin()
    {
        item++;
      
    
     }
   

}
