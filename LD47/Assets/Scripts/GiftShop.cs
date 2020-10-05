using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GiftShop : MonoBehaviour
{

    public GameObject abreLoja;
    public GameObject tiraUI;
    // Start is called before the first frame update
    public void AbreLoja(){
        abreLoja.SetActive(true);
        tiraUI.SetActive(false);
    }
    public void Volta()
    {
        SceneManager.LoadScene("HIque");
    }
    
}
