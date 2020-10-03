using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulArea : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Test_input();
    }


    public void Test()
    {
        Debug.Log("a");
    }

    void Test_input()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);

                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

                if(hit)
                {
                    if(hit.collider.tag == "Interacting")
                    {
                        hit.collider.gameObject.GetComponent<Interacting>().OnEvent.Invoke();
                    }
                  
                }

            }

        }
    }
}
