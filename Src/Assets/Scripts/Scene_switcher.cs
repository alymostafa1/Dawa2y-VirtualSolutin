using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_switcher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Load_Scanner() {

        SceneManager.LoadScene(1);

    }
    public void Load_Welcome() {

        SceneManager.LoadScene(0);

    }
    public void Load_About() {

        SceneManager.LoadScene(2);

    }
}
