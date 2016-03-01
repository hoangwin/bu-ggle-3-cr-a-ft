using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	// Use this for initialization
    public static SuperInt m_HighScore;
    public static SuperInt m_LevelUNblock;    
    
    public static int Score;
    void Start () {

	}

    public static void Load()
    {
        m_LevelUNblock = new SuperInt(1, "UNLOCK_STAGE");        
        m_LevelUNblock.Load();
        //m_LevelUNblock.NUM = 30;
    }
    public static void Save()
    {        
        m_LevelUNblock.Save();
    }
    // Update is called once per frame
    void Update () {
	
	}
}
