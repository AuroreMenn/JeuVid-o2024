using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CinematiqueFin : MonoBehaviour
{
    public GameObject[] images; // Référencez ici vos images dans l'éditeur Unity
    public float imageDisplayTime = 10f; // Temps d'affichage de chaque image
    private int currentImageIndex = 0;
    private float timer = 0f;

    void Update()
    {
        // Si le timer dépasse le temps d'affichage de l'image actuelle
        if (timer >= imageDisplayTime || Input.GetKeyDown(KeyCode.Space))
        {
            // Passe à l'image suivante
            currentImageIndex++;
            // Réinitialise le timer
            timer = 0f;
        }

        // Si on a affiché toutes les images, on charge la nouvelle scène
        if (currentImageIndex >= images.Length)
        {
            Application.Quit();
                return;
        }

        // Active l'image actuelle et désactive les autres
        for (int i = 0; i < images.Length; i++)
        {
            images[i].SetActive(i == currentImageIndex);
        }

        // Incrémente le timer
        timer += Time.deltaTime;
    }
}
