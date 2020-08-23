using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Hobiler
{
    Kitap,
    Bilim,
    Tasarım,
    Tarih,
    Sinema,
    Yazılım,
    Tiyatro,
    Resim,
    Oyun,
    Müzik,
    Spor,
    Robotik
}
public class SignHobiler : MonoBehaviour
{
    Dictionary<Hobiler, bool> hobilerDictionary = new Dictionary<Hobiler, bool>();
    
    void Awake()
    {
        hobilerDictionary.Clear();
        hobilerDictionary.Add(Hobiler.Bilim,false);
        hobilerDictionary.Add(Hobiler.Oyun,false);
        hobilerDictionary.Add(Hobiler.Resim,false);
        hobilerDictionary.Add(Hobiler.Robotik,false);
        hobilerDictionary.Add(Hobiler.Sinema,false);
        hobilerDictionary.Add(Hobiler.Tarih,false);
        hobilerDictionary.Add(Hobiler.Spor,false);
        hobilerDictionary.Add(Hobiler.Tasarım,false);
        hobilerDictionary.Add(Hobiler.Tiyatro,false);
        hobilerDictionary.Add(Hobiler.Yazılım,false);
        hobilerDictionary.Add(Hobiler.Kitap,false);
        hobilerDictionary.Add(Hobiler.Müzik,false);
    }
    public void SelectHobby(Hobiler hobiIsmi,bool alinmismi)
    {
        hobilerDictionary[hobiIsmi] = alinmismi;
    }

    public void HobilerKayit()
    {
        MainController.instance.student.hobbies.Clear();
        List<Hobiler> temp = new List<Hobiler>();
        foreach (var VARIABLE in hobilerDictionary)
        {
            if (VARIABLE.Value == true)
            {
                temp.Add(VARIABLE.Key);
            }
        }
        MainController.instance.student.hobbies.AddRange(temp);
    }
}
