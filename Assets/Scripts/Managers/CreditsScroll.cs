using UnityEngine;
using TMPro;

public class CreditsScroll : MonoBehaviour
{
    public TextMeshProUGUI creditsText;   // Le texte
    public float scrollSpeed = 30f;       // Vitesse de défilement
    public float targetPositionY = 800f;  // Position finale où s’arrêtera le texte
    public GameObject logoImage;          // L’image à afficher à la fin
    public float delayBeforeLogo = 2f;    // Petit délai avant l’apparition des logos

    private RectTransform textRect;
    private bool hasStopped = false;

    void Start()
    {
        textRect = creditsText.rectTransform;
        logoImage.SetActive(false);  // Cache l’image au début
    }

    void Update()
    {
        if (!hasStopped)
        {
            // Si la position n’est pas encore atteinte, fais défiler le texte vers le haut
            textRect.Translate(Vector3.up * scrollSpeed * Time.deltaTime);

            // Quand on atteint ou dépasse la position cible, on stoppe et on affiche les logos après un délai
            if (textRect.anchoredPosition.y >= targetPositionY)
            {
                hasStopped = true;
                Invoke(nameof(ShowLogo), delayBeforeLogo);
            }
        }
    }

    void ShowLogo()
    {
         logoImage.SetActive(true);

    // Joue la musique
    AudioSource audio = GetComponent<AudioSource>();
    if (audio != null)
    {
        audio.Play();
    }
}
}
