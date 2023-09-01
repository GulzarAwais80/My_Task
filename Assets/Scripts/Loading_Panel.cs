using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Loading_Panel : MonoBehaviour
{
    public Slider Loading_Slider;
    public float Slider_Value;
    private void OnEnable()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
      if(Loading_Slider.value >= 1)
        {
            this.gameObject.SetActive(false);
        }
      else
        {
            Slider_Value += Time.deltaTime * 0.5f;
            Loading_Slider.value = Slider_Value;
        }
    }
    private void OnDisable()
    {
        Loading_Slider.value = 0f;
        Slider_Value = 0f;
    }
}
