using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class SelectStage : MonoBehaviour {    
    // Use this for initialization
    public int m_SelectLevel = 0;
    public int m_Index = 0;
    public static int m_page = 0;
    public Transform[] m_Postion;    
    public static SelectStage m_Instance;
    public Text m_TextPage;
    float axisValue = 0;
    public static int MAX_PAGE = 34;
    public Image m_Panel;
    public bool m_isItween;
    void Awake()
    {
        m_Instance = this;

        // Debug.Log("cccc");
    }
    void Start() {
        m_Instance = this;
        if (ScoreManager.m_LevelUNblock == null)
            ScoreManager.Load();
        m_page = 0;
        m_isItween = false;
        SelectStage.m_Instance.m_TextPage.text = (SelectStage.m_page + 1).ToString() + "/" + MAX_PAGE.ToString();
        ChangePage();
    }
    
    // Update is called once per frame
    void Update() {

        if (!m_isItween)
            if (Input.GetKeyUp(KeyCode.Escape))
            {

                //  SoundEngine.m_Instancce.PlaySoundCLick();
                //Debug.Log("aaaaaaaaaaaa");
                //Time.timeScale = 1;
                SceneManager.LoadScene("MainMenu");
            }
    }
    public void ChangePage()
    {
        // Debug.Log("aa");

        for (int i = 0; i < 20; i++)
        {

            if (m_page * 20 + i + 1 > ScoreManager.m_LevelUNblock.NUM)
            {
                m_Postion[i].GetComponent<Button>().interactable = false;
            }
            else
            {
                m_Postion[i].GetComponent<Button>().interactable = true;
            }

            m_Postion[i].GetComponent<SelectLevelButton>().UpdateText();
        }
        if (m_page * 20 + m_Index + 1 <= ScoreManager.m_LevelUNblock.NUM)
        {

        }
        else {
            if (m_page * 20 + 1 <= ScoreManager.m_LevelUNblock.NUM)
                m_Index = ScoreManager.m_LevelUNblock.NUM - 1 - m_page * 20;
        }
    }
    public void ButtonExit()
    {
        //if (TransitEffect.m_Instance.m_isEffecting)
        //    return;
        // TransitEffect.m_Instance.TranSitBlack(TransitEffect.TYPE_TRANSIT.MAIN_MENU);
     //   MainMenu.m_Instance.ActivePanel(MainMenu.m_Instance.m_PanelMainMenu);
    }

    public void ButtonLeft()
    {
        if (m_isItween)
            return;
            // if (TransitEffect.m_Instance.m_isEffecting)
            //     return;
            SelectStage.m_page--;
        if (SelectStage.m_page < 0)
            SelectStage.m_page = MAX_PAGE-1;
        //SelectStage.m_Instance.m_Index = 12 + SelectStage.m_Instance.m_Index;
        SelectStage.m_Instance.m_TextPage.text = (SelectStage.m_page + 1).ToString() + "/" + MAX_PAGE.ToString();
        SelectStage.m_Instance.ChangePage();
        SoundEngine.playBubbleEffect(SoundEngine.instance.m_click);
    }
    public void ButtonRight()
    {
        if (m_isItween)
            return;
        //if (TransitEffect.m_Instance.m_isEffecting)
         //   return;
        SelectStage.m_page += 1;
        if (SelectStage.m_page >= MAX_PAGE)
            SelectStage.m_page = 0;
       // SelectStage.m_Instance.m_Index = SelectStage.m_Instance.m_Index - 12;
        SelectStage.m_Instance.m_TextPage.text = (SelectStage.m_page + 1).ToString() + "/" + MAX_PAGE.ToString();
        SelectStage.m_Instance.ChangePage();
        SoundEngine.playBubbleEffect(SoundEngine.instance.m_click);
    }
    public void BackButtonPress()
    {
        if (m_isItween)
            return;
        m_isItween = true;
        SoundEngine.playBubbleEffect(SoundEngine.instance.m_click);
        ChangeToBlack_MaiMENU();
       // Application.LoadLevel("MainMenu");
    }
    public void ChangeToBlack_GAMEPLAY()
    {
        m_isItween = true;
        iTween.ValueTo(this.gameObject, iTween.Hash("from", 0, "to", 1, "time", 0.5, "onupdate", "OnColorUpdated", "oncomplete", "onCompletedGAMEPLAY"));

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
    public void onCompletedGAMEPLAY()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void onCompletedMainMenu()
    {
        Application.LoadLevel("MainMenu");
    }
}
