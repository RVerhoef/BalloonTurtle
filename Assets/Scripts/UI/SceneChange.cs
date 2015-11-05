//Written by Rob Verhoef
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneChange : MonoBehaviour 
{
    private Image _fade;
	
	public void ChangeLevel () 
	{
        //Fade out
        _fade = GameObject.Find("Fade").GetComponent<Image>();
        _fade.CrossFadeColor(Color.black, 1.5f, true, true);
        //Next level is loaded when screen is black
        Application.LoadLevel(Application.loadedLevel + 1);

	}
}
