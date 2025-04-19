using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardPanelComponent : MonoBehaviour
{
    [SerializeField] GameObject previousMenuRef = null;

    [SerializeField] CustomButton backButton = null;
    // Start is called before the first frame update
    void Start()
    {
        backButton.AddLeftClickAction(() => BackToPreviousMenu());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void BackToPreviousMenu()
    {
        gameObject.SetActive(false);
        previousMenuRef.SetActive(true);
    }
}
