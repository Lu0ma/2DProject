using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPanelComponent : MonoBehaviour
{
    [SerializeField] GameObject mainMenuRef = null;
    [SerializeField] List<CustomButton> saveButtons = null;
    [SerializeField] CustomButton backButton= null;
    [SerializeField] List<Animator> animators = null;
    bool isActive = false;

    public bool IsActive { get => isActive; set => isActive = value; }

    void Start()
    {
        backButton.AddLeftClickAction(() =>
        {
            isActive = false;
            Invoke(nameof(OpenMainMenu), 0.75f);
        });

        foreach (CustomButton button in saveButtons)
        {
            button.AddLeftClickAction(() => LaunchGame());

            //animator4.GetCurrentAnimatorStateInfo(0).normalizedTime > 1;
        }
    }
    // Update is called once per frame
    void Update()
        {
            foreach (Animator animator in animators)
            {
                animator.SetBool("IsMenuActive", isActive);
            }
        }
    

    private void OpenMainMenu()
    {
        gameObject.SetActive(false);
        mainMenuRef.SetActive(true);
    }
    private void LaunchGame()
    {
        SceneManager.LoadScene("Level_01");
    }
}
