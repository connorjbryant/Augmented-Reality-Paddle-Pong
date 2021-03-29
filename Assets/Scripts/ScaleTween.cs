using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTween : MonoBehaviour
{
    public LeanTweenType easeType;

    void OnEnable()
    {
        LeanTween.moveY(gameObject, 13.5f, 0.3f).setLoopPingPong().setEase(easeType);
    }
}
