using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {
	// Use this for initialization

	public static MainMenu instance;
    public Sprite m_SpriteOn;
    public Sprite m_SpriteOff;
    public Image m_ImageSound;
    void Start () {
		DEF.Init ();
		DEF.ScaleAnchorGui();
		ScoreManager.Load();
		setBGButton ();
		instance = this;
        if (SoundEngine.soundclick == null)
        {
            SoundEngine.soundclick = GameObject.Find("SoundClick");
            DontDestroyOnLoad(SoundEngine.soundclick);
        }
        //  DEF.scaleFixImagetoScreen(background);
        if (AnimControl.instance != null)
            AnimControl.instance.MenuBegin();
        //Debug.Log("aaaaaaaaa");
	}	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
	public void setBGButton()
	{
	//	GameObject bgButton = GameObject.Find("LabelSoundOnOff");
    //    Text target = bgButton.GetComponentInChildren<Text>();

        if (SoundEngine.isSound)
            m_ImageSound.overrideSprite = m_SpriteOn;//  target.text = "Âm Thanh : Bật";
		else
            m_ImageSound.overrideSprite = m_SpriteOff;//target.text = "Âm Thanh : Tắt";
                                                     //target.MakePixelPerfect();
    }
}
