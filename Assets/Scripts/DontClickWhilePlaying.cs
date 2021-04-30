using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DontClickWhilePlaying : MonoBehaviour
{
    AudioSource audioSrc;
    private Button button;
    private Color newColor;

    ColorBlock cb;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        button = GetComponent<Button>();
        newColor = new Color(255, 255, 255, 255);

        cb = button.colors;
        cb.disabledColor = newColor;
        button.colors = cb;
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSrc.isPlaying)
        {
            button.interactable = false;
            button.transition = Selectable.Transition.None;
        }
        else
        {
            button.interactable = true;
            button.transition = Selectable.Transition.ColorTint;
        }
    }
}
