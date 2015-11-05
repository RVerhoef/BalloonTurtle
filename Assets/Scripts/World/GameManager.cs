//Written by Rob Verhoef
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	private int _collectedPickups;
    private int _pickupsToCollect = 5;
    private Text _scoreText;
    private Text _startText;
    private Image _fade;

    void Awake () 
	{
        _scoreText = GameObject.Find("Score Text").GetComponent<Text>();
        _startText = GameObject.Find("Start Text").GetComponent<Text>();
        _fade = GameObject.Find("Fade").GetComponent<Image>();
        _scoreText.text = (_collectedPickups + " / " + _pickupsToCollect);
        Time.timeScale = 0;
    }

    void Start ()
    {
        //The level fades out
        _fade.CrossFadeColor(Color.clear, 5.0f, true, true);
    }

	void Update () 
	{
        //The level starts when the player presses any key
        if (Input.anyKeyDown)
        {
            Time.timeScale = 1;
            _startText.enabled = false;
        }
        //The level ends once the player has collected the required pickups
        if (_collectedPickups == _pickupsToCollect)
        {
            Time.timeScale = 0;
            _fade.CrossFadeColor(Color.black, 1.5f, true, true);
        }
        else if (_collectedPickups == _pickupsToCollect && _fade.color == Color.black)
        {
            Application.LoadLevel(Application.loadedLevel + 1);
        }
    }

    public void IncreaseScore ()
    {
        //Score & UI is updated
        _collectedPickups++;
        _scoreText.text = (_collectedPickups + " / " + _pickupsToCollect);
    }

    public void DecreaseScore()
    {
        //Score & UI is updated
        _collectedPickups--;
        _scoreText.text = (_collectedPickups + " / " + _pickupsToCollect);
    }

    public int Pickups
    {
        get
        {
            return _collectedPickups;
        }
    }
}
