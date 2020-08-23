
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum Dersler
{
    Matematik,
    Türkçe,
    FenBilimleri,
    Bilgisayar,
    BedenEğitimi,
    Resim,
    Müzik,
    Vatandaşlık
}
[Serializable]
public class SignEklenecekDersO
{
    public Dersler dersAdi;
    public string dersSaat;
    public string dersDakika;
}
public class SignEklenecekDers : MonoBehaviour
{
    [SerializeField] private Text dersSaatText, dersAdiText;
    public void DersSync(Dersler dersAdi, string dersSaat, string dersDakika)
    {
        dersAdiText.text = dersAdi.ToString();
        dersSaatText.text = dersSaat.ToString()+":"+dersDakika.ToString();
    }
}
