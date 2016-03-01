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
    public static int MAX_PAGE = 4;
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
        SelectStage.m_Instance.m_TextPage.text = (SelectStage.m_page + 1).ToString() + "/" + MAX_PAGE.ToString();
        ChangePage();
    }
    
    // Update is called once per frame
    void Update() {
      
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
                m_Index = ScoreManager.m_LevelUNblock.NUM-1- m_page * 20;
        
         
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
       // if (TransitEffect.m_Instance.m_isEffecting)
       //     return;
        SelectStage.m_page--;
        if (SelectStage.m_page < 0)
            SelectStage.m_page = 3;
        //SelectStage.m_Instance.m_Index = 12 + SelectStage.m_Instance.m_Index;
        SelectStage.m_Instance.m_TextPage.text = (SelectStage.m_page + 1).ToString() + "/" + MAX_PAGE.ToString();
        SelectStage.m_Instance.ChangePage();

    }
    public void ButtonRight()
    {
        //if (TransitEffect.m_Instance.m_isEffecting)
         //   return;
        SelectStage.m_page += 1;
        if (SelectStage.m_page >= 4)
            SelectStage.m_page = 0;
       // SelectStage.m_Instance.m_Index = SelectStage.m_Instance.m_Index - 12;
        SelectStage.m_Instance.m_TextPage.text = (SelectStage.m_page + 1).ToString() + "/" + MAX_PAGE.ToString();
        SelectStage.m_Instance.ChangePage();

    }
    public void BackButtonPress()
    {

        SoundEngine.playSound("SoundClick");
        Application.LoadLevel("MainMenu");
    }
}
