using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class SelectLevelButton : MonoBehaviour
{

    // Use this for initialization
    public int m_Level;
    public Text m_Text;
    public GameObject m_ImagePass;
    public GameObject m_ImageNew;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UpdateText()
    {
        m_Text.text = (m_Level + 20 * SelectStage.m_page).ToString();
        if (SelectStage.m_page * 20 + m_Level <= ScoreManager.m_LevelUNblock.NUM)
        {
            if (SelectStage.m_page * 20 + m_Level == ScoreManager.m_LevelUNblock.NUM)
            {
                m_ImagePass.SetActive(true);
                m_ImageNew.SetActive(false);
            }
            else
            {
                m_ImagePass.SetActive(false);
                m_ImageNew.SetActive(true);
            }
            m_Text.color = Color.white;
        }
        else
        {
            m_ImagePass.SetActive(false);
            m_ImageNew.SetActive(false);
            m_Text.color = Color.grey;
        }


    }
    public void ButtonLevelPress()
    {
        if (SelectStage.m_Instance.m_isItween)
            return;
        //  SoundEngine.m_Instancce.PlaySoundCLick();
        SelectStage.m_Instance.m_Index = m_Level;
        int index = SelectStage.m_page * 20 + m_Level;
       // Debug.Log(ScoreManager.m_LevelUNblock.NUM);
        if (index <= ScoreManager.m_LevelUNblock.NUM)
        {
            //      Time.timeScale = 1;            
            LevelManager.currentLevel = index;
            //      GameManager.m_IsPlaying = true;
          //  Debug.Log(LevelManager.currentLevel);
            SoundEngine.playBubbleEffect(SoundEngine.instance.m_click);
            SelectStage.m_Instance.ChangeToBlack_GAMEPLAY();
          //  SceneManager.LoadScene("GamePlay");
            // SoundEngine.m_Instancce.PlaySoundCLick();
        }
    }

}
