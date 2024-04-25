using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioClip backgroundMusic; // La musique de fond à jouer

    void Awake()
    {
        // Assurez-vous que cet objet persiste entre les scènes
        DontDestroyOnLoad(gameObject);

        // Configurez l'AudioSource pour jouer la musique de fond
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.clip = backgroundMusic;

        // Jouez la musique de fond
        audioSource.Play();
    }
}