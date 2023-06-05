using System.Collections;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocalizationSetter : MonoBehaviour
{
    public static int LocalizationId = 0;
    private const int DefaultLocalizationValue = 0;
    private bool _isLocalizeActive = false;
  
    private void Start()
    {
        LocalizationId = PlayerPrefs.GetInt(nameof(LocalizationId), DefaultLocalizationValue);
        ChangeLocalization(LocalizationId);
    }

    public void ChangeLocalization(int localizationId)
    {
        if(_isLocalizeActive == true)
        {
            return;
        }
        StartCoroutine(SetLocalizationById(localizationId));
        PlayerPrefs.SetInt(nameof(LocalizationId), localizationId);
    }

    IEnumerator SetLocalizationById(int localizationId)
    {
        _isLocalizeActive = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localizationId];
        _isLocalizeActive = false;
    }
}
