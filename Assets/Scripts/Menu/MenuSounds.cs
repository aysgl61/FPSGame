using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSounds : MonoBehaviour
{
    public AudioSource fx; //sesleri çalabilmek için audiosource oluşturdum
    public AudioClip hoverFx; //butonun üzerine gelince ses çıkaracak
    public AudioClip clickFx; //butona tıklayınca ses çıkaracak

    public void HoverSound()
    {
        fx.PlayOneShot(hoverFx);
    }

    public void ClickSound()
    {
        fx.PlayOneShot(clickFx);
    }
}
