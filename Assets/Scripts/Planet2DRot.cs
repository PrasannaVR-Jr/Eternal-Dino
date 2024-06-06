using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet2DRot : MonoBehaviour
{
    public float angSpeed=50;
    public DinoController dinoController;
    
    void Update()
    {
        if(GameManager.Instance.GameStarted)
            transform.Rotate(0, 0, angSpeed * 180 * Time.deltaTime);
    }
}
