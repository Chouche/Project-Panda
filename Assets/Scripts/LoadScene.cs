using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    private DataController dataController;

	public void LoadSceneByName(string sceneTitle)
    {
        SceneManager.LoadScene(sceneTitle);
    }

    public void LoasdGameSceneByLevelID(int levelID)
    {
        dataController = FindObjectOfType<DataController>();
        dataController.currentlevel = levelID - 1;
        SceneManager.LoadScene("Game");
        
    }
}
