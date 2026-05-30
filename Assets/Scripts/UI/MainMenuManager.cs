using System.Collections;
using FMODUnity;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Animator transition;
    [SerializeField] private EventReference buttonSfx;

    public void LoadScene()
    {
        AudioManager.Instance.PlaySFX(buttonSfx);
        StartCoroutine(LoadSceneRoutine("SampleScene"));
    }

    public void ExitGame()
    {
        AudioManager.Instance.PlaySFX(buttonSfx);
        StartCoroutine(QuitGameRoutine());
    }

    private IEnumerator LoadSceneRoutine(string scenename)
    {
        transition.SetTrigger("TransitionIn"); 
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scenename);
    }

    private IEnumerator QuitGameRoutine()
    {
        transition.SetTrigger("TransitionIn"); 
        yield return new WaitForSeconds(1);
        Application.Quit();
    }
}
