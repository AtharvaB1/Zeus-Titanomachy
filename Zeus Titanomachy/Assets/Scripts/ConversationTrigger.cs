using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationTrigger : MonoBehaviour
{
    public NPCConversation myConversation;
    [SerializeField] private GameObject textToDelete;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                ConversationManager.Instance.StartConversation(myConversation);
                textToDelete.SetActive(false);
            }
        }
    }
}
