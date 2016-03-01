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
        SoundEngine.playSound("SoundClick");
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

        SoundEngine.playSound("SoundClick");
        Application.LoadLevel("MainMenu");
    }

	public void ButtonPlayInGamePress()
	{
        SoundEngine.playSound("SoundClick");
		GamePlay.changeState (GamePlay.STATE_PLAY);
		GamePlay.instance.PanelPause.SetActive(false);

	}

	public void ButtonRestartInGamePress()
	{
        SoundEngine.playSound("SoundClick");
		GamePlay.instance.restart();
		//Application.LoadLevel("GamePlayScence");
		//Debug.Log ("aaaaaaaaaa");
	}
	public void ButtonRatePress()
	{
        SoundEngine.playSound("SoundClick");
		Application.OpenURL ("market://details?id=com.lamstudio.bubble.craft");
		//Application.OpenURL ("http://details?id=com.flappy.bird.kiwi");
	}
	

	public void ButtonSoundPress()
	{
		SoundEngine.isSound = !SoundEngine.isSound;
        SoundEngine.playSound("SoundClick");
		MainMenu.instance.setBGButton ();
	}

	public void IGMButtonPress()
	{
        SoundEngine.playSound("SoundClick");
        if (GamePlay.currentState == GamePlay.STATE_PLAY)
        {
            GamePlay.changeState(GamePlay.STATE_PAUSE);
            GamePlay.instance.PanelPause.SetActive(true);
        }
	}

	public void ButtonReplayPress()
	{
        SoundEngine.playSound("SoundClick");
		GamePlay.instance.restart();
	}

	public void ButtonMainMenuPress()
	{
        SoundEngine.playSound("SoundClick");
		Application.LoadLevel ("MainMenu");
	}
	public void ButtonNextPress()
	{
        SoundEngine.playSound("SoundClick");
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
