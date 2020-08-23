using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hosgeldiniz : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(basla());
    }

    IEnumerator basla()
    {
        yield return  new  WaitForSeconds(1f);
        SceneManager.LoadScene("Sign");
    }
}
