using UnityEngine;

public class MainMenuComponent : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] StartPanelComponent startMenuInfo= null;
    [SerializeField] GameObject startMenuRef = null;
    [SerializeField] GameObject optionMenuRef = null;
    [SerializeField] GameObject exitMenuRef = null;

    [Header("Buttons")]
    [SerializeField] CustomButton playButton = null;
    [SerializeField] CustomButton settingsButton = null;
    [SerializeField] CustomButton exitButton = null;

    // Start is called before the first frame update
    void Start()
    {
        playButton.AddLeftClickAction(() => OpenStartPanel());
        settingsButton.AddLeftClickAction(() => OpenSettingsPanel());
        exitButton.AddLeftClickAction(() => OpenExitPanel());
    }

    void OpenStartPanel()
    {
        gameObject.SetActive(false);
        startMenuInfo.IsActive = true;
        startMenuRef.SetActive(true);
        optionMenuRef.SetActive(false);
        exitMenuRef.SetActive(false);
    }

    void OpenSettingsPanel()
    {
        gameObject.SetActive(false);
        startMenuRef.SetActive(false);
        optionMenuRef.SetActive(true);
        exitMenuRef.SetActive(false);
    }
    void OpenExitPanel()
    {
        gameObject.SetActive(false);
        startMenuRef.SetActive(false);
        optionMenuRef.SetActive(false);
        exitMenuRef.SetActive(true);
    }

}
