using UnityEngine;

public class SettingsPanelComponent : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] GameObject mainPanelRef = null;
    [SerializeField] GameObject gamePanelRef = null;
    [SerializeField] GameObject audioPanelRef = null;
    [SerializeField] GameObject videoPanelRef = null;
    [SerializeField] GameObject controllerPanelRef = null;
    [SerializeField] GameObject keyboardPanelRef = null;
    //TODO Add other menuPanel : Game/Video/Audio/Controller/Keyboard

    [Header("Buttons")]

    [SerializeField] CustomButton gameButton = null;
    [SerializeField] CustomButton audioButton = null;
    [SerializeField] CustomButton videoButton = null;
    [SerializeField] CustomButton controllerButton = null;
    [SerializeField] CustomButton keyboardButton = null;
    [SerializeField] CustomButton backButton = null;
    // Start is called before the first frame update
    void Start()
    {
        backButton.AddLeftClickAction(() => BackToMainMenu());
        gameButton.AddLeftClickAction(() => GoToGameMenu());
        audioButton.AddLeftClickAction(() => GoToAudioMenu());
        videoButton.AddLeftClickAction(() => GoToVideoMenu());
        controllerButton.AddLeftClickAction(() => GoToControllerMenu());
        keyboardButton.AddLeftClickAction(() => GoToKeyboardMenu());
    }

    // Update is called once per frame
    private void BackToMainMenu()
    {
        mainPanelRef.SetActive(true);
        gameObject.SetActive(false);
    }

    private void GoToGameMenu()
    {
        gameObject.SetActive(false);
        gamePanelRef.SetActive(true);
    }
    private void GoToAudioMenu()
    {
        gameObject.SetActive(false);
        audioPanelRef.SetActive(true);
    }
    private void GoToVideoMenu()
    {
        gameObject.SetActive(false);
        videoPanelRef.SetActive(true);
    }
    private void GoToControllerMenu()
    {
        gameObject.SetActive(false);
        controllerPanelRef.SetActive(true);
    }
    private void GoToKeyboardMenu()
    {
        gameObject.SetActive(false);
        keyboardPanelRef.SetActive(true);
    }
}
