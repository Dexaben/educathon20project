using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Gorev
{
    public string gorev;
    public string gun, ay, yil;
    public int puan;
    public bool durum;
}
public class GorevPanel : MonoBehaviour
{
    [SerializeField] private Text gorevText, gorevTarihText,gorevPuanText;
    private int gorevpuan;
    [SerializeField] private GameObject tamamlanmaPanel;
    public Todo todo;
    public Gorev gorev;
    public void GorevSync( string gorevText, string gorevTarihText,int gorevPuan,bool durum)
    {
        gorevpuan = gorevPuan;
        gorevPuanText.text = gorevpuan + " Puan";
        this.gorevText.text = gorevText.ToString();
        this.gorevTarihText.text = gorevTarihText.ToString();
        if (!durum)
        {
            tamamlanmaPanel.SetActive(true);
        }
        else tamamlanmaPanel.SetActive(false);
     
    }

    public void GorevTamamla()
    {
        MainController.instance.PuanAl(gorevpuan);
        tamamlanmaPanel.SetActive(false);
        gorev.durum = true;
        todo.TabloSync();
    }

}
