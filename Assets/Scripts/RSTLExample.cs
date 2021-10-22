
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Battlehub.RTCommon;
using Battlehub.RTSL.Interface;


public class RSTLExample : MonoBehaviour
{
    IProject m_project;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        m_project = IOC.Resolve<IProject>();

        yield return m_project.OpenProject("My Project");
        yield return m_project.CreateFolder("Scene/Demo");
    }

    IEnumerator SaveScene()
    {
        ProjectAsyncOperation ao = m_project.Save("Scene/Demo/Scene",SceneManager.GetActiveScene());
        yield return ao;
        if (ao.Error.HasError)
        {
            Debug.LogError(ao.Error.ToString());
        }
    }

    IEnumerator LoadScene()
    {
        ProjectAsyncOperation ao = m_project.Load<Scene>("Scene/Demo/Scene");
        yield return ao;
        if (ao.Error.HasError)
        {
            Debug.LogError(ao.Error.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            StartCoroutine(SaveScene());
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (m_project.Exist<Scene>("Scene/Demo/Scene"))
            {
                StartCoroutine(LoadScene());
            }
        }
    }
}
