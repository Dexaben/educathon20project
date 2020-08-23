using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using  UnityEngine.UI;
public class SignController : MonoBehaviour
{
    [SerializeField] private InputField isim, soyisim,sehir,reguKodu;
    [SerializeField] private Dropdown gun, ay, yil,sinifDropdown;
    public SignHaftalikDersProgrami signHaftalikDersProgrami;
    void Start()
    {
        //gun ay yil inputları.
        List<string>temp = new List<string>();
        for (int i = 1; i <= 31; i++)
        {
           temp.Add(i.ToString());
        }
        gun.options.Clear();
        gun.AddOptions(temp);
        temp.Clear();
        for (int i = 1; i <= 12; i++)
        {
            temp.Add(i.ToString());
        }
        ay.options.Clear();
        ay.AddOptions(temp);
        temp.Clear();
        for (int i = 2000; i <= System.DateTime.Now.Year; i++)
        {
            temp.Add(i.ToString());
        }
        yil.options.Clear();
        yil.AddOptions(temp);
        temp.Clear();
    }
    public void IsimSoyisimInput()
    {
       MainController.instance.student.name = isim.text;
       MainController.instance.student.surname = soyisim.text;
    }
    public void ogrenimDuzeyi(int duzey)
    {
        MainController.instance.student.educationDegree = (EducationDegree)duzey;
    }

    public void bilgilerGiris()
    {
        MainController.instance.student.birthdayDay =  (Convert.ToInt32(gun.options[gun.value].text));
       MainController.instance.student.birthdayMouth =   (Convert.ToInt32(ay.options[ay.value].text));
       MainController.instance.student.birthdayYear =  (Convert.ToInt32(yil.options[yil.value].text));
       MainController.instance.student.city = sehir.text;
       MainController.instance.student.classNumber = (Convert.ToInt32(sinifDropdown.options[sinifDropdown.value].text));
    }
    public void SceneChange(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void HaftalikDersProgrami()
    {
        MainController.instance.student.dersler = new List<HaftalikDersler>(signHaftalikDersProgrami.dersler);
    }
    
}
