using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ClickToNextScene : MonoBehaviour, IPointerClickHandler
{
    public GameObject DialoguePanelObject;
    public GameObject FadeToSceneObject;

    private bool isAllDialogueFinished = false;

	// Use this for initialization
	void Start ()
    {
        DialoguePanelObject.GetComponent<DialoguePanel>().AllDialogueFinished += ClickToNextScene_AllDialogueFinished;
    }

    private void ClickToNextScene_AllDialogueFinished(object sender, System.EventArgs e)
    {
        isAllDialogueFinished = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isAllDialogueFinished)
        {
            FadeToSceneObject.SetActive(true);
        }
    }
}
