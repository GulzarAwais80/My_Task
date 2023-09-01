using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance;
    public GameObject Level_Complete_Panel;
    public Text Level_no;
    public GameObject[] Levels;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        int level_For_Text = 0;
        level_For_Text++;
        Level_no.text = "Level_No: " + level_For_Text;
        Select_Level();
        Levels[PlayerPrefs.GetInt("Level_no", 0)].SetActive(true);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Select_Level()
    {
        for (int i = 0; i < Levels.Length; i++)
        {
            Levels[i].SetActive(false);
        }
    }
    public void Level_Complete()
    {
        Level_Complete_Panel.SetActive(true);
    }
    public void Next_Btn()
    {
        int Next_Value = PlayerPrefs.GetInt("Level_no");
        Next_Value++;
        if(Next_Value >= 4 )
        {
            Next_Value = 0;
        }
        PlayerPrefs.SetInt("Level_no", Next_Value);
        ShareValues.Next_Btn = 1;
        ShareValues.match_No = 0;
        ShareValues.Turn_No = 0;
        ShareValues.State = 0;
        SceneManager.LoadScene(0);
    }
}  