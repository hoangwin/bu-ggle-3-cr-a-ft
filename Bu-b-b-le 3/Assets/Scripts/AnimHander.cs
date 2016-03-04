using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AnimHander : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void onCompletedMainMenu()
    {
        
        Application.LoadLevel("SelectLevel");
    }
    public void onCompletedMainMenuSHowAds()
    {
        AdsManager.ShowADS_FULL();

    }
  
    
    
    
    
     
}
