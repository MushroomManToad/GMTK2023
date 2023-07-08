using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransObj : MonoBehaviour
{
    [SerializeField]
    private string targetScene;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerMovementController pmc = collider.gameObject.GetComponent<PlayerMovementController>();
        if(pmc != null )
        {
            SceneTransferManager.Instance.loadScene(targetScene);
        }
    }
}
