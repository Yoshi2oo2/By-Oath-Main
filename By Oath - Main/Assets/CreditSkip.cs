using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditSkip : MonoBehaviour
{
    public void Skip()
    {
        SceneManager.LoadScene(0);
    }
}
