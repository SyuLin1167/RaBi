using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    public void ButtonCleck()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
