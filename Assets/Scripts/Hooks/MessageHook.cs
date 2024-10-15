using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageHook : MonoBehaviour
{
    public GameObject _winMessage;


    public void ActivateMessage() {
        _winMessage.SetActive(true);
        _winMessage.GetComponent<SizeAnimation>().TriggerSizeAnimation();
    }
}
