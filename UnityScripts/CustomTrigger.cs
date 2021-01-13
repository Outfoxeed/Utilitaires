using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class CustomTrigger : MonoBehaviour
{
    public enum OnTriggerAction { destroy, disable, disable_trigger};
    public OnTriggerAction actionOnTrigger;
    public UnityEvent evnt;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            evnt?.Invoke();
            switch (actionOnTrigger)
            {
                case OnTriggerAction.destroy:
                    Destroy(gameObject);
                    break;
                case OnTriggerAction.disable:
                    gameObject.SetActive(false);
                    break;
                case OnTriggerAction.disable_trigger:
                    GetComponent<Collider2D>().enabled = false;
                    break;
            }
        }
    }
}
