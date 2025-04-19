using UnityEditor;
using UnityEngine;

public class ExitPanelComponent : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] GameObject mainMenuPanel = null;

    [Header("Button")]
    [SerializeField] CustomButton yesButton = null;
    [SerializeField] CustomButton noButton = null;
    // Start is called before the first frame update
    void Start()
    {
        yesButton.AddLeftClickAction(() => QuitGame());
        noButton.AddLeftClickAction(() => BackToMainMenu());
    }

    private void QuitGame()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #endif
        Application.Quit();
    }

    private void BackToMainMenu()
    {
        mainMenuPanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
