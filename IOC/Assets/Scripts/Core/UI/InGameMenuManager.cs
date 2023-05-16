using System;
using System.Collections;
using System.Collections.Generic;
using Events;
using TMPro;
using UnityEngine;

public class InGameMenuManager : MonoBehaviour
{
    private int currentTreeRessource = 0;
    private int currentHubRessource = 0;
    private int currentAgentCount = 0;
    private void Awake()
    {
       EventManagerSingleton.Get(SetEventManager);
    }

    private void SetEventManager(EventManagerSingleton eventManagerSingleton)
    {
        _eventManagerSingleton = eventManagerSingleton;
        _eventManagerSingleton.AddListener<OnRessourceCountUpdatedEvent>(UpdateRessourceAvailableText);
        _eventManagerSingleton.AddListener<OnRessourceCountUpdatedEvent>(UpdateHubRessourceText);
        eventManagerSingleton.AddListener<OnAgentCreatedEvent>(UpdateAgentCountText);
       
    }

    private void UpdateRessourceAvailableText(OnRessourceCountUpdatedEvent onRessourceCountUpdatedEvent)
    {
        switch (onRessourceCountUpdatedEvent.Owner)
        {
            case RessourceOwnerEnum.Tree:
            {
                currentTreeRessource += onRessourceCountUpdatedEvent.ValueUpdated;
                _treeRessourceAvailableText.text = currentTreeRessource.ToString();
                break;
            }
        }
    }
    private void UpdateHubRessourceText(OnRessourceCountUpdatedEvent onRessourceCountUpdatedEvent)
    {
        switch (onRessourceCountUpdatedEvent.Owner)
        {
            case RessourceOwnerEnum.Hub:
            {
                 currentHubRessource += onRessourceCountUpdatedEvent.ValueUpdated;
                _ressourceHubText.text =   currentHubRessource.ToString();
                break;
            }
        }
    }

    private void UpdateAgentCountText(OnAgentCreatedEvent onAgentCreatedEvent)
    {
        currentAgentCount++;
        _agentCountText.text = currentAgentCount.ToString();
        Debug.Log("updated");
    }
 
    private EventManagerSingleton _eventManagerSingleton;
    [SerializeField] private TextMeshProUGUI _treeRessourceAvailableText;
    [SerializeField] private TextMeshProUGUI _ressourceHubText;
    [SerializeField] private TextMeshProUGUI _agentCountText;
}
