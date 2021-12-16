using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintMessage : MonoBehaviour
{

    public string message = "Hello there !!";

    public void Print(string Message) => Debug.Log(Message);

    public void Print() => Print(message);

}
