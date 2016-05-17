using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonControl : MonoBehaviour {

    // Use this for initialization
    public Text m_TextSound;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void PlayButtonPress()
	{
        GamePlay.instance.restart();
	}
    public void ButtonBackMainMenu()
    {
        GamePlay.currentState = GamePlay.STATE_MAINMENU;
        GamePlay.instance.setPannel(GamePlay.instance.PanelMAIN);
        //GamePlay.instance.restart();
    }
    public void ButtonResumePress()
    {
        GamePlay.currentState = GamePlay.STATE_PLAY;
        GamePlay.instance.setPannel(GamePlay.instance.PanelPLAY);
        Time.timeScale = 1;
    }

    public void ButtonPausePress()
    {

        GamePlay.currentState = GamePlay.STATE_PAUSE;
        GamePlay.instance.setPannel(GamePlay.instance.PanelPAUSE);
        Time.timeScale = 0;
    }
    public void ButtonReplayPress()
	{
		GamePlay.instance.restart();
		//Application.LoadLevel("GamePlayScence");
		//Debug.Log ("aaaaaaaaaa");
	}
	public void ButtonRatePress()
	{
#if UNITY_ANDROID
        Application.OpenURL ("market://details?id=com.smashy.reverse.crosy");
        //Application.OpenURL ("http://details?id=com.smashy.reverse.crosy");
#elif UNITY_IOS
        Application.OpenURL("https://itunes.apple.com/us/app/crossy-reverse/id1114686286?ls=1&mt=8");
#endif
    }




    public void ButtonSoundPress()
	{
        SoundEngine.isSound = !SoundEngine.isSound;
        SoundEngine.playSound(SoundEngine.instance.m_SoundClick);
        if (SoundEngine.isSound)
            m_TextSound.text = "SOUND : ON";
        else
            m_TextSound.text = "SOUND : OFF";


    }
    public void ButtonQuitPress()
    {
        Application.Quit();
    }
}
