using System.Collections;
using TMPro;
using UnityEngine;

public class TransitionPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI loadingText;

    private Coroutine transitionCoroutine;

    public void ShowPanel()
    {
        gameObject.SetActive(true);

        if (transitionCoroutine == null)
        {
            transitionCoroutine = StartCoroutine(LoadingRoutine());
        }
    }
    public void HidePanel()
    {
        gameObject.SetActive(false);

        if (transitionCoroutine != null)
        {
            StopCoroutine(transitionCoroutine);
            transitionCoroutine = null;
        }
    }

    private IEnumerator LoadingRoutine()
    {
        while (true)
        {
            loadingText.text = "Loading...";
            yield return new WaitForSeconds(1f);
            loadingText.text = "Loading.";
            yield return new WaitForSeconds(1f);
            loadingText.text = "Loading..";
            yield return new WaitForSeconds(1f);
        }
    }
}
