﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class exit : MonoBehaviour {
	public Slider mode;
	public Image vr,normal;
	void Start(){
		vr.canvasRenderer.SetAlpha (1f);
		normal.canvasRenderer.SetAlpha (1f);
	}
	public void vrOrNormal(){
		if (mode.value == 1) {
			normal.canvasRenderer.SetAlpha (.4f);
			vr.canvasRenderer.SetAlpha (1f);
			PlayerPrefs.SetInt ("isVrOn", 1);
		} 
		else{
			normal.canvasRenderer.SetAlpha (1f);
			vr.canvasRenderer.SetAlpha (.4f);
			PlayerPrefs.SetInt ("isVrOn", 0);
		}
	}
	public void QuitGame()
	{
		Debug.Log ("As you wish! :)");
		Application.Quit();
	}

}