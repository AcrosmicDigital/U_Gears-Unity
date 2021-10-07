using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ActionOnClickButton : MonoBehaviour
{
    public string scriptName = "";
    public bool enable = true;
    public Button button;
    public UnityEvent<GameObject> onClick;

    // Start is called before the first frame update
    void Start()
    {
        if (button == null)
            button = GetComponent<Button>();

        if (button == null)
            return;

        button.onClick.AddListener( () => onClick?.Invoke(gameObject));
    }

}
