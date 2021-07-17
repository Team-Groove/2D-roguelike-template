using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField] private GameObject elf = null;
    [SerializeField] private GameObject orc = null;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (elf.activeSelf == true)
            {
                elf.SetActive(false);
                orc.SetActive(true);
            }
            else if (orc.activeSelf == true)
            {
                elf.SetActive(true);
                orc.SetActive(false);
            }
        }
    }
}
