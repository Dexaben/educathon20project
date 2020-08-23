using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPanelController : MonoBehaviour
{
    [SerializeField] private GameObject profil, yanPencere, gorevler, Rozetlerim;
    public profil Profil;
    public Todo todo;
    public void PanelAc(GameObject acilacak)
    {
      
        profil.SetActive(false);
        yanPencere.SetActive(false);
        gorevler.SetActive(false);
        Rozetlerim.SetActive(false);
        Profil.Guncelle();
        todo.TabloSync();
        acilacak.SetActive(true);
    }
}
