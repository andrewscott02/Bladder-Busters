using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsUI : MonoBehaviour
{
    public Text[] text;

    public void ConfigureControls(Dictionary<KeyCode, int> controlDirections)
    {
        text[controlDirections[KeyCode.W]].text = "W";
        text[controlDirections[KeyCode.A]].text = "A";
        text[controlDirections[KeyCode.S]].text = "S";
        text[controlDirections[KeyCode.D]].text = "D";
    }
}
