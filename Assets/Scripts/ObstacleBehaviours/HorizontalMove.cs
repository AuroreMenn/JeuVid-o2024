using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMove : MonoBehaviour
{
	[SerializeField] private float moveSpeed = 5f; //Vitesse de l'objet, modifiable
	[SerializeField] private int xSens = 1; //Le sens de l'objet (1 si en bas, -1 si en haut)
	[SerializeField] private Rigidbody2D rb; //Le rigidbody pour bouger l'obstacle
	private Vector2 movement;
    private Vector3 initialScale;


	//Au démarrage, défini la variable de mouvement
	void Start(){
		movement = new Vector2(xSens, 0);
		initialScale = transform.localScale;
	}

	//A chaque frame, on bouge l'objet via son rigidbody dans le mouvement défini * la vitesse de l'objet moveSpeed * Time.fixedDeltaTime le laps de temps écoulé en 1 frame
	void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        // Changer l'échelle du sprite en fonction de la direction
        if (movement.x < 0) // Si le mouvement est vers la gauche
        {
            transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);
        }
        else if (movement.x > 0) // Si le mouvement est vers la droite
        {
            transform.localScale = initialScale;
        }
    }

	void OnTriggerEnter2D(Collider2D col) {
		//Si l'obstacle rentre en collision avec un mur, on inverse son mouvement Horizontal pour qu'il aille dans le sens contraire
		if (col.gameObject.tag == "Wall") {
			movement.x = movement.x*-1;
		}
	}
}
