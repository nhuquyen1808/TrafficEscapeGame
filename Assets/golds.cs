using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class golds : MonoBehaviour
{

    private void OnEnable()
    {
        Invoke("CointFlyToDestination", 0.5f);
    }

    void CointFlyToDestination()
    {
        transform.DOMove(UiManager.ins.desCoin, 1)
            .OnComplete(() =>
            {
                Destroy(this.gameObject);
            });
    }
}
