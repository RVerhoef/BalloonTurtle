//Written by Rob Verhoef
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeOut : MonoBehaviour
{
    private Image _fade;

    void Awake ()
    {
        _fade = GameObject.Find("Fade").GetComponent<Image>();
    }

    void Start ()
    {
        _fade.CrossFadeColor(Color.clear, 5.0f, true, true);
    }
}
