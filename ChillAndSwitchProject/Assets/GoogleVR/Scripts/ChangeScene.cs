using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 0.45f;
    //public GameObject webcam;
    public void changeScene(string name)
    {
        StartCoroutine(LoadLevel(name));
    }

    IEnumerator LoadLevel(string name)
    {
        transition.SetTrigger("StartScene");

        //webcam.SetActive(false);
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(name);
    }
}
 
