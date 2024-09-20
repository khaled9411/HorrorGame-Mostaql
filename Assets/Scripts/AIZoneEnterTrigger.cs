using System.Collections;
using System.Collections.Generic;
using UHFPS.Runtime;
using UnityEngine;

public class AIZoneEnterTrigger : MonoBehaviour
{
    public GameObject monster1;
    public GameObject path1;

    public GameObject monster2;
    public GameObject path2;

    public GameObject monster3;
    public GameObject path3;

    public string triggerZone;

    private void Awake()
    {
        StartCoroutine(AwakeTheAI());
    }

    private IEnumerator AwakeTheAI()
    {
        path2.SetActive(true);
        monster2.SetActive(true);
        yield return null;
        path2.SetActive(false);
        monster2.SetActive(false);
        yield return null;
        path3.SetActive(true);
        monster3.SetActive(true);
        yield return null;
        path3.SetActive(false);
        monster3.SetActive(false);
        yield return null;
        path1.SetActive(true);
        monster1.SetActive(true);
        yield return null;
        path1.SetActive(false);
        monster1.SetActive(false);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (triggerZone)
            {
                case "Place1":
                    if (monster1.GetComponent<NPCStateMachine>().IsCurrent("Patrol"))
                    {
                        monster2.SetActive(false);
                        path2.SetActive(false);
                        monster3.SetActive(false);
                        path3.SetActive(false);
                        path1.SetActive(true);
                        monster1.SetActive(true);
                    }
                    break;

                case "Place2":
                    if (monster2.GetComponent<NPCStateMachine>().IsCurrent("Patrol"))
                    {
                        monster1.SetActive(false);
                        path1.SetActive(false);
                        monster3.SetActive(false);
                        path3.SetActive(false);
                        path2.SetActive(true);
                        monster2.SetActive(true);
                    }
                    break;

                case "Place3":
                    if (monster3.GetComponent<NPCStateMachine>().IsCurrent("Patrol"))
                    {
                        monster1.SetActive(false);
                        path1.SetActive(false);
                        monster2.SetActive(false);
                        path2.SetActive(false);
                        path3.SetActive(true);
                        monster3.SetActive(true);
                    }
                    break;
            }
        }
    }
}
