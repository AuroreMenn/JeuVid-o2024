using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nourriture : MonoBehaviour
{
    [SerializeField] public GameObject door;

    // Start is called before the first frame update
    void Awake()
    {
        GameObject.Find("Character Animated Variant").GetComponent<PlayerManagerAnimated>().nourriture = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col) {
		//Si l'obstacle entre en collision avec le joueur (objet avec le tag "Player")
        if (col.gameObject.tag == "Player") {
            col.gameObject.GetComponent<PlayerManagerAnimated>().AddNourriture(); 
            gameObject.SetActive(false);
            door.SetActive(false);
        }
    }
}

