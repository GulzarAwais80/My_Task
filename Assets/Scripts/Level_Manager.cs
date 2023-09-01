using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Level_Manager : MonoBehaviour
{
    public AudioClip Click, Flip, Matching, MisMatch;
    public AudioSource MainAudio;
    string SaveId;
    string SaveId_2;

    public Text Match_no_text;
    public Text Turns_no_text;
    public static Level_Manager Instance;

    [HideInInspector]
    public GameObject Selected_btn1;

    [HideInInspector]
    public GameObject Selected_btn2;

    public int Targeted_Match_Count;
    public GameObject[] Cover_Images;
    public GameObject GameManager;

    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.activeInHierarchy)
        {
            Instance = this;
        }
        else
        {
            Instance = this;
        }
    }
    private void OnEnable()
    {
        ShareValues.match_No = 0;
        ShareValues.State = 0;
        StartCoroutine(Cover_Images_On());
    }
    // Update is called once per frame
    void Update()
    {
        if (ShareValues.match_No >= Targeted_Match_Count)
        {
            Targeted_Match_Count = 0;
            GameManager.GetComponent<GameManager>().Level_Complete();
        }
    }
    IEnumerator Cover_Images_On()
    {
        if (ShareValues.Next_Btn == 1)
        {
            yield return new WaitForSeconds(3.1f);
            ShareValues.Next_Btn = 0;
        }
        else
        {
            yield return new WaitForSeconds(1.2f);
        }
        for (int i = 0; i < Cover_Images.Length; i++)
        {
            Cover_Images[i].SetActive(true);
        }
    }
    public void Button_Clicked(string Id)
    {
        if (ShareValues.Next_Turn == true)
        {
            MainAudio.PlayOneShot(Flip);
            if (ShareValues.State == 0)
            {
                SaveId = Id;
                Selected_btn1.gameObject.GetComponent<Animator>().enabled = true;
                Selected_btn1.gameObject.GetComponent<Button>().interactable = false;

                ShareValues.State = 1;
                StartCoroutine(Off_First_Game_Object());
            }
            else if (ShareValues.State == 1)
            {
                ShareValues.State = 2;
                ShareValues.Next_Turn = false;
                SaveId_2 = Id;
                Selected_btn2.gameObject.GetComponent<Animator>().enabled = true;
                Selected_btn2.gameObject.GetComponent<Button>().interactable = false;

                StartCoroutine(Off_Second_Game_Object());
            }
        }
        else
        {
            Debug.Log("Dont Do Please");
        }

    }
    IEnumerator Off_First_Game_Object()
    {
        yield return new WaitForSeconds(0.92f);
        Selected_btn1.gameObject.GetComponent<Animator>().enabled = false;
        Selected_btn1.gameObject.GetComponent<Image>().enabled = false;
    }
    IEnumerator Off_Second_Game_Object()
    {
        yield return new WaitForSeconds(0.92f);
        Selected_btn2.gameObject.GetComponent<Animator>().enabled = false;
        Selected_btn2.gameObject.GetComponent<Image>().enabled = false;

        if (SaveId_2 == SaveId)
        {
            Debug.Log("Con");
            StartCoroutine(For_Off_Completed_Objects());
        }
        else
        {
            ShareValues.Turn_No++;
            Turns_no_text.text = "Turns: " + ShareValues.Turn_No.ToString();
            Debug.Log("no Con");
            StartCoroutine(For_States());
        }
    }
    IEnumerator For_States()
    {
        yield return new WaitForSeconds(0.1f);
        MainAudio.PlayOneShot(MisMatch);
        Selected_btn1.gameObject.GetComponent<Image>().enabled = true;
        Selected_btn2.gameObject.GetComponent<Image>().enabled = true;
        Selected_btn1.gameObject.GetComponent<Button>().interactable = true;
        Selected_btn2.gameObject.GetComponent<Button>().interactable = true;

        ShareValues.State = 0;
        ShareValues.Next_Turn = true;
    }
    IEnumerator For_Off_Completed_Objects()
    {
        yield return new WaitForSeconds(0.4f);
        MainAudio.PlayOneShot(Matching);
        ShareValues.Turn_No++;
        Turns_no_text.text = "Turns: " + ShareValues.Turn_No.ToString();
        ShareValues.match_No++;
        Match_no_text.text = "Match: " + ShareValues.match_No.ToString();
        Selected_btn1.gameObject.transform.parent.gameObject.SetActive(false);
        Selected_btn2.gameObject.transform.parent.gameObject.SetActive(false);
        ShareValues.State = 0;
        //  yield return new WaitForSeconds(0.1f);
        ShareValues.Next_Turn = true;
    }
    private void OnDisable()
    {
        Instance = null;
    }
}  