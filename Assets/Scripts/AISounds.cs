using System.Collections;
using System.Collections.Generic;
using UHFPS.Runtime;
using UHFPS.Scriptable;
using UHFPS.Tools;
using UnityEngine;
using static UHFPS.Scriptable.SurfaceDefinitionSet;
[RequireComponent(typeof(AudioSource))]
public class AISounds : MonoBehaviour
{
    [SerializeField] private AudioClip[] foodStepsSounds;
    [SerializeField] private AudioClip screamOfAgerSound;
    [SerializeField] private AudioSource screamOfAgerAudioSource;
    [SerializeField] private AudioSource ChaseAudioSource;
    [SerializeField] private AudioSource afterRunAudioSource;

    private NPCStateMachine npcStateMachine;
    private AudioSource foodStepsAudioSource;
    private void Awake()
    {
        foodStepsAudioSource = GetComponent<AudioSource>();
        npcStateMachine = GetComponent<NPCStateMachine>();
    }

    private void Update()
    {
        if(!npcStateMachine.IsPlayerDead)
            ScreamOfAngerSound();
    }

    public void FoodStepsSound()
    {
        foodStepsAudioSource.clip = foodStepsSounds[Random.Range(0, foodStepsSounds.Length)];
        foodStepsAudioSource.Play();
    }

    private bool once = true;
    public void ScreamOfAngerSound()
    {
        if (once && npcStateMachine.IsCurrent("Chase"))
        {
            screamOfAgerAudioSource.clip = screamOfAgerSound;
            screamOfAgerAudioSource.Play();
            ChaseAudioSource.Play();
            once = false;
            StartCoroutine(ResetOnceBoolen());
            return;
        }

        //if(!once && npcStateMachine.PreviousState == npcStateMachine.StatesAsset.AIStates[])
        if (npcStateMachine.PreviousState.HasValue)
        {
            string previousStateKey = npcStateMachine.PreviousState.Value.StateData.StateAsset.GetStateKey();
            if (!once && (previousStateKey == "Chase" || previousStateKey == "Player Hide"))
            {
                StartCoroutine(PlayafterRunAudioSource());
                once = true;
                Debug.Log("Previous state is " + previousStateKey);
            }
            else if(previousStateKey == "Patrol")
            {
                afterRunAudioSource.Stop();
                //Debug.Log("Previous state is not Chase. It is: " + previousStateKey);
            }
        }
        else
        {
            //Debug.Log("Previous state is null.");
        }
    }

    private IEnumerator ResetOnceBoolen()
    {
        yield return new WaitForSeconds(20);
        once = true;
    }

    private IEnumerator PlayafterRunAudioSource()
    {
        yield return new WaitForSeconds(10);
        afterRunAudioSource.Play();
    }
}
