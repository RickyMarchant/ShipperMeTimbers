using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	public void NewGameButton(string newGameToLoad)
    {
        SceneManager.LoadScene(newGameToLoad);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
