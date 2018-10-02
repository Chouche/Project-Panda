using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeLessonsPage : MonoBehaviour
{


    public GameObject[] lessonButtons;
    private int page;
    public Button m_btnLeft, m_btnRight;

    // Use this for initialization
    void Start()
    {
        var arr = this.transform.childCount;
        Debug.Log("number of child in Lessons : " + arr);
        lessonButtons = new GameObject[arr];

        for (int i = 0; i < this.transform.childCount; i++)
        {
            lessonButtons[i] = this.gameObject.transform.GetChild(i).gameObject;
            page = 1;
        }

        Button btnDown = m_btnLeft;
        Button btnUp = m_btnRight;

        btnDown.onClick.AddListener(ChangePageDown);
        btnUp.onClick.AddListener(ChangePageUp);
    }


    void ChangePageUp()
    {
        Debug.Log("taille du tableau " + this.transform.childCount);
        if(page < this.transform.childCount)
        {
            page += 1;
        }
        else
        {
            page = 1;
        }
        
        CheckPage();
    }

    void ChangePageDown()
    {
        if(page > 1)
        {
           page -= 1; 
        }
        else
        {
           page = lessonButtons.Length;
        }
        
        CheckPage();
    }

    public void CheckPage()
    {
        Debug.Log("checkPage et page egal " + page);
        for (int y = 1; y < lessonButtons.Length + 1; y++)
        {
            if (page == y)
            {
                lessonButtons[y - 1].SetActive(true);
            }
            else
            {
                lessonButtons[y - 1].SetActive(false);
            }
        }
    }

}
