using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroiComponent : MonoBehaviour
{
    // Start is called before the first frame update
   public void DestroiBall(GameObject obj)
    {
        obj.SetActive(false);
        if (obj.GetComponent<NormalBall>() != null)
        {
            ReloadLevelComponent.RL.DisableBall();
        }
        if (obj.GetComponent<MainBall>() != null)
        {
            obj.GetComponent<MainBall>().ResetBall();
        }
    }
}
