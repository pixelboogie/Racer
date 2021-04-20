using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
              if (OVRInput.GetUp(OVRInput.RawButton.X)){
                       SceneManager.LoadScene("Scene-01");
              }
    }
}
