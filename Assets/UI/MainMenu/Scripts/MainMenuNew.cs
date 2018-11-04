using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuNew : MonoBehaviour {

	public Animator CameraObject;

	[Header("Load Screen")]
	public string sceneName; 

	[Header("Panels")]
	public GameObject PanelControls;
	public GameObject PanelVideo;
	public GameObject PanelGame;
    public GameObject PanelAudio;
	public GameObject PanelKeyBindings;
	public GameObject PanelMovement;
	public GameObject PanelCombat;
	public GameObject PanelGeneral;
	public GameObject PanelareYouSure;
    public GameObject TopButtons;
    public GameObject KeyButtons;

	[Header("SFX")]
	public GameObject hoverSound;
	public GameObject sfxhoversound;
	public GameObject clickSound;

	// campaign button sub menu
	[Header("Sub Menu Buttons")]
	public GameObject continueBtn;
	public GameObject newGameBtn;
    public GameObject ExitBtn;
    public GameObject PlayBtn;
    public GameObject SettingsBtn;
    public GameObject Back_Btn;
    public GameObject Version;

	// highlights
	[Header("Highlight Effects")]
	public GameObject lineGame;
	public GameObject lineVideo;
	public GameObject lineControls;
    public GameObject lineAudio;

    [Header("Highlight Effects2")]
    public GameObject lineGeneral;
    public GameObject lineMovement;
    public GameObject lineCombat;
    public GameObject lineKeyReturn;

    public void Return()
    {
        KeyButtons.gameObject.SetActive(false);
        TopButtons.gameObject.SetActive(true);
        PanelMovement.gameObject.SetActive(false);
        PanelCombat.gameObject.SetActive(false);
        PanelGeneral.gameObject.SetActive(false);



    }

    public void  PlayCampaign (){
		PanelareYouSure.gameObject.SetActive(false);
		continueBtn.gameObject.SetActive(true);
		newGameBtn.gameObject.SetActive(true);
        PlayBtn.gameObject.SetActive(false);
        ExitBtn.gameObject.SetActive(false);
        SettingsBtn.gameObject.SetActive(false);
        Back_Btn.gameObject.SetActive(true);
	}

	public void NewGame(){
		if(sceneName != "")
		SceneManager.LoadScene(sceneName);
	}

	public void  DisablePlayCampaign (){
		continueBtn.gameObject.SetActive(false);
		newGameBtn.gameObject.SetActive(false);
        PlayBtn.gameObject.SetActive(true);
        ExitBtn.gameObject.SetActive(true);
        SettingsBtn.gameObject.SetActive(true);
        Back_Btn.gameObject.SetActive(false);


    }

    public void DisableEverything()
    {
        continueBtn.gameObject.SetActive(false);
        newGameBtn.gameObject.SetActive(false);
        PlayBtn.gameObject.SetActive(false);
        ExitBtn.gameObject.SetActive(false);
        SettingsBtn.gameObject.SetActive(false);
        Back_Btn.gameObject.SetActive(false);
        Version.gameObject.SetActive(false);


    }

    public void  Position2 (){
		DisablePlayCampaign();
		CameraObject.SetFloat("Animate",1);
	}

	public void  Position1 (){
		CameraObject.SetFloat("Animate",0);
	}


    public void  GamePanel (){
		PanelControls.gameObject.SetActive(false);
		PanelVideo.gameObject.SetActive(false);
		PanelGame.gameObject.SetActive(true);
		PanelKeyBindings.gameObject.SetActive(false);
        PanelAudio.gameObject.SetActive(false);

        lineGame.gameObject.SetActive(true);
		lineControls.gameObject.SetActive(false);
		lineVideo.gameObject.SetActive(false);
        lineAudio.gameObject.SetActive(false);
    }

	public void  VideoPanel (){
		PanelControls.gameObject.SetActive(false);
		PanelVideo.gameObject.SetActive(true);
		PanelGame.gameObject.SetActive(false);
        PanelAudio.gameObject.SetActive(false);
		PanelKeyBindings.gameObject.SetActive(false);

		lineGame.gameObject.SetActive(false);
		lineControls.gameObject.SetActive(false);
		lineVideo.gameObject.SetActive(true);
        lineAudio.gameObject.SetActive(false);
    }

	public void  ControlsPanel (){
		PanelControls.gameObject.SetActive(true);
		PanelVideo.gameObject.SetActive(false);
		PanelGame.gameObject.SetActive(false);
		PanelKeyBindings.gameObject.SetActive(false);
        PanelAudio.gameObject.SetActive(false);

        lineGame.gameObject.SetActive(false);
		lineControls.gameObject.SetActive(true);
		lineVideo.gameObject.SetActive(false);
        lineAudio.gameObject.SetActive(false);
	}

    public void AudioPanel ()
    {
        PanelControls.gameObject.SetActive(false);
        PanelVideo.gameObject.SetActive(false);
        PanelGame.gameObject.SetActive(false);
        PanelKeyBindings.gameObject.SetActive(false);
        PanelAudio.gameObject.SetActive(true);

        lineGame.gameObject.SetActive(false);
        lineControls.gameObject.SetActive(false);
        lineVideo.gameObject.SetActive(false);
        lineAudio.gameObject.SetActive(true);

    }

	public void  KeyBindingsPanel (){
        PanelGeneral.gameObject.SetActive(true);
		PanelControls.gameObject.SetActive(false);
		PanelVideo.gameObject.SetActive(false);
		PanelGame.gameObject.SetActive(false);
		PanelKeyBindings.gameObject.SetActive(true);
        PanelAudio.gameObject.SetActive(false);
        TopButtons.gameObject.SetActive(false);

        KeyButtons.gameObject.SetActive(true);
        lineGame.gameObject.SetActive(true);
        lineControls.gameObject.SetActive(true);
        lineVideo.gameObject.SetActive(false);
        lineAudio.gameObject.SetActive(false);
    }

	public void  MovementPanel (){
		PanelMovement.gameObject.SetActive(true);
		PanelCombat.gameObject.SetActive(false);
		PanelGeneral.gameObject.SetActive(false);
        PanelAudio.gameObject.SetActive(false);

        lineGame.gameObject.SetActive(false);
        lineControls.gameObject.SetActive(true);
        lineVideo.gameObject.SetActive(true);
        lineAudio.gameObject.SetActive(false);
    }

	public void  CombatPanel (){
		PanelMovement.gameObject.SetActive(false);
		PanelCombat.gameObject.SetActive(true);
		PanelGeneral.gameObject.SetActive(false);
        PanelAudio.gameObject.SetActive(false);
        lineGame.gameObject.SetActive(false);
        lineControls.gameObject.SetActive(true);
        lineVideo.gameObject.SetActive(false);
        lineAudio.gameObject.SetActive(true);
    }

	public void  GeneralPanel (){
		PanelMovement.gameObject.SetActive(false);
		PanelCombat.gameObject.SetActive(false);
		PanelGeneral.gameObject.SetActive(true);
        lineGame.gameObject.SetActive(true);
        lineControls.gameObject.SetActive(true);
        lineVideo.gameObject.SetActive(false);
        lineAudio.gameObject.SetActive(false);
    }

	public void  PlayHover (){
		hoverSound.GetComponent<AudioSource>().Play();
	}

	public void  PlaySFXHover (){
		sfxhoversound.GetComponent<AudioSource>().Play();
	}

	public void  PlayClick (){
		clickSound.GetComponent<AudioSource>().Play();
	}

	// Are You Sure - Quit Panel Pop Up
	public void  AreYouSure (){
		PanelareYouSure.gameObject.SetActive(true);
        PlayBtn.gameObject.SetActive(false);
        ExitBtn.gameObject.SetActive(false);
        SettingsBtn.gameObject.SetActive(false);
    }

	public void  No (){
		PanelareYouSure.gameObject.SetActive(false);
        DisablePlayCampaign();
	}

	public void  Yes (){
		Application.Quit();
	}
}