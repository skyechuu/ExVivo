using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class resetscene : MonoBehaviour {

		void Update(){
			if(Input.GetKeyDown(KeyCode.R)){
				Application.LoadLevel(0); 
			}
		}
	}