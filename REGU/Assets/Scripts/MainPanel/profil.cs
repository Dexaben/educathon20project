using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class profil : MonoBehaviour
{
    [SerializeField] private Transform tamamlanmisGorevlerContent,hobilerContent;    
    [SerializeField] private GameObject gorevPrefab,hobiPrefab;

    [Serializable]
    public class hobiclass
    {
        public Hobiler hobi;
        public Sprite hobiResim;
    }

    public List<hobiclass> hobiler;
    [SerializeField]
    private Text IsimText, sinifText, puanText;

    [SerializeField] private Slider puanSlider;
    void Awake()
    {
       Guncelle();
    }

    public void Guncelle()
    {
        TamamlanmisGorevleriListele();
        BilgileriGuncelle();
        HobilerListele();
    }
    void HobilerListele()
    {
        foreach (Transform VARIABLE in hobilerContent)
        {
            Destroy(VARIABLE.gameObject);
        }
        foreach (var VARIABLE in MainController.instance.student.hobbies)
        {
            GameObject hobi = Instantiate(hobiPrefab, hobilerContent);
            hobi.GetComponent<Image>().sprite = hobiler.Find(x => x.hobi == VARIABLE).hobiResim;
        }
       
    }
    void BilgileriGuncelle()
    {
        IsimText.text = MainController.instance.student.name;
        sinifText.text = MainController.instance.student.educationDegree.ToString().ToUpper()+"\n"+MainController.instance.student.classNumber+".Sınıf";
        puanText.text = MainController.instance.student.puan + " Puan";
    }
    void TamamlanmisGorevleriListele()
    {    
        foreach (Transform VARIABLE in tamamlanmisGorevlerContent)
        {
            Destroy(VARIABLE.gameObject);
        }
        for (int i = 0; i < MainController.instance.student.gorevler.Count; i++)
        {
            if (MainController.instance.student.gorevler[i].durum == true)
            {
                GorevPanel ders = Instantiate(gorevPrefab, tamamlanmisGorevlerContent).GetComponent<GorevPanel>();
                ders.GorevSync(MainController.instance.student.gorevler[i].gorev,MainController.instance.student.gorevler[i].gun+"."+MainController.instance.student.gorevler[i].ay+"."+MainController.instance.student.gorevler[i].yil,MainController.instance.student.gorevler[i].puan,true);
            }
        }
    }
}
