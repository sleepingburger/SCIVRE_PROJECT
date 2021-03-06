﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using SpeechLib;
using System.Xml;
using System.IO;

public class planetDialogue : MonoBehaviour {

	//THIS GLAZE IS FOR THE DESCRIPTION 
	//OF ALL THE OJEBJECTS IN 3D MODE

	private SpVoice voice;
	public Dialogue dialogue;

	public static bool ret;
	private bool gazeAt;
	public static bool hasSelect;

  	float gazeTime = 2f;
    private float timer;
	PanelAnim panelAnim;
	public static float minZoom,maxZoom;
    public static int selectedPlanet;
    public int planetNo;
	void Start(){
		panelAnim = FindObjectOfType<PanelAnim> ();
		defaultView ();
	}
	void Update () {
		if (VrOn.isVROn) {
			if (gazeAt) {
				timer += Time.deltaTime;
				if (timer >= gazeTime) {
					ExecuteEvents.Execute (gameObject, new PointerEventData (EventSystem.current), ExecuteEvents.pointerDownHandler);
					timer = 0f;
				}
			}
		}
	}
	public void PointerEnter(){
		if (VrOn.isVROn) {
			gazeAt = true;
			ret = true;
		}
	}
	public void PointerDown(){
		if (VrOn.isVROn) {
			//means the vr is on , here you can add all the events when ur in vr mode
			hasSelect = true;
			gazeAt = false;
			selectedPlanet = planetNo;
			panelAnim.newPanel (selectedPlanet);

		} else {
			FindObjectOfType<DialogueManager> ().StartDialogue (dialogue);
			//dito pwede ung double tap ilagay this is the change of pivot
			//lerp = true;
			anatomyDialogue.textToBeSpeech = dialogue.sentences;

			hasSelect = true;
            selectedPlanet = planetNo;

			if (selectedPlanet == 9)
				defaultView ();
			else {
				minZoom = 250f;
				maxZoom = 500f;
			}
		}
			
	}
	public void PointerExit(){
        if (VrOn.isVROn)
        {
            timer = 0f;
            gazeAt = false;
            ret = false;
        }
	}


    public void defaultView() {
		minZoom = 300f;
		maxZoom = 1200f;
    }

	public void hasSelected(bool a){
		hasSelect = a;
	}
	public void planetNumber(int a){
		planetNo = a;
	}





	/*public void speak(string message)
	{

		voice = new SpVoice();
		voice.Rate = -2;


		voice.Speak (message, SpeechVoiceSpeakFlags.SVSFlagsAsync);


	}




	/// CODE FOR LOAD XML OR OTHER TEXT FILES IN THE SISTEM FROM THE FOLDER RESOURCE

	string loadXMLStandalone (string fileName) {

		string path  = Path.Combine("Resources", fileName);
		path = Path.Combine (Application.dataPath, path);
		Debug.Log ("Path:  " + path);
		StreamReader streamReader = new StreamReader (path);
		string streamString = streamReader.ReadToEnd();
		Debug.Log ("STREAM XML STRING: " + streamString);
		return streamString;
	}*/

}
