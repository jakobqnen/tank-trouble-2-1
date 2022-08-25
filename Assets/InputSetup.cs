using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InputSetup : MonoBehaviour
{
    public InputControls inputControls;
    public ControlSet controlSet;
    // Start is called before the first frame update
    void Start()
    {
        inputControls = new InputControls();
        controlSet.SetColorActionMap(Color.blue, inputControls.Where(x => x.actionMap.name == "Controls0").ToList()[0].actionMap);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
