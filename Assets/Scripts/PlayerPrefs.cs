using System.Collections;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LanguageManager : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(LoadLanguagePreference());
    }

    public void SetLanguage(int localeID)
    {
        // Change la langue sélectionnée
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeID];

        // Sauvegarde la préférence dans PlayerPrefs
        PlayerPrefs.SetInt("language", localeID);
        PlayerPrefs.Save();
    }

    private IEnumerator LoadLanguagePreference()
    {
        // Attendre l'initialisation du système de localisation
        yield return LocalizationSettings.InitializationOperation;

        // Vérifier si une langue a déjà été sauvegardée

        Debug.Log(PlayerPrefs.GetInt("language"));
        if (PlayerPrefs.HasKey("language"))
        {
            int savedLocaleID = PlayerPrefs.GetInt("language");
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[savedLocaleID];
        }
        else
        {
            // Si aucune langue n'a été sauvegardée, utiliser la langue par défaut ou une autre logique
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0]; // Par défaut : première langue
            PlayerPrefs.SetInt("language", 0);
            PlayerPrefs.Save();
        }
    }
}
