using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class SelectLevelButton : MonoBehaviour
{

    // Use this for initialization
    public int m_Level;
    public Text m_Text;
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

    }
    public void ButtonLevelPress()
    {

      //  SoundEngine.m_Instancce.PlaySoundCLick();
        SelectStage.m_Instance.m_Index = m_Level;
        int index = SelectStage.m_page * 20 + m_Level;
        Debug.Log(ScoreManager.m_LevelUNblock.NUM);
        if (index <= ScoreManager.m_LevelUNblock.NUM)
        {
      //      Time.timeScale = 1;
            
            LevelManager.currentLevel = index;
            //      GameManager.m_IsPlaying = true;
            Debug.Log(LevelManager.currentLevel);
            SceneManager.LoadScene("GamePlay");

      //      SoundEngine.m_Instancce.PlaySoundCLick();
        }
    }

}
