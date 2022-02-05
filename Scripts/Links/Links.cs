using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Links : MonoBehaviour
{
    public void OpenFacebook()
    {
        Application.OpenURL("https://www.facebook.com/darkmattergamesproduction/");
    }
    public void OpenInstagram()
    {
        Application.OpenURL("https://www.instagram.com/darkmattergameproduction/");
    }
    public void OpenYoutube()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCxLG9FDcQoX5AvL8UDCkayA");
    }

    public void OpenTwitter()
    {
        Application.OpenURL("https://twitter.com/MatterGame");
    }
}
