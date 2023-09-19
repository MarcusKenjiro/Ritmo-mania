using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class muteController : MonoBehaviour
{
    private bool mute;

    public Sprite muteSprite;
    public Sprite noMuteSprite;

    //public AudioSource audioSource;

    private SpriteRenderer renderSprite;


    private void Start()
    {
        //Atribui a variável renderSprite o componente de SpriteRenderer presente no objeto 2D, na inicialização da cena.
        renderSprite = GetComponent<SpriteRenderer>(); 
        mute = PlayerPrefs.GetInt("MUTED") == 1;

        //audioSource = GetComponent<AudioSource>();

        if (mute == false)
        {
            renderSprite.sprite = noMuteSprite;
        }
        else
        {
            renderSprite.sprite = muteSprite;
        }
    }

    private void OnMouseDown()
    {
        Mute();
    }

    public void Mute()
    {
        mute = !mute;
        AudioListener.pause = mute;
        //audioSource.mute = !audioSource.mute;
        PlayerPrefs.GetInt("MUTED", mute ? 1 : 0);

        if (mute == false)
        {
            renderSprite.sprite = noMuteSprite;
        }
        else
        {
            renderSprite.sprite = muteSprite;
        }
    }
}
