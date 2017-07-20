using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchSelector : MonoBehaviour
{
    private MainMenu refMM;
    private LeapButton[] arrayChild;

    private void Start()
    {
        refMM = FindObjectOfType<MainMenu>();
        // Assegno il metodo ChoosedTrack al delegato
        refMM.delChoosedTrack = ChoosedTrack;
        refMM.delChoosedPlayer = ChoosedPlayer;
        arrayChild = GetComponentsInChildren<LeapButton>();
    }

    // Si prende il nome del tracciato scelto in modo che al cambio scena si sappia giá
    // cosa far spawnare e disattiva invece tutti gli altri
    public void ChoosedTrack(string _name)
    {
        for (int i = 0; i < arrayChild.Length; i++)
        {
            if (_name == arrayChild[i].gameObject.name)
            {
                // Spengo l'animazione e spengo lo script LeapButton
                Debug.Log("Sono nel Circuit giusto poiché sono " + arrayChild[i].name);
                arrayChild[i].GetComponent<LeapButton>().anim.SetBool("On", false);
                arrayChild[i].GetComponent<LeapButton>().enabled = false;
                // Attivo il tracciato al suo interno su cui giocherá il Player nella PlayScene
                arrayChild[i].transform.GetChild(0).gameObject.SetActive(true);
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                //Destroy(arrayChild[i]);
                arrayChild[i].gameObject.SetActive(false);
            }
        }
    }

    public void ChoosedPlayer(string _name)
    {
        for (int i = 0; i < arrayChild.Length; i++)
        {
            if (_name == arrayChild[i].gameObject.name)
            {
                Debug.Log("Sono nel Circuit giusto poiché sono " + arrayChild[i].name);
                DontDestroyOnLoad(this.gameObject);
                arrayChild[i].gameObject.SetActive(true);
            }
            else
            {
                arrayChild[i].gameObject.SetActive(false);
            }
        }
    }
}
