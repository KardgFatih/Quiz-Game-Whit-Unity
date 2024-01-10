using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void OpenSocialmedya(string my_Url)
    {
        Application.OpenURL(my_Url);
    }

    public void Quite()
    {
        Application.Quit();
    }
}
