using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearts : MonoBehaviour
{
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;
    public static int RemainingHearts = 3;

    private void Start() {
        RemainingHearts = 3;
        Heart1.SetActive(true);
        Heart2.SetActive(true);
        Heart3.SetActive(true);
    }

    void Update()
    {
        switch(RemainingHearts) {
            case 2:
                Heart1.SetActive(false);
                break;
            case 1:
                Heart2.SetActive(false);
                break;
            case 0:
                Heart3.SetActive(false);
                Heart2.SetActive(false);
                Heart1.SetActive(false);
                break;
        }
    }
}
