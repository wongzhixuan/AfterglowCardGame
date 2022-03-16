using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCardGallery : MonoBehaviour
{
    public GameObject CardGalleryUI;
    private bool galleryOpened;

    void OpenGallery()
    {
        CardGalleryUI.SetActive(true);
        galleryOpened = true;
    }

    // void Update()
    // {
    //     if(Input.GetKeyDown(KeyCode.Escape))
    //     {
    //         CloseGallery(); 
    //     }
    // }

    void CloseGallery()
    {
        if(galleryOpened == true)
        {
            CardGalleryUI.SetActive(false);
            galleryOpened = false;
        }
    }
}
