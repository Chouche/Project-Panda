using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour {


    public Text levelText;

    private LevelData levelData;
    private LevelMenuController levelMenuController;

	// Use this for initialization
	void Start () {
        levelMenuController = FindObjectOfType<LevelMenuController>();
	}
	
    public void Setup(LevelData data)
    {
        levelData = data;
        levelText.text = "Level: " + levelData.idLevel;
    }

	public void HandleClick()
    {
        LevelMenuController.AnswerButtonClicked(answerData.isCorrect);
    }

    
}
