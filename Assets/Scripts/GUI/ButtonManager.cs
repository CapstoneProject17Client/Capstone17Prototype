using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

/// <summary>
/// Button Manager.
/// Menu button functions
/// Functionality: start new scene, open Setting menu, and quit application
/// Resource: https://unity3d.com/learn/tutorials/topics/user-interface-ui/creating-main-menu
/// Author: Andrew Lam
/// </summary>
public class ButtonManager : MonoBehaviour {

	public Transform mainMenu, gameSettings;
	public string levelToLoad;

	// start game
	public void playGameBtn(string scene) {
		SceneManager.LoadScene(levelToLoad);
	}

//	// Open setting panel
//	public void settingBtn(bool clicked) {
//		if (clicked) {
//			gameSettings.gameObject.SetActive (clicked);
//			mainMenu.gameObject.SetActive (false);
//		} else {
//			gameSettings.gameObject.SetActive (clicked);
//			mainMenu.gameObject.SetActive (true);
//		}
//	}

	// close application
	public void exitGameBtn() {
		Application.Quit ();
	}
}