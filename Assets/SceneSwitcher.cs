using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{
    public void SwitchScene()
    {


        int nextLevel = (Application.loadedLevel + 1) % Application.levelCount;
        Application.LoadLevel(nextLevel);
        Debug.Log("test button");
    }

    public void AnotherFunc()
    {
        //int nextLevel = (Application.loadedLevel + 1) % Application.levelCount;
        //Application.LoadLevel(nextLevel);
        Debug.Log("test button");
    }

}
