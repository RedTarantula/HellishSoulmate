using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TestInput();
    }

    void TestInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
         
            if (touch.phase == TouchPhase.Began)
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);

                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

                if (hit)
                {
                    if (hit.collider.tag == "Interacting")
                    {
                        hit.collider.gameObject.GetComponent<Interacting>().OnEvent.Invoke();
                    }

                }

            }

        }
        else if(Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

            if (hit)
            {
                if (hit.collider.tag == "Interacting")
                {
                    hit.collider.gameObject.GetComponent<Interacting>().OnEvent.Invoke();
                }

            }
        }
    }
}
