using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public FixedJoystick moveJoystick;
    public float movSpeed;

    void Update()
    {
        float hoz = moveJoystick.Horizontal;
        float ver = moveJoystick.Vertical;
        Vector3 dir = new Vector3(hoz,0,ver).normalized;
        transform.Translate(dir*movSpeed, Space.World);
    }

    public void kill()
    {
        SceneManager.LoadScene("MainScene");
    }

}
