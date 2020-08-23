using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine.UI;

public enum HaftaninGunleri
{
    Pazartesi,
    Salı,
    Çarşamba,
    Perşembe,
    Cuma,
    Cumartesi,
    Pazar,
}
[Serializable]
public class HaftalikDersler
{
    public List<SignEklenecekDersO> dersler;
    public HaftaninGunleri gun;

}
public class SignHaftalikDersProgrami : MonoBehaviour
{
    [SerializeField] private GameObject dersPrefab;
    [SerializeField] private Transform derslerContent,dersEkleO;
    [SerializeField] private Dropdown dersEkleDersIsim;
    [SerializeField] private Text dersEkleDakika,dersEkleSaat,gunText;
    public List<HaftalikDersler> dersler = new List<HaftalikDersler>();
    private HaftaninGunleri suankiGun = HaftaninGunleri.Pazartesi;
   
    void Start()
    {
        dersler.Add(new HaftalikDersler(){dersler = new List<SignEklenecekDersO>(),gun = HaftaninGunleri.Pazartesi});
        dersler.Add(new HaftalikDersler(){dersler = new List<SignEklenecekDersO>(),gun = HaftaninGunleri.Salı});
        dersler.Add(new HaftalikDersler(){dersler = new List<SignEklenecekDersO>(),gun = HaftaninGunleri.Çarşamba});
        dersler.Add(new HaftalikDersler(){dersler = new List<SignEklenecekDersO>(),gun = HaftaninGunleri.Perşembe});
        dersler.Add(new HaftalikDersler(){dersler = new List<SignEklenecekDersO>(),gun = HaftaninGunleri.Cuma});
    }
    public void DersEkle()
    {
        dersEkleO.gameObject.SetActive(true);
        dersEkleDersIsim.options.Clear();
        dersEkleDersIsim.AddOptions(Enum.GetNames(typeof(Dersler)).ToList());
        dersEkleDakika.text = DateTime.Now.Minute.ToString();
        dersEkleSaat.text = DateTime.Now.Hour.ToString();
    }

    public void DersEkleListe()
    {
        HaftalikDersler ders =  dersler.Find(x => x.gun == suankiGun);
        SignEklenecekDersO dersEkle = new SignEklenecekDersO()
        {
            dersAdi = (Dersler) System.Enum.Parse(typeof(Dersler), dersEkleDersIsim.value.ToString()),
            dersDakika = dersEkleDakika.text,
            dersSaat = dersEkleSaat.text
        };
        ders.dersler.Add(dersEkle);
        TabloSync();
    }
    public void DersSilListe()
    {
        TabloSync();
    }
    public void GunIleri()
    {
        if (suankiGun != HaftaninGunleri.Cuma)
        {
      
            suankiGun++;
            gunText.text = suankiGun.ToString();
            TabloSync();
        }
    }
    public void GunGeri()
    {
        if (suankiGun != HaftaninGunleri.Pazartesi)
        {
            suankiGun--;
            gunText.text = suankiGun.ToString();
            TabloSync();
        }
    }
    Color RandomPastelColor()
    {
        Color color_ = new Color(
            (float)UnityEngine.Random.Range(0, 255), 
            (float)UnityEngine.Random.Range(0, 255), 
            (float)UnityEngine.Random.Range(0, 255)
        );
        int red = UnityEngine.Random.Range(0, 256);
        int green = UnityEngine.Random.Range(0, 256);
        int blue = UnityEngine.Random.Range(0, 256);
        if (color_ != null) {
            red = (int)((red + (int)color_.r) / 1.6f);
            green = (int)((green + (int)color_.g) / 1.6f);
            blue = (int)((blue + (int)color_.b) / 1.6f);
        }

        Color color = new Color(red/255f, green/255f, blue/255f); 
        return color;
    }
    public void TabloSync()
    {
        //suankiGun ile dersler listeden çekilip siralanacak.
        for (int i = 1; i < derslerContent.childCount; i++)
        {
            Destroy(derslerContent.transform.GetChild(i).gameObject);
        }
        HaftalikDersler dersler_ =  dersler.Find(x => x.gun == suankiGun);
        for (int i = 0;i<dersler_.dersler.Count;i++)
        {
            SignEklenecekDers ders = Instantiate(dersPrefab, derslerContent).GetComponent<SignEklenecekDers>();
            ders.DersSync(dersler_.dersler[i].dersAdi,dersler_.dersler[i].dersSaat,dersler_.dersler[i].dersDakika);
        }
    }
}
