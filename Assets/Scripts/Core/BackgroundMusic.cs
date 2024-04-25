using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioClip backgroundMusic; // La musique de fond à jouer
    private static bool musicStarted = false; // Variable statique pour suivre si la musique a déjà commencé

    void Awake()
    {
        // Assurez-vous que cet objet persiste entre les scènes
        DontDestroyOnLoad(gameObject);

        // Vérifie si la musique n'a pas déjà commencé
        if (!musicStarted)
        {
            // Configurez l'AudioSource pour jouer la musique de fond
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.loop = true;
            audioSource.clip = backgroundMusic;

            // Jouez la musique de fond
            audioSource.Play();

            // Indique que la musique a commencé
            musicStarted = true;
        }
    }
}
