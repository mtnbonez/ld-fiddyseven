using UnityEngine;

[ExecuteInEditMode]
public class ButtonTest : MonoBehaviour
{

    public bool buttonDisplayName; //"run" or "generate" for example
    public bool buttonDisplayName2; //supports multiple buttons

    void Update()
    {
        if (buttonDisplayName)
            ButtonFunction1();
        else if (buttonDisplayName2)
            ButtonFunction2();
        buttonDisplayName = false;
        buttonDisplayName2 = false;
    }

    void ButtonFunction1()
    {
        Debug.Log("Button1 Pressed");
    }
    void ButtonFunction2()
    {
        Debug.Log("Button2 Pressed");
    }
}
