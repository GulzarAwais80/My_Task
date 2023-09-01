using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soon_Panel : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(Off_The_Soon_Panel());
    }
    IEnumerator Off_The_Soon_Panel()
    {
        yield return new WaitForSeconds(1.5f);
        this.gameObject.SetActive(false);

    }
}
