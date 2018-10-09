using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    public Text questionText;
    public SimpleObjectPool answerButtonObjectPool;
    public Transform answerButtonParent;

    private DataController dataController;
    private LessonData currentLessonData;
    private LevelData currentLevelData;
    private QuestionData[] questionPool;

    private bool isLevelActive;
    private float timeRemaining;
    private int questionIndex;
    private int idCurrentLesson;
    private int playerScore;

    public GameObject questionDisplay;
    public GameObject levelEndDisplay;
    public Text starGetDisplay;

    private List<GameObject> answerButtonGameObjects = new List<GameObject>();


	// Use this for initialization
	void Start () {
        dataController = FindObjectOfType<DataController>();
        currentLessonData = dataController.GetCurrentLessonData();
        idCurrentLesson = dataController.currentlevel; 
        questionPool = currentLessonData.levels[idCurrentLesson].questions;

        playerScore = 3;
        questionIndex = 0;
        


        ShowQuestion();
        isLevelActive = true;
	}
	
    private void ShowQuestion()
    {
        RemoveAnswerButtons();
        QuestionData questionData = questionPool[questionIndex];
        questionText.text = questionData.questionText;

        for (int i = 0; i < questionData.answers.Length; i++)
        {
            GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();
            answerButtonGameObjects.Add(answerButtonGameObject);
            answerButtonGameObject.transform.SetParent(answerButtonParent);

            AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
            answerButton.Setup(questionData.answers[i]);
        }
    }

    private void RemoveAnswerButtons()
    {
        while (answerButtonGameObjects.Count > 0)
        {
            answerButtonObjectPool.ReturnObject(answerButtonGameObjects[0]);
            answerButtonGameObjects.RemoveAt(0);
        }
    }

    public void AnswerButtonClicked(bool isCorrect)
    {
        if (!isCorrect)
        {
            playerScore -= 1;
        }

        if(questionPool.Length > questionIndex + 1)
        {
            questionIndex++;
            ShowQuestion();

        }
        else
        {
            EndRound();
        }
    }

    public void EndRound()
    {
        isLevelActive = false;
        questionDisplay.SetActive(false);
        levelEndDisplay.SetActive(true);
    }

	// Update is called once per frame
	void Update () {
        starGetDisplay.text = "Nb Stars " + playerScore.ToString();
    }
}
