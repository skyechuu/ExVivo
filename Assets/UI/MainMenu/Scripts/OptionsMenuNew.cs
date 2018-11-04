using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionsMenuNew : MonoBehaviour {

	// toggle buttons
	public GameObject fullscreentext;
	public GameObject shadowofftext;
	public GameObject shadowofftextLINE;
	public GameObject shadowlowtext;
	public GameObject shadowlowtextLINE;
    public GameObject shadowmedtext;
    public GameObject shadowmedtextLINE;
	public GameObject shadowhightext;
	public GameObject shadowhightextLINE;
	public GameObject difficultynormaltextLINE;
	public GameObject difficultyhardcoretextLINE;
    public GameObject difficultyeasytextLINE;
    public GameObject cameraeffectstext;
	public GameObject invertmousetext;
    public GameObject invertmouseline;
	public GameObject vsynctext;
	public GameObject motionblurtext;
	public GameObject ambientocclusiontext;
	public GameObject texturelowtext;
	public GameObject texturelowtextLINE;
	public GameObject texturemedtext;
	public GameObject texturemedtextLINE;
	public GameObject texturehightext;
	public GameObject texturehightextLINE;
	public GameObject aaofftext;
	public GameObject aaofftextLINE;
	public GameObject aa2xtext;
	public GameObject aa2xtextLINE;
	public GameObject aa4xtext;
	public GameObject aa4xtextLINE;
	public GameObject aa8xtext;
	public GameObject aa8xtextLINE;
    public GameObject vsyncoff_line;
    public GameObject motionoff_line;
    public GameObject ambient_line;
    public GameObject fullscreen_line;
    public GameObject postfx_line;




    // sliders
    public GameObject musicSlider;
	public GameObject sfxSlider;
	public GameObject sensitivityXSlider;
	public GameObject sensitivityYSlider;
	public GameObject mouseSmoothSlider;

	private float sliderValue = 0.0f;
	private float sliderValueSFX = 0.0f;
	private float sliderValueXSensitivity = 0.0f;
	private float sliderValueYSensitivity = 0.0f;
	private float sliderValueSmoothing = 0.0f;

    public void Start() {
        // check difficulty
        if (PlayerPrefs.GetInt("NormalDifficulty") == 1)
        {
            difficultynormaltextLINE.gameObject.SetActive(true);
            difficultyhardcoretextLINE.gameObject.SetActive(false);
            difficultyeasytextLINE.gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("HardCoreDifficulty") == 1)
        {
            //difficultynormaltext.GetComponent<Text>().text = "normal";
            //difficultyhardcoretext.GetComponent<Text>().text = "HARDCORE";
            difficultyhardcoretextLINE.gameObject.SetActive(true);
            difficultynormaltextLINE.gameObject.SetActive(false);
            difficultyeasytextLINE.gameObject.SetActive(false);
        }

        else if (PlayerPrefs.GetInt("EasyDifficulty") == 1)
        {
            //difficultynormaltext.GetComponent<Text>().text = "normal";
            //difficultyhardcoretext.GetComponent<Text>().text = "HARDCORE";
            difficultyhardcoretextLINE.gameObject.SetActive(false);
            difficultynormaltextLINE.gameObject.SetActive(false);
            difficultyeasytextLINE.gameObject.SetActive(true);

        }

        // check slider values
        musicSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("MusicVolume");
        sfxSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("SFXVolume");
        sensitivityXSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("XSensitivity");
        sensitivityYSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("YSensitivity");
        mouseSmoothSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("MouseSmoothing");

        // check full screen
        if (Screen.fullScreen == true) {
            fullscreentext.GetComponent<Text>().text = "On";
        }
        else if (Screen.fullScreen == false) {
            fullscreentext.GetComponent<Text>().text = "Off";
        }


        

        // check shadow distance/enabled
        if (PlayerPrefs.GetInt("Shadows") == 0) {
            QualitySettings.shadowCascades = 0;
            QualitySettings.shadowDistance = 0;
            shadowofftext.GetComponent<Text>().text = "Off";
            shadowlowtext.GetComponent<Text>().text = "Low";
            shadowmedtext.GetComponent<Text>().text = "Medium";
            shadowhightext.GetComponent<Text>().text = "High";
            shadowofftextLINE.gameObject.SetActive(true);
            shadowlowtextLINE.gameObject.SetActive(false);
            shadowhightextLINE.gameObject.SetActive(false);
            shadowmedtextLINE.gameObject.SetActive(false);
            shadowmedtext.gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Shadows") == 1) {
            QualitySettings.shadowCascades = 0;
            QualitySettings.shadowDistance = 20;
            shadowofftext.GetComponent<Text>().text = "Off";
            shadowlowtext.GetComponent<Text>().text = "Low";
            shadowmedtext.GetComponent<Text>().text = "Medium";
            shadowhightext.GetComponent<Text>().text = "High";
            shadowofftextLINE.gameObject.SetActive(false);
            shadowlowtextLINE.gameObject.SetActive(true);
            shadowhightextLINE.gameObject.SetActive(false);
            shadowmedtextLINE.gameObject.SetActive(false);
            shadowmedtext.gameObject.SetActive(false);

        }

        else if (PlayerPrefs.GetInt("Shadows") == 2) {
            QualitySettings.shadowCascades = 2;
        QualitySettings.shadowDistance = 40;
        shadowofftext.GetComponent<Text>().text = "Off";
        shadowlowtext.GetComponent<Text>().text = "Low";
        shadowmedtext.GetComponent<Text>().text = "Medium";
        shadowhightext.GetComponent<Text>().text = "High";
        shadowofftextLINE.gameObject.SetActive(false);
        shadowlowtextLINE.gameObject.SetActive(false);
        shadowhightextLINE.gameObject.SetActive(false);
        shadowmedtextLINE.gameObject.SetActive(true);
        shadowmedtext.gameObject.SetActive(true);
        }

		else if(PlayerPrefs.GetInt("Shadows") == 3){
			QualitySettings.shadowCascades = 4;
			QualitySettings.shadowDistance = 150;
			shadowofftext.GetComponent<Text>().text = "Off";
			shadowlowtext.GetComponent<Text>().text = "Low";
            shadowmedtext.GetComponent<Text>().text = "Medium";
            shadowhightext.GetComponent<Text>().text = "High";
			shadowofftextLINE.gameObject.SetActive(false);
			shadowlowtextLINE.gameObject.SetActive(false);
			shadowhightextLINE.gameObject.SetActive(true);
            shadowmedtextLINE.gameObject.SetActive(false);
            shadowmedtext.gameObject.SetActive(false);
        }

		// check vsync
		if(QualitySettings.vSyncCount == 0){
			vsynctext.GetComponent<Text>().text = "Off";
           
        }
		else if(QualitySettings.vSyncCount == 1){
			vsynctext.GetComponent<Text>().text = "On";

        }

		// check mouse inverse
		if(PlayerPrefs.GetInt("Inverted")==0){
			invertmousetext.GetComponent<Text>().text = "Off";
            invertmouseline.gameObject.SetActive(false);
		}
		else if(PlayerPrefs.GetInt("Inverted")==1){
			invertmousetext.GetComponent<Text>().text = "On";
            invertmouseline.gameObject.SetActive(true);
        }

		// check motion blur
		if(PlayerPrefs.GetInt("MotionBlur")==0){
			motionblurtext.GetComponent<Text>().text = "Off";
		}
		else if(PlayerPrefs.GetInt("MotionBlur")==1){
			motionblurtext.GetComponent<Text>().text = "On";
		}

		// check ambient occlusion
		if(PlayerPrefs.GetInt("AmbientOcclusion")==0){
			ambientocclusiontext.GetComponent<Text>().text = "Off";
		}
		else if(PlayerPrefs.GetInt("AmbientOcclusion")==1){
			ambientocclusiontext.GetComponent<Text>().text = "On";
		}

		// check texture quality
		if(PlayerPrefs.GetInt("Textures") == 0){
			QualitySettings.masterTextureLimit = 2;
			texturelowtext.GetComponent<Text>().text = "Low";
			texturemedtext.GetComponent<Text>().text = "Medium";
			texturehightext.GetComponent<Text>().text = "High";
			texturelowtextLINE.gameObject.SetActive(true);
			texturemedtextLINE.gameObject.SetActive(false);
			texturehightextLINE.gameObject.SetActive(false);
		}
		else if(PlayerPrefs.GetInt("Textures") == 1){
			QualitySettings.masterTextureLimit = 1;
			texturelowtext.GetComponent<Text>().text = "Low";
            texturemedtext.GetComponent<Text>().text = "Medium";
			texturehightext.GetComponent<Text>().text = "High";
			texturelowtextLINE.gameObject.SetActive(false);
			texturemedtextLINE.gameObject.SetActive(true);
			texturehightextLINE.gameObject.SetActive(false);
		}
		else if(PlayerPrefs.GetInt("Textures") == 2){
			QualitySettings.masterTextureLimit = 0;
			texturelowtext.GetComponent<Text>().text = "Low";
			texturemedtext.GetComponent<Text>().text = "Med";
			texturehightext.GetComponent<Text>().text = "High";
			texturelowtextLINE.gameObject.SetActive(false);
			texturemedtextLINE.gameObject.SetActive(false);
			texturehightextLINE.gameObject.SetActive(true);
		}
	}

	public void  Update (){
		sliderValue = musicSlider.GetComponent<Slider>().value;
		sliderValueSFX = sfxSlider.GetComponent<Slider>().value;
		sliderValueXSensitivity = sensitivityXSlider.GetComponent<Slider>().value;
		sliderValueYSensitivity = sensitivityYSlider.GetComponent<Slider>().value;
		sliderValueSmoothing = mouseSmoothSlider.GetComponent<Slider>().value;
	}

	public void  FullScreen (){
		Screen.fullScreen = !Screen.fullScreen;

		if(Screen.fullScreen == true){
			fullscreentext.GetComponent<Text>().text = "On";
            fullscreen_line.gameObject.SetActive(true);
        }
		else if(Screen.fullScreen == false){
			fullscreentext.GetComponent<Text>().text = "Off";
            fullscreen_line.gameObject.SetActive(false);
        }
	}

	public void  MusicSlider (){
		PlayerPrefs.SetFloat("MusicVolume", sliderValue);
	}

	public void  SFXSlider (){
		PlayerPrefs.SetFloat("SFXVolume", sliderValueSFX);
	}

	public void  SensitivityXSlider (){
		PlayerPrefs.SetFloat("XSensitivity", sliderValueXSensitivity);
	}

	public void  SensitivityYSlider (){
		PlayerPrefs.SetFloat("YSensitivity", sliderValueYSensitivity);
	}

	public void  SensitivitySmoothing (){
		PlayerPrefs.SetFloat("MouseSmoothing", sliderValueSmoothing);
		Debug.Log(PlayerPrefs.GetFloat("MouseSmoothing"));
	}

    public void EasyDifficulty()
    {
        //difficultynormaltext.GetComponent<Text>().text = "NORMAL";
        //difficultyhardcoretext.GetComponent<Text>().text = "hardcore";
        difficultyhardcoretextLINE.gameObject.SetActive(false);
        difficultynormaltextLINE.gameObject.SetActive(false);
        difficultyeasytextLINE.gameObject.SetActive(true);
        PlayerPrefs.SetInt("EasyDifficulty", 1);
        PlayerPrefs.SetInt("NormalDifficulty", 0);
        PlayerPrefs.SetInt("HardCoreDifficulty", 0);

    }

        public void  NormalDifficulty (){
		//difficultynormaltext.GetComponent<Text>().text = "NORMAL";
		//difficultyhardcoretext.GetComponent<Text>().text = "hardcore";
		difficultyhardcoretextLINE.gameObject.SetActive(false);
		difficultynormaltextLINE.gameObject.SetActive(true);
        difficultyeasytextLINE.gameObject.SetActive(false);
        PlayerPrefs.SetInt("EasyDifficulty", 0);
        PlayerPrefs.SetInt("NormalDifficulty",1);
		PlayerPrefs.SetInt("HardCoreDifficulty",0);
	}

	public void  HardcoreDifficulty (){
		//difficultynormaltext.GetComponent<Text>().text = "normal";
		//difficultyhardcoretext.GetComponent<Text>().text = "HARDCORE";
		difficultyhardcoretextLINE.gameObject.SetActive(true);
		difficultynormaltextLINE.gameObject.SetActive(false);
        difficultyeasytextLINE.gameObject.SetActive(false);
        PlayerPrefs.SetInt("NormalDifficulty",0);
		PlayerPrefs.SetInt("HardCoreDifficulty",1);
        PlayerPrefs.SetInt("EasyDifficulty", 0);
    }

	public void  ShadowsOff (){
		PlayerPrefs.SetInt("Shadows",0);
		QualitySettings.shadowCascades = 0;
		QualitySettings.shadowDistance = 0;
		shadowofftext.GetComponent<Text>().text = "Off";
		shadowlowtext.GetComponent<Text>().text = "Low";
        shadowmedtext.GetComponent<Text>().text = "Medium";
        shadowhightext.GetComponent<Text>().text = "High";
		shadowofftextLINE.gameObject.SetActive(true);
        shadowlowtextLINE.gameObject.SetActive(false);
        shadowmedtextLINE.gameObject.SetActive(false);
		shadowhightextLINE.gameObject.SetActive(false);
	}

	public void  ShadowsLow (){
		PlayerPrefs.SetInt("Shadows",1);
		QualitySettings.shadowCascades = 0;
		QualitySettings.shadowDistance = 15;
		shadowofftext.GetComponent<Text>().text = "Off";
		shadowlowtext.GetComponent<Text>().text = "Low";
        shadowmedtext.GetComponent<Text>().text = "Medium";
        shadowhightext.GetComponent<Text>().text = "High";
		shadowofftextLINE.gameObject.SetActive(false);
		shadowlowtextLINE.gameObject.SetActive(true);
        shadowmedtextLINE.gameObject.SetActive(false);
        shadowhightextLINE.gameObject.SetActive(false);
	}

    public void ShadowMed()
    {
        PlayerPrefs.SetInt("Shadows", 1);
        QualitySettings.shadowCascades = 2;
        QualitySettings.shadowDistance = 40;
        shadowofftext.GetComponent<Text>().text = "Off";
        shadowlowtext.GetComponent<Text>().text = "Low";
        shadowmedtext.GetComponent<Text>().text = "Medium";
        shadowhightext.GetComponent<Text>().text = "High";
        shadowofftextLINE.gameObject.SetActive(false);
        shadowlowtextLINE.gameObject.SetActive(false);
        shadowmedtext.gameObject.SetActive(true);
        shadowmedtextLINE.gameObject.SetActive(true);
        shadowhightextLINE.gameObject.SetActive(false);
    }

    public void  ShadowsHigh (){
		PlayerPrefs.SetInt("Shadows",2);
		QualitySettings.shadowCascades = 4;
		QualitySettings.shadowDistance = 500;
		shadowofftext.GetComponent<Text>().text = "Off";
		shadowlowtext.GetComponent<Text>().text = "Low";
        shadowmedtext.GetComponent<Text>().text = "Medium";
        shadowhightext.GetComponent<Text>().text = "High";
		shadowofftextLINE.gameObject.SetActive(false);
		shadowlowtextLINE.gameObject.SetActive(false);
		shadowhightextLINE.gameObject.SetActive(true);
        shadowhightext.gameObject.SetActive(true);
        shadowmedtextLINE.gameObject.SetActive(false);
    }

	public void  vsync (){
		if(QualitySettings.vSyncCount == 0){
			QualitySettings.vSyncCount = 1;
			vsynctext.GetComponent<Text>().text = "On";
            vsyncoff_line.gameObject.SetActive(true);
        }
		else if(QualitySettings.vSyncCount == 1){
			QualitySettings.vSyncCount = 0;
			vsynctext.GetComponent<Text>().text = "Off";
            vsyncoff_line.gameObject.SetActive(false);
        }
	}

	public void  InvertMouse (){
		if(PlayerPrefs.GetInt("Inverted")==0){
			PlayerPrefs.SetInt("Inverted",1);
			invertmousetext.GetComponent<Text>().text = "On";
		}
		else if(PlayerPrefs.GetInt("Inverted")==1){
			PlayerPrefs.SetInt("Inverted",0);
			invertmousetext.GetComponent<Text>().text = "Off";
		}
	}

	public void  MotionBlur (){
		if(PlayerPrefs.GetInt("MotionBlur")==0){
			PlayerPrefs.SetInt("MotionBlur",1);
			motionblurtext.GetComponent<Text>().text = "On";
            motionoff_line.gameObject.SetActive(true);
        }
		else if(PlayerPrefs.GetInt("MotionBlur")==1){
			PlayerPrefs.SetInt("MotionBlur",0);
			motionblurtext.GetComponent<Text>().text = "Off";
            motionoff_line.gameObject.SetActive(false);
        }
	}

	public void  AmbientOcclusion (){
		if(PlayerPrefs.GetInt("AmbientOcclusion")==0){
			PlayerPrefs.SetInt("AmbientOcclusion",1);
			ambientocclusiontext.GetComponent<Text>().text = "On";
            ambient_line.gameObject.SetActive(true);
		}
		else if(PlayerPrefs.GetInt("AmbientOcclusion")==1){
			PlayerPrefs.SetInt("AmbientOcclusion",0);
			ambientocclusiontext.GetComponent<Text>().text = "Off";
            ambient_line.gameObject.SetActive(false);
        }
	}

	public void  CameraEffects (){
		if(PlayerPrefs.GetInt("CameraEffects")==0){
			PlayerPrefs.SetInt("CameraEffects",1);
			cameraeffectstext.GetComponent<Text>().text = "On";
            postfx_line.gameObject.SetActive(true);

        }
		else if(PlayerPrefs.GetInt("CameraEffects")==1){
			PlayerPrefs.SetInt("CameraEffects",0);
			cameraeffectstext.GetComponent<Text>().text = "Off";
            postfx_line.gameObject.SetActive(false);
        }
	}

	public void  TexturesLow (){
		PlayerPrefs.SetInt("Textures",0);
		QualitySettings.masterTextureLimit = 2;
		texturelowtext.GetComponent<Text>().text = "Low";
		texturemedtext.GetComponent<Text>().text = "Medium";
		texturehightext.GetComponent<Text>().text = "High";
		texturelowtextLINE.gameObject.SetActive(true);
		texturemedtextLINE.gameObject.SetActive(false);
		texturehightextLINE.gameObject.SetActive(false);
	}

	public void  TexturesMed (){
		PlayerPrefs.SetInt("Textures",1);
		QualitySettings.masterTextureLimit = 1;
		texturelowtext.GetComponent<Text>().text = "Low";
		texturemedtext.GetComponent<Text>().text = "Medium";
		texturehightext.GetComponent<Text>().text = "High";
		texturelowtextLINE.gameObject.SetActive(false);
		texturemedtextLINE.gameObject.SetActive(true);
		texturehightextLINE.gameObject.SetActive(false);
	}

	public void  TexturesHigh (){
		PlayerPrefs.SetInt("Textures",2);
		QualitySettings.masterTextureLimit = 0;
		texturelowtext.GetComponent<Text>().text = "Low";
		texturemedtext.GetComponent<Text>().text = "Medium";
		texturehightext.GetComponent<Text>().text = "High";
		texturelowtextLINE.gameObject.SetActive(false);
		texturemedtextLINE.gameObject.SetActive(false);
		texturehightextLINE.gameObject.SetActive(true);
	}
}