using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void Level1_NextBtn()
    {
        SceneManager.LoadScene("Level2");
    }
}
