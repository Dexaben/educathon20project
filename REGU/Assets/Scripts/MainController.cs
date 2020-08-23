using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EducationDegree
{
    ilkokul,
    ortaokul,
    lise,
    universite
}


public class MainController : MonoBehaviour
{
    public static MainController instance;
    
    public Student student = new Student();
    void Awake()
     {
         if (instance != null)
         {
             Destroy(gameObject);
             return;
         }
         instance = this;
         DontDestroyOnLoad(gameObject);
     }
    [Serializable]
    public class Student
    {
        [SerializeField]
        public string userID;
        public string name;
        public string surname;
        public EducationDegree educationDegree;
        public int birthdayDay;
        public int birthdayMouth;
        public int birthdayYear;
        public int classNumber;
        public int puan;
        public string city;
        public List<Hobiler> hobbies;
        public List<HaftalikDersler> dersler;
        public List<Gorev> gorevler = new List<Gorev>();
    }
    public void PuanAl(int puan)
    {
        student.puan += puan;
    }
}
