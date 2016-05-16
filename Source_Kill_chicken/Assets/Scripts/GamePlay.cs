using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class GamePlay : MonoBehaviour {
	GameObject BottomBG;
	//public GameObject BirdObject;
	public static ArrayList ListBirdObject= new ArrayList();
    //  public List<GameObject>  m_ListBirdObject;
    public GameObject PanelMAIN;
    public GameObject PanelPLAY;
    public GameObject PanelPAUSE;
    public GameObject PanelOVER;
    public Animator m_animReadyGo;
	
    public GameObject[] listBirdTemplate;



    public static float speedx = 0.06f ;
	public static GamePlay instance;
	public static int currentState = 0;
	public const int STATE_WATTING = 0;
	public const int STATE_PLAY = 1;
	public const int STATE_MAINMENU = 2;
	public const int STATE_OVER = 3;
    public const int STATE_PAUSE = 4;
    public static float TimePlayedSubState = 0f;
	public static float TimelastCreateBird = 0f;
	public static float TimeOffsetCreateBird = 0f;

    public Text m_TextScoreIngame;
    public Text m_TextScoreBestGameOver;
    public Text m_TextScoreGameOver;
    public Text m_TextScoreBestMainMenu;
    public Text m_TextTapScreen;

    // Use this for initialization
    void Start () {
        instance = this;
        DEF.Init();
        ScoreControl.loadGame();
		currentState = STATE_MAINMENU;
        ScoreControl.setDefaultScore();
        setPannel(PanelMAIN);
        	
		
		//restart ();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		TimePlayedSubState += Time.deltaTime;
        AdsManager.timeShowAds += Time.deltaTime;
        if (Input.GetKeyDown (KeyCode.Escape)) {
            //	Application.LoadLevel ("MainMenu");
            restart();

		}
        // Debug.Log(currentState);
        if (currentState == STATE_WATTING)
        {
            if (TimePlayedSubState > 3)
            {
                m_TextTapScreen.gameObject.SetActive(false);
                GamePlay.currentState = GamePlay.STATE_PLAY;
            }
            
            //Debug.Log("aaaaaaaaaa");
        }

        else
        if (currentState == STATE_PLAY)
        {
           
            if (ListBirdObject.Count < 20 && TimePlayedSubState > TimelastCreateBird + TimeOffsetCreateBird)
            {
                //GameObject a = (GameObject)Instantiate (Resources.Load ("BirdPrefab"));
                int i = Random.Range(0, 10);
                //GameObject a = (GameObject)Instantiate(Resources.Load("PigPrefab"));
                //Debug.Log(i);
                GameObject a = (GameObject)Instantiate(listBirdTemplate[i]);
                a.transform.Translate(0, 0, Random.Range(-3f, 3f));
                a.layer = 11;
                Physics.IgnoreLayerCollision(11, 11, true);


                ListBirdObject.Add(a);

                TimelastCreateBird = TimePlayedSubState;
                TimeOffsetCreateBird = Random.Range(0.2f, 0.5f);
            }
        }	

		GameObject obj;
		for (int i= ListBirdObject.Count-1; i>-1; i--) {
			obj = (GameObject)ListBirdObject [i];
            if(obj == null)
            {
               // Debug.Log("remove");
                ListBirdObject.RemoveAt(i);
                DestroyImmediate(obj);
            }
            else if(!(obj.GetComponent<Player>().isLive))//here
			{
              //  Debug.Log("remove1");
                ListBirdObject.RemoveAt (i);
				Destroy(obj,1);
			}
		}

		

	}
	
	void FixedUpdate()
	{
			if (GamePlay.currentState == GamePlay.STATE_PLAY) {
				
			/*
				for (int i= 0; i<trapList.Count; i++) {
						mobject = (GameObject)trapList [i];
						mobject.transform.localPosition = new Vector3 (mobject.transform.localPosition.x - speedx, mobject.transform.localPosition.y, 1);
				}
				*/
			}	
	}

	public void restart() 
	{
		//GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity,new  Vector3(DEF.scaleX, DEF.scaleY, 1));
		GameObject obj;
		for (int i= ListBirdObject.Count-1; i>-1; i--) {
			obj = (GameObject)ListBirdObject [i];
			ListBirdObject.RemoveAt (i);
			DestroyImmediate (obj);
		}

		instance = this;
		
		//if(GamePlay.currentState == GamePlay.STATE_OVER)
		//	GamePlay.currentState = GamePlay.STATE_PLAY;
		//else
			GamePlay.currentState = GamePlay.STATE_WATTING;
        m_animReadyGo.Play("ReadyGo");
        m_TextTapScreen.gameObject.SetActive(true);



        ScoreControl.setDefaultScore ();

		//BirdObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
		TimelastCreateBird = 0;
		TimePlayedSubState = 0;
		TimeOffsetCreateBird = 0;
		ScoreControl.Score = 0;
		ScoreControl.setDefaultScore();
        GamePlay.instance.m_TextScoreIngame.text = ScoreControl.Score.ToString();
        SoundEngine.playSound(SoundEngine.instance.m_SoundReady);
        GamePlay.currentState = GamePlay.STATE_WATTING;
        setPannel(PanelPLAY);
        //   GameObject.Find("LabelScoreInGame").GetComponent<UILabel>().text = "" + ScoreControl.getRealScore();
        //    GameObject.Find("LabelScoreInGame").GetComponent<UILabel>().text =""+ ScoreControl.getRealScore();
    }
	public void initGameOver()
	{
		BoxCollider [] arraycollider;

       // Debug.Log(ListBirdObject.Count);

        for (int i= 0; i< ListBirdObject.Count; i++) {
            GameObject obj = ((GameObject)ListBirdObject[i]);
            obj.GetComponent<Rigidbody>().GetComponent<Rigidbody>().velocity = new Vector2(0,0);
            obj.GetComponent<Rigidbody>().GetComponent<Rigidbody>().useGravity =false;
            obj.GetComponent<Rigidbody>().GetComponent<Rigidbody>().isKinematic = true;
            obj.transform.localRotation = Quaternion.Euler (new Vector3 (0, 0, 0));


			arraycollider =((GameObject) ListBirdObject[i]).GetComponents<BoxCollider>();
			for(int j =0; j<arraycollider.Length;j++)
				arraycollider[j].enabled = false;
		}

	}
	public void showGameOver()
	{
		currentState = STATE_OVER;
        
        ScoreControl.setBestScore(ScoreControl.Score);
        GamePlay.instance.m_TextScoreGameOver.text = ScoreControl.Score.ToString();
        GamePlay.instance.m_TextScoreBestGameOver.text = ScoreControl.BestScore.ToString();
        setPannel(PanelOVER);
        AdsManager.ShowADS_FULL();
        //GameObject.Find("LabelScore").GetComponent<UILabel>().text =""+ ScoreControl.getRealScore();
        //GameObject.Find("LabelScoreBest").GetComponent<UILabel>().text =""+ ScoreControl.getRealBestScore();

        ScoreControl.saveGame ();
	}
    public void setPannel (GameObject obj)
    {
        if (obj == PanelMAIN)
        {
            PanelMAIN.SetActive(true);
            GamePlay.instance.m_TextScoreBestMainMenu.text = "Best : " + ScoreControl.BestScore.ToString();
        }
        else
            PanelMAIN.SetActive(false);

        if (obj == PanelPLAY)
            PanelPLAY.SetActive(true);
        else
            PanelPLAY.SetActive(false);

        if (obj == PanelPAUSE)
            PanelPAUSE.SetActive(true);
        else
            PanelPAUSE.SetActive(false);

        if (obj == PanelOVER)
            PanelOVER.SetActive(true);
        else
            PanelOVER.SetActive(false);      
    }
}
