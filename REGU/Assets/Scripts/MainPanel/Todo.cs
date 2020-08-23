using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class Todo : MonoBehaviour
{
    
    [SerializeField] private GameObject gorevPrefab;
    [SerializeField] private Transform tamamlanmisGorevlerContent,tamamlanmamisGorevlerContent,gorevEkleO;
    [SerializeField] private Text gorevEkleIsim, gorevEkleGun, gorevEkleAy, gorevEkleYil;
    void Start()
    {
        //gorevler cekilecek.
       TabloSync();
       
    }
    public void GorevEkle()
    {
        gorevEkleO.gameObject.SetActive(true);
        gorevEkleIsim.text = "";
    }

    public void DersEkleListe()
    {
       
        Gorev gorev = new Gorev()
        {
            gorev = gorevEkleIsim.text,
            gun = gorevEkleGun.text,
            ay = gorevEkleAy.text,
            yil = gorevEkleYil.text,
            puan = UnityEngine.Random.Range(200,1500)
        };
        MainController.instance.student.gorevler.Add(gorev);
        TabloSync();
    }
   
    public void TabloSync()
    {
        for (int i = 1; i < tamamlanmamisGorevlerContent.childCount; i++)
        {
            Destroy(tamamlanmamisGorevlerContent.transform.GetChild(i).gameObject);
        }
        foreach (Transform VARIABLE in tamamlanmisGorevlerContent)
        {
            Destroy(VARIABLE.gameObject);
        }
       
        for (int i = 0; i < MainController.instance.student.gorevler.Count; i++)
        {
            if (MainController.instance.student.gorevler[i].durum == true)
            {
                GorevPanel ders = Instantiate(gorevPrefab, tamamlanmisGorevlerContent).GetComponent<GorevPanel>();
                ders.todo = this;
                ders.gorev = MainController.instance.student.gorevler[i];
                ders.GorevSync(MainController.instance.student.gorevler[i].gorev,MainController.instance.student.gorevler[i].gun+"."+MainController.instance.student.gorevler[i].ay+"."+MainController.instance.student.gorevler[i].yil,MainController.instance.student.gorevler[i].puan,true);
            }
            else
            {
                GorevPanel ders = Instantiate(gorevPrefab, tamamlanmamisGorevlerContent).GetComponent<GorevPanel>();
                ders.todo = this;
                ders.gorev = MainController.instance.student.gorevler[i];
                ders.GorevSync(MainController.instance.student.gorevler[i].gorev,MainController.instance.student.gorevler[i].gun+"."+MainController.instance.student.gorevler[i].ay+"."+MainController.instance.student.gorevler[i].yil,MainController.instance.student.gorevler[i].puan,false);
            }
        }
    }
}
