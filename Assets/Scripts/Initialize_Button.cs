using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialize_Button : MonoBehaviour
{
    public void Init_Button()
    {
        if(ShareValues.State == 0)
        {
            Level_Manager.Instance.Selected_btn1 = this.gameObject;
        }
        else
        {
            Level_Manager.Instance.Selected_btn2 = this.gameObject;
        }
    }
}
