using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Menu_Manager : MonoBehaviour
{
    public GameObject GamePlay_Panel;
    public GameObject Very_Soon_Panel;
    public AudioClip Click;
    public AudioSource MainAudio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        if(ShareValues.Next_Btn == 1)
        {
            Easy_Mode();
        }
    }
    public void Easy_Mode()
    {
        this.gameObject.SetActive(false);
        GamePlay_Panel.SetActive(true);
        MainAudio.PlayOneShot(Click);
    }
    public void Medium_Mode()
    {
        Very_Soon_Panel.SetActive(true);
        MainAudio.PlayOneShot(Click);
    }
    public void Hard_Mode()
    {
        Very_Soon_Panel.SetActive(true);
        MainAudio.PlayOneShot(Click);
    }
}
