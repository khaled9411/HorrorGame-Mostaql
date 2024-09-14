using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UHFPS;
using UHFPS.Runtime;

public class AIAfterCrouch : MonoBehaviour
{
    PlayerStateMachine playerStateMachine;
    NPCStateMachine npcStateMachine;

    private float defulteSightsFOV;
    private float defulteSightsDistance;
    [SerializeField] private float FOVDecreasValue;
    [SerializeField] private float SightsDistanceDecreasValue;

    private void Start()
    {
        playerStateMachine = FindAnyObjectByType<PlayerStateMachine>();
        npcStateMachine = GetComponent<NPCStateMachine>();

        defulteSightsFOV = npcStateMachine.SightsFOV;
        defulteSightsDistance = npcStateMachine.SightsDistance;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStateMachine.IsCurrent(PlayerStateMachine.CROUCH_STATE))
        {
            npcStateMachine.SightsFOV = defulteSightsFOV / FOVDecreasValue;
            npcStateMachine.SightsDistance = defulteSightsDistance / SightsDistanceDecreasValue;
        }
        else
        {
            npcStateMachine.SightsFOV = defulteSightsFOV;
            npcStateMachine.SightsDistance = defulteSightsDistance;
        }
    }
}
