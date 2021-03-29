using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToUrl : MonoBehaviour {

    public void OpenURL(string url)
    {
        Application.OpenURL(url);
    }
}
