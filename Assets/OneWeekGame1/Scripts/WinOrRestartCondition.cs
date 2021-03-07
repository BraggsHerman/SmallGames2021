using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinOrRestartCondition : MonoBehaviour
{
    //if character falls, or if they get to the end of the level, reset the level
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PController>())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
