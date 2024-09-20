using System.Collections;
using System.Collections.Generic;
using UHFPS.Runtime;
using UnityEngine;

public class Win : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    bool isWon = false;
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }
    // Update is called once per frame
    void Update()
    {
        if (isWon)
        {
            _canvasGroup.alpha = Mathf.MoveTowards(_canvasGroup.alpha, 1, 0.1f);

            if(_canvasGroup.alpha == .9)
            {
                gameManager.PlayerPresence.FreezePlayer(true, true);
                gameManager.PlayerPresence.PlayerManager.PlayerItems.DeactivateCurrentItem();
            }
        }
    }

    public void Won()
    {
        isWon = true;
    }
}
