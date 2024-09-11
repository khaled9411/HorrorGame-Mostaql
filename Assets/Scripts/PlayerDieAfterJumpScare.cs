using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UHFPS;
using UHFPS.Runtime;

public class PlayerDieAfterJumpScare : MonoBehaviour
{
    PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent<PlayerHealth>(out playerHealth);
    }

    public void StartDie()
    {
        StartCoroutine(Die());
    }
    private IEnumerator Die()
    {
        yield return new WaitForSeconds(1);
        playerHealth.ApplyDamageMax();
    }
}
