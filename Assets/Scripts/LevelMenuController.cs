using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LevelMenuController : MonoBehaviour {

    
    public SimpleObjectPool levelButtonObjectPool;
    public Transform answerButtonParent;

    private DataController dataController;
    private LessonData currentLessonData;
    private LevelData currentLevelData;
    private LevelData[] levelPool;

    private bool isLevelActive;
    private float timeRemaining;
    private int questionIndex;
    private int idCurrentLesson;
    private int playerScore;

  

    private List<GameObject> answerButtonGameObjects = new List<GameObject>();


	// Use this for initialization
	void Start () {
        dataController = FindObjectOfType<DataController>();
        currentLessonData = dataController.GetCurrentLessonData();
        idCurrentLesson = dataController.currentlevel; 
        levelPool = currentLessonData.levels[idCurrentLesson].questions;

        ShowQuestion();
	}
	
    private void ShowQuestion()
    {
        LevelData levelData = levelPool[questionIndex];

        for (int i = 0; i < levelData.; i++)
        {
            GameObject answerButtonGameObject = levelButtonObjectPool.GetObject();
            answerButtonGameObjects.Add(answerButtonGameObject);
            answerButtonGameObject.transform.SetParent(answerButtonParent);

            AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
            answerButton.Setup(levelData.answers[i]);
        }
    }




	// Update is called once per frame
	void Update () {
        
    }
}
