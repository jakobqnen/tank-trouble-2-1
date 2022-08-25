using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Linq;

[CreateAssetMenu]
public class ControlSet : ScriptableObject
{
    public Color color;
    [SerializeField]
    private Image[] keyImages;
    [SerializeField]
    private InputActionMap actionMap;

    public void SetColorActionMap(Color _color, InputActionMap _actionMap)
    {
        color = _color;
        actionMap = _actionMap;
    }


}
