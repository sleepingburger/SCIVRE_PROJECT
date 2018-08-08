using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public class ui : MonoBehaviour {


	//ButtonSOund
	public AudioClip sound;
	private Button button { get { return GetComponent<Button>(); } }
	private AudioSource source { get { return GetComponent<AudioSource>(); } }

	void Start () {
		gameObject.AddComponent<AudioSource>();
		source.clip = sound;
		source.playOnAwake = false;
		button.onClick.AddListener(() => PlaySound());
	}

	void PlaySound () {
		source.PlayOneShot(sound);
	}

	//Exit
	public void QuitGame()
	{
		Debug.Log ("As you wish! :)");
		Application.Quit();
	}
		
	


	// ShowingRegisterCanvass Method

	public  GameObject PanelLogin;
	public  GameObject PanelMenu;

		
	public void Button_ClickLogin()
	{

		PanelLogin.gameObject.SetActive (false);
		PanelMenu.gameObject.SetActive (true);
		PlaySound ();

	}	






}
