using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Personagens : Interacting
{

    //public int personagem;

    public GameObject bar;

    string[] dialogosSeparados;

    LeitorDeTxt leitorDeTxt;

    // Start is called before the first frame update
    void Start()
    {
        leitorDeTxt = Camera.main.GetComponent<LeitorDeTxt>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DefineDialogo(int personagem)
    {
        string dialogoPersonagem;

        dialogoPersonagem = leitorDeTxt.RetornaDialogo(0);

        dialogosSeparados = dialogoPersonagem.Split('\n');

        Debug.Log("clicou" + personagem);

        bar.SetActive(false);

        

    }

    public void DateDialogos()
    {

    }
}
