using UnityEngine;
using System.Collections;

public class ButtonControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void ButtonPlayGamePress()
	{
        AnimControl.instance.menuEnd();
        SoundEngine.playBubbleEffect(SoundEngine.instance.m_click);
        //Application.LoadLevel("SelectLevel");

    }
    public void ButtonMoreGame()
	{
        //SoundEngine.playSound("SoundClick");
		//Application.LoadLevel("GamePlayScence");
        //Application.LoadLevel("About");
        Application.OpenURL("http://aegamemobile.com");
	}
    public void ButtonExitButtonPress()
    {
        Application.Quit();
    }
    public void BackButtonPress()
    {

        SoundEngine.playBubbleEffect(SoundEngine.instance.m_click);
        GamePlay.instance.ChangeToBlack_MaiMENU();
    }

	public void ButtonPlayInGamePress()
	{
        SoundEngine.playBubbleEffect(SoundEngine.instance.m_click);
        GamePlay.changeState (GamePlay.STATE_PLAY);
		GamePlay.instance.PanelPause.SetActive(false);

	}

	public void ButtonRestartInGamePress()
	{
        SoundEngine.playBubbleEffect(SoundEngine.instance.m_click);
        GamePlay.instance.restart();
		//Application.LoadLevel("GamePlayScence");
		//Debug.Log ("aaaaaaaaaa");
	}
	public void ButtonRatePress()
	{
        SoundEngine.playBubbleEffect(SoundEngine.instance.m_click);
#if UNITY_ANDROID
        Application.OpenURL ("market://details?id=com.lamstudio.bubble.craft");
        //Application.OpenURL ("http://details?id=com.flappy.bird.kiwi");
#elif UNITY_IOS
        Application.OpenURL ("https://itunes.apple.com/us/app/bubble-shooter-craft-style/id1090645861?ls=1&mt=8");
        
#else 
       WP8Statics.RateApp("Test");

#endif
    }


    public void ButtonSoundPress()
	{
		SoundEngine.isSoundSFX = !SoundEngine.isSoundSFX;
        SoundEngine.playBubbleEffect(SoundEngine.instance.m_click);
        MainMenu.instance.setBGButton ();
	}

	public void IGMButtonPress()
	{
        SoundEngine.playBubbleEffect(SoundEngine.instance.m_click);
        if (GamePlay.currentState == GamePlay.STATE_PLAY)
        {
            GamePlay.changeState(GamePlay.STATE_PAUSE);
            GamePlay.instance.PanelPause.SetActive(true);
        }
	}

	public void ButtonReplayPress()
	{
        SoundEngine.playBubbleEffect(SoundEngine.instance.m_click);
        GamePlay.instance.restart();
	}

	public void ButtonMainMenuPress()
	{
        SoundEngine.playBubbleEffect(SoundEngine.instance.m_click);
        GamePlay.instance.ChangeToBlack_MaiMENU();
    }
	public void ButtonNextPress()
	{
        SoundEngine.playBubbleEffect(SoundEngine.instance.m_click);
        LevelManager.currentLevel++;
		GamePlay.instance.restart();
	}
    
    public void LeftButtonPress()
    {
       // SoundEngine.playSound("SoundClick");
        SelectStage.m_page--;
        if (SelectStage.m_page < 1)
            SelectStage.m_page = SelectStage.MAX_PAGE;
        SelectStage.m_Instance.ChangePage();
    
    }

    public void RightButtonPress()
    {
        //SoundEngine.playSound("SoundClick");
        SelectStage.m_page++;
        if (SelectStage.m_page > SelectStage.MAX_PAGE)
            SelectStage.m_page = 1;
        SelectStage.m_Instance.ChangePage();
    }

	//Select 	Level
	




}
