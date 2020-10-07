using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GiftShop : MonoBehaviour
{

    public GameObject abreLoja;
    public GameObject tiraUI;

    public GameObject boyzins;
    // Start is called before the first frame update
    public void AbreLoja(){
        boyzins.SetActive(false);
        abreLoja.SetActive(true);
        tiraUI.SetActive(false);
    }
    public void Volta()
    {
        SceneManager.LoadScene("Hell");
    }
    
}
