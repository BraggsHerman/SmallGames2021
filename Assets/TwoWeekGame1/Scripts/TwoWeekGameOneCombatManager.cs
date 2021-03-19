using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoWeekGameOneCombatManager : MonoBehaviour
{
    public static TwoWeekGameOneCombatManager instance;

    public bool canReceviveInput;
    public bool inputReceived;

    public void Awake()
    {
        instance = this;
    }

   public void Attack()
   {
        if (Input.GetKey(KeyCode.J))
        {
            if (canReceviveInput)
            {
                inputReceived = true;
                canReceviveInput = false;

            }
            else
            {
                return;
            }
        }
   }

    public void InputManager()
    {
        if (!canReceviveInput)
        {
            canReceviveInput = false;
        }
        else
        {
            canReceviveInput = true;
        }
    }
}
