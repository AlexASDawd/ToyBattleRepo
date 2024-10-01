using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyBattleSign : MonoBehaviour
{
    [SerializeField] private GameObject[] _toyBattleSighn;
    
    [ContextMenu("StartAnimation")]
    private void StartAnimation() {
        _toyBattleSighn[0].GetComponent<Animator>().SetTrigger("StartAnimation");
    }

    

}
