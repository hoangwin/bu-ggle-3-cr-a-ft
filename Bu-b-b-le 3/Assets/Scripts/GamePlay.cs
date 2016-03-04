using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GamePlay : MonoBehaviour {

	public GameObject PanelOverGame;
	public GameObject PanelWin;
	public GameObject PanelPause;
    public GameObject Gunner;
    public GameObject BubblePre;

    public Sprite SpriteStar1;
    public Sprite SpriteStar2;
    public Sprite SpriteStar3;
	//public static float speedx = 0.06f ;
	public static GamePlay instance;

	//state
	public static int currentState = 0;
	public static int nextState = 0;
	public const int STATE_WATTING = 0;
	public const int STATE_PLAY = 1;
	public const int STATE_DROP = 2;
	public const int STATE_OVER = 3;
	public const int STATE_PAUSE = 4;
	public const int STATE_WAITING_WIN_LOSE = 5;
	public const int STATE_WIN = 6;
	public const int STATE_LOSE = 7;
    //end state
    public bool m_isItween;
    public static float TimePlayedSubState = 0f;
	
	public  Transform m_TransformcurrentBubble;
    public Transform m_TransforPreBubble;
    public Text m_TextStateInGame;
    public Text m_TextScoreIngame;
    public Text m_TextStateWin;
    public Text m_TextStateLose;
    public static int STATE_INIT = 0;
	public static bool isWin = true;
	//public UILabel LabelLevel;
	//public UILabel LabelScore;

 //   public Animator GunnerAnim;
	void Start () {

		DEF.Init();


		instance = this;
        DEF.ScaleAnchorGui();
       // GameObject.Find("WallBottom").layer = 12;
       // Physics2D.IgnoreLayerCollision(12, 12, true);

        restart();
    }
	
	// Update is called once per frame
	void Update () 
	{
		TimePlayedSubState += Time.deltaTime;
        AdsManager.timeShowAds += Time.deltaTime;
		if (Input.GetKeyDown (KeyCode.Escape)) {				
                if (currentState == STATE_PLAY)
                {
                    GamePlay.changeState(GamePlay.STATE_PAUSE);
                    GamePlay.instance.PanelPause.SetActive(true);
                }
                else if (currentState == STATE_PAUSE)
                {
                    GamePlay.changeState(GamePlay.STATE_PLAY);
                    GamePlay.instance.PanelPause.SetActive(false);
                }
                else
                {
                ChangeToBlack_MaiMENU();
                    
                }
		}
        //		Debug.Log(currentState);
        switch (currentState)
        {




            case GamePlay.STATE_PLAY:
                shootBubble();
                LevelManager.UpdatekMoveWall();
                break;
            case GamePlay.STATE_WAITING_WIN_LOSE:
                if (TimePlayedSubState < 2)
                    break;

                if (isWin)
                {

                    PanelWin.SetActive(true);
                    m_TextStateWin.text = "STATE " + LevelManager.currentLevel.ToString();
                    if (ScoreManager.m_LevelUNblock == null)
                        ScoreManager.Load();
                    //  GameObject.Find("LabelScoreWin").GetComponent<UILabel>().text = ScoreControl.Score.ToString();
                    if (ScoreManager.m_LevelUNblock.NUM == LevelManager.currentLevel)
                    {
                        ScoreManager.m_LevelUNblock.NUM++;
                    }

                    //kiem tra star

                    int star = 0;
                    if (LevelManager.countbubbleShoot <= LevelManager.star3)
                    {
                        star = 3;
                        GameObject.Find("Star").GetComponent<Image>().sprite = SpriteStar3;
                    }
                    else if (LevelManager.countbubbleShoot <= LevelManager.star2)
                    {
                        star = 2;
                        GameObject.Find("Star").GetComponent<Image>().sprite = SpriteStar2;
                    }
                    else
                    {
                        star = 1;
                        GameObject.Find("Star").GetComponent<Image>().sprite = SpriteStar1;
                    }


                    //ScoreManager.strLevelStar = ScoreManager.strLevelStar.Insert(LevelManager.currentLevel, star.ToString());

                    // ScoreManager.strLevelStar = ScoreManager.strLevelStar.Remove(LevelManager.currentLevel + 1,1);

                    ScoreManager.Save();

                    changeState(STATE_WIN);
                    AdsManager.ShowADS_FULL();
                }
                else
                {
                    PanelOverGame.SetActive(true);
                    m_TextStateLose.text = "STATE " + LevelManager.currentLevel.ToString();
                    changeState(STATE_LOSE);
                }

                break;
        }

		if(nextState != currentState)
		{
			currentState = nextState;
			return;
		}
	}
	public static void changeState(int State)
	{
		nextState = State;
	}
	void FixedUpdate()
	{

	}

	public void shootBubble()
	{      
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0) || Input.GetMouseButton(0)||
            ((Input.touchCount == 1) && (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Ended)))
        {
            Vector2 fingerPos = new Vector2(0, 0);
            if (Input.touchCount == 1)
            {
                fingerPos = Input.GetTouch(0).position;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                fingerPos = Input.mousePosition;
            }
          //  Debug.Log("fingerPos.y1 : " + fingerPos.y);
            if (fingerPos.y == 0 || (fingerPos.y > (9*Screen.height / 10))) // 4.1 || fingerPos.y < -2)
                return;
           
            
            //Debug.Log("aaaa:" + fingerPos.x + "  ,  " + fingerPos.y);
            Vector2 posCurrent = Camera.main.WorldToScreenPoint(m_TransformcurrentBubble.position);
            //fingerPos = Camera.main.WorldToScreenPoint(fingerPos);           

            //  Debug.Log("fingerPos.y : " + fingerPos.y);
            fingerPos.x = fingerPos.x - posCurrent.x;// CURRENT_START_Y;
            fingerPos.y = fingerPos.y - posCurrent.y;// CURRENT_START_Y;

           
            //Debug.Log("rrr:"+fingerPos.x+"  ,  "+fingerPos.y + "  ,  " + fingerPos.z);
            float Max = 15*4f;

            if (Mathf.Abs(fingerPos.x) > Mathf.Abs(fingerPos.y))
            {
                fingerPos.y = Mathf.Abs(fingerPos.y / fingerPos.x * Max);
                fingerPos.x = fingerPos.x / Mathf.Abs(fingerPos.x) * Max;
            }
            else
            {
                fingerPos.x = fingerPos.x / Mathf.Abs(fingerPos.y) * Max;
                fingerPos.y = Max;
            }

          
            float angle = -Mathf.Atan2(fingerPos.x, fingerPos.y) * 180 / Mathf.PI;
         //   Debug.Log("fingerPos : " + fingerPos.x +"," + fingerPos.y);
         
         //   Debug.Log("angle : " + angle);
            Gunner.transform.eulerAngles = new Vector3(0, 0, angle);
             LevelManager.currentBubble.transform.eulerAngles = new Vector3(0, 0, angle);
            if (LevelManager.currentBubble.GetComponent<Bubble>().state == Bubble.STATE_BUBBLE_WATING_SHOOT)
            {             
                if (Input.GetMouseButtonUp(0) || ((Input.touchCount == 1) && (Input.GetTouch(0).phase == TouchPhase.Ended)))
                {
                    SoundEngine.playCommondEffect(SoundEngine.instance.m_shoot);
                    LevelManager.countbubbleShoot++;
                    LevelManager.currentBubble.layer =LayerMask.NameToLayer("Bubble");
                    LevelManager.currentBubble.GetComponent<Rigidbody2D>().velocity = fingerPos;//
                    LevelManager.currentBubble.GetComponent<Bubble>().currentvelocity = fingerPos;//
                    LevelManager.currentBubble.transform.eulerAngles = new Vector3(0, 0, 0);
                    LevelManager.currentBubble.GetComponent<Bubble>().state = Bubble.STATE_BUBBLE_SHOOT;
                    iTween.MoveTo(BubblePre, iTween.Hash("x", m_TransformcurrentBubble.position.x,"y", m_TransformcurrentBubble.position.y, "time", 1f));
                }
            }
        }
	
	}

	public void restart() 
	{
        ScoreManager.Score = 0;
        if (LevelManager.currentLevel < 1)
            LevelManager.currentLevel = 1;
        if (LevelManager.currentLevel >= 680)
            LevelManager.currentLevel = 680;

        LevelManager.getLevel(LevelManager.currentLevel);


        PanelPause.SetActive(false);
        PanelWin.SetActive(false);
        PanelOverGame.SetActive(false);
        changeState(GamePlay.STATE_PLAY);

        m_TextStateInGame.text = "State " + LevelManager.currentLevel.ToString();
        m_TextScoreIngame.text = "0";
        GameObject.Destroy(LevelManager.currentBubble);
        LevelManager.creatNewBubbleBegin();
        //BubblePre.layer = 12;
    }
	public void initGameOver()
	{
//		BoxCollider2D [] arraycollider;
		//for (int i= trapList.Count-1; i>-1; i--) {
		//	arraycollider =((GameObject) trapList[i]).GetComponents<BoxCollider2D>();
		//	for(int j =0; j<arraycollider.Length;j++)
		//		arraycollider[j].enabled = false;
		//}
	}
    public void ChangeToBlack_MaiMENU()
    {
        m_isItween = true;
        iTween.ValueTo(this.gameObject, iTween.Hash("from", 0, "to", 1, "time", 0.5, "onupdate", "OnColorUpdated", "oncomplete", "onCompletedMainMenu"));

    }
    private void OnColorUpdated(float color)
    {
        //   m_Panel.color = new Color(0x00, 0x00, 0x00,color);
        // Debug.Log("aaa");//  targetSpriteRenderer.color = color;
    }
    
    public void onCompletedMainMenu()
    {
        Application.LoadLevel("MainMenu");
    }

}
