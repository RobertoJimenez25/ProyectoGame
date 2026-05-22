using UnityEngine;
using System.Collections;

public class PantallaMuerte : MonoBehaviour
{
    public GameObject panelMuerte;

    public void MostrarMuerte()
    {
        StartCoroutine(
        SecuenciaMuerte());
    }

    IEnumerator SecuenciaMuerte()
    {
        panelMuerte.SetActive(
        true);

        yield return
        new WaitForSeconds(2);

        panelMuerte.SetActive(
        false);
    }
}