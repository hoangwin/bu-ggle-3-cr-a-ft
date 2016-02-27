﻿using UnityEngine;
using System.Collections;

public class ButtonControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void PuzzleButtonPress()
	{
        AnimControl.instance.menuEnd();
        SoundEngine.playSound("SoundClick");
		//Application.LoadLevel("SelectLevel");
	
	}
    public void MoreGame()
	{
        //SoundEngine.playSound("SoundClick");
		//Application.LoadLevel("GamePlayScence");
        //Application.LoadLevel("About");
        Application.OpenURL("http://aegamemobile.com");
	}
    public void ExitButtonPress()
    {
        Application.Quit();
    }
    public void BackButtonPress()
    {

        SoundEngine.playSound("SoundClick");
        Application.LoadLevel("MainMenu");
    }

	public void PlayInGamePress()
	{
        SoundEngine.playSound("SoundClick");
		GamePlay.changeState (GamePlay.STATE_PLAY);
		GamePlay.instance.PanelPause.SetActive(false);

	}

	public void RestartInGamePress()
	{
        SoundEngine.playSound("SoundClick");
		GamePlay.instance.restart();
		//Application.LoadLevel("GamePlayScence");
		//Debug.Log ("aaaaaaaaaa");
	}
	public void ButtonRatePress()
	{
        SoundEngine.playSound("SoundClick");
		Application.OpenURL ("market://details?id=com.flappy.bird.kiwi");
		//Application.OpenURL ("http://details?id=com.flappy.bird.kiwi");
	}
	public void RankingButtonPress()
	{
        SoundEngine.playSound("SoundClick");
		Application.LoadLevel("Ranking");
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

	public void ReplayButtonPress()
	{
        SoundEngine.playSound("SoundClick");
		GamePlay.instance.restart();
	}

	public void MainMenuButtonPress()
	{
        SoundEngine.playSound("SoundClick");
		Application.LoadLevel ("MainMenu");
	}
	public void NextButtonPress()
	{
        SoundEngine.playSound("SoundClick");
		LevelManager.currentLevel++;
		GamePlay.instance.restart();
	}
    
    public void LeftButtonPress()
    {
        SoundEngine.playSound("SoundClick");
        SelectLevel.currentpage--;
        if (SelectLevel.currentpage < 1)
            SelectLevel.currentpage = SelectLevel.MAX_PAGE;
      SelectLevel.instance.setAllButton();
    
    }

    public void RightButtonPress()
    {
        SoundEngine.playSound("SoundClick");
        SelectLevel.currentpage++;
        if (SelectLevel.currentpage> SelectLevel.MAX_PAGE)
            SelectLevel.currentpage = 1;
        SelectLevel.instance.setAllButton();
    }

	//Select 	Level
	public void LevelButtonPress(int level)
	{
        SoundEngine.playSound("SoundClick");
        level += (SelectLevel.currentpage -1)*20;
        if (level <= ScoreControl.mUnblockLevel)
        {
            LevelManager.currentLevel = level;
            Application.LoadLevel("GamePlayScence");
        }
	}
	public void LevelButtonPress1()
	{
		LevelButtonPress(1);
	}
	public void LevelButtonPress2()
	{
		LevelButtonPress(2);
	}
	public void LevelButtonPress3()
	{
		LevelButtonPress(3);
	}
	public void LevelButtonPress4()
	{
		LevelButtonPress(4);
	}
	public void LevelButtonPress5()
	{
		LevelButtonPress(5);
	}
	public void LevelButtonPress6()
	{
		LevelButtonPress(6);
	}
	public void LevelButtonPress7()
	{
		LevelButtonPress(7);
	}
	public void LevelButtonPress8()
	{
		LevelButtonPress(8);
	}
	public void LevelButtonPress9()
	{
		LevelButtonPress(9);
	}
	public void LevelButtonPress10()
	{
		LevelButtonPress(10);
	}
	public void LevelButtonPress11()
	{
		LevelButtonPress(11);
	}
	public void LevelButtonPress12()
	{
		LevelButtonPress(12);
	}
	public void LevelButtonPress13()
	{
		LevelButtonPress(13);
	}
	public void LevelButtonPress14()
	{
		LevelButtonPress(14);
	}
	public void LevelButtonPress15()
	{
		LevelButtonPress(15);
	}
	public void LevelButtonPress16()
	{
		LevelButtonPress(16);
	}
	public void LevelButtonPress17()
	{
		LevelButtonPress(17);
	}
	public void LevelButtonPress18()
	{
		LevelButtonPress(18);
	}
	public void LevelButtonPress19()
	{
		LevelButtonPress(19);
	}
	public void LevelButtonPress20()
	{
		LevelButtonPress(20);
	}




}
