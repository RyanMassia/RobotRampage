using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : Gun
{
    override protected void Update()
    {
        base.Update();
        // Automatic Fire     
        if (Input.GetMouseButton(0) && Time.time - lastFireTime > fireRate)// like other code but uses get mouse button so when held will keep firing
        {
            lastFireTime = Time.time;
            Fire();
        }
    }
}



