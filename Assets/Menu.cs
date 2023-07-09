using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject MenuC;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        MenuC.SetActive(true);
        GameManager.Instance.score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown && !Input.GetMouseButton(0) && !Input.GetMouseButton(1) && !Input.GetMouseButton(2))
        {
            Time.timeScale = 1f;
            MenuC.SetActive(false);
        }

    }
}
