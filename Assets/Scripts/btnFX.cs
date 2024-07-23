using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class btnFX : MonoBehaviour
{
    public AudioSource myFX;
    public AudioClip hoverFX;
    public AudioClip clickFX;
    public TMP_Text text;
    public void HoverSound()
    {
        myFX.PlayOneShot(hoverFX);
    }
    public void ClickSound()
    {
        myFX.PlayOneShot(clickFX);
    }
}
