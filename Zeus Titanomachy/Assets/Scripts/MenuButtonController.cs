using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonController : MonoBehaviour {

	// Use this for initialization
	public int index;
	public bool pres = false;
	[SerializeField] bool keyDown;
	[SerializeField] int maxIndex;
	public AudioSource audioSource;

	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return) && index == 0)
        {
            SceneManager.LoadScene("Actual_scene");
        }
        if (Input.GetKeyDown(KeyCode.Return) && index == 2)
        {
            Application.Quit();
        }
        if (Input.GetAxis ("Vertical") != 0){
			if(!keyDown){
				if (Input.GetAxis ("Vertical") < 0) {
					if(index < maxIndex){
						index++;
					}else{
						index = 0;
					}
				} else if(Input.GetAxis ("Vertical") > 0){
					if(index > 0){
						index --; 
					}else{
						index = maxIndex;
					}
				}
				keyDown = true;
			}
		}else{
			keyDown = false;
		}
        

    }
	

}
