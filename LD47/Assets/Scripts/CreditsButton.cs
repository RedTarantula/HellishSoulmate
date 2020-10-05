using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsButton : MonoBehaviour
{
    
    public void GoToCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    
    public void GoBack()
    {
        SceneManager.LoadScene("HIque");
    }

}
