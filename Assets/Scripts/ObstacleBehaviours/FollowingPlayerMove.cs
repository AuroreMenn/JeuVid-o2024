using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingPlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // Vitesse de l'objet, modifiable
    [SerializeField] private Rigidbody2D rb; // Le rigidbody pour bouger l'obstacle
    private GameObject player;

    private float delay = 0.5f;
    private float timerDelay = 0;
    private Vector2 initPosition; // position initiale
    private Vector3 initialScale; // taille initiale du sprite

    // Au démarrage, défini la variable de mouvement
    void Start()
    {
        player = PlayerManager.GetPlayer();
        initPosition = new Vector2(transform.position.x, transform.position.y);
        initialScale = transform.localScale; // Enregistrer la taille initiale
    }

    // A chaque frame, on bouge l'objet via son rigidbody dans le mouvement défini * la vitesse de l'objet moveSpeed * Time.fixedDeltaTime le laps de temps écoulé en 1 frame
    void FixedUpdate()
    {
        // Si le timer de delay est supérieur à 0, on attend que le temps soit écoulé jusqu'à zéro
        if (timerDelay > 0)
        {
            timerDelay = Mathf.Max(0, timerDelay - Time.fixedDeltaTime);
        }

        // Calcul de la direction vers le joueur
        Vector2 direction = (player.transform.position - transform.position).normalized;
        // Réglage de la direction selon la position du joueur
        if (direction.x < 0)
        {
            // Si le joueur est à gauche, ajuste la taille du sprite à gauche
            transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);
        }
        else
        {
            // Sinon, ajuste la taille du sprite à droite (valeur par défaut)
            transform.localScale = initialScale;
        }

        // Mouvement de l'ennemi vers le joueur
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }

    // Fonction qui remet l'objet à sa position initiale
    public void reinitPosition()
    {
        transform.position = initPosition;
        timerDelay += delay;
    }
}
