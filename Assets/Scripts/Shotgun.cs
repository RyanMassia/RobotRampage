using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{
    override protected void Update()
    {
        base.Update();  // Shotgun & Pistol have semi-auto fire rate  
        if (Input.GetMouseButtonDown(0) && (Time.time - lastFireTime)> fireRate) // cheaks enough time has passeed between shot s to allow next  
        {
            lastFireTime = Time.time; 
            Fire();
        }
    }
}
 
