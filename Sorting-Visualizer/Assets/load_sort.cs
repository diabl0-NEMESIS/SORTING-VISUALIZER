
using UnityEngine;
using UnityEngine.SceneManagement;
public class load_sort : MonoBehaviour
{
    public void loadselectionsort()
    {
        SceneManager.LoadScene(sceneName: "SELECTION-SORT");

    }

    public void loadmergesort()
    {

        SceneManager.LoadScene(sceneName: "MERGE-SORT");
    }

    public void loadquicksort()
    {

        SceneManager.LoadScene(sceneName: "QUICK-SORT");
    }

    public void loadheapsort()
    {
        SceneManager.LoadScene(sceneName: "HEAP-SORT");

    }

    public void loadbubblesort()
    {
        SceneManager.LoadScene(sceneName: "BUBBLE-SORT");

    }
    public void loadinsertionsort()
    {
        SceneManager.LoadScene(sceneName: "INSERTION-SORT");
    }

    public void loadinfo()
    {
        SceneManager.LoadScene(sceneName: "information");

    }
}
