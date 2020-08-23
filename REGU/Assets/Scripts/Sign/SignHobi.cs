using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignHobi: MonoBehaviour
{
    public Hobiler hobiIsmi;
    public bool alinmismi;
    public GameObject closedPanel;
    public SignHobiler signHobiler;
    void Start()
    {
        HobiEdin();
    }
    public void HobiEdin()
    {
        if (!alinmismi)
        {
            alinmismi = true;
            closedPanel.SetActive(false);
            Debug.Log("girdi");
        }

        else
        {
            alinmismi = false;
            closedPanel.SetActive(true);
        
        }
        signHobiler.SelectHobby(hobiIsmi,alinmismi);

    }
}
