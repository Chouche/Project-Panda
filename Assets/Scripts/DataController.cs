using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour {


    public LessonData[] allLessonData;

    // Use to choose the lesson 
    public int currentlevel = -1; 

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("MainMenu");

        //set id automatically for each lesson
        for(int i=0; i<allLessonData.Length; i++)
        {
            allLessonData[i].idLesson = i;
        }


	}
	
    public LessonData GetCurrentLessonData()
    {
        return allLessonData[0];
    }

	// Update is called once per frame
	void Update () {
		
	}
}
