using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Taker : MonoBehaviour
{
    public GameObject _Sender;

    void Start()
    {
        _Sender.SendMessage("Test", 5);
    }

    void Test(int number)
    {
        print(number);
    }
}
