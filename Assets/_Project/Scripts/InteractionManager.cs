using System;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractionManager : MonoBehaviour
{

    void Update()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        if (results.Count == 0) return;

        Interactive interactive = FilterFirstInteractive(results);

        if (!interactive) return;

        Debug.Log($"{interactive.gameObject.name} is interactive");
    }

    private Interactive GetInteractive(GameObject hitObject)
    {
        Interactive interactive = hitObject.GetComponent<Interactive>();

        if (!interactive) interactive = GetInteractiveFromParent(hitObject);
        if (!interactive) interactive = GetInteractiveFromChild(hitObject);

        if (!interactive)
            throw new ArgumentException($"{hitObject.name} has no Interactive class related to it");

        return interactive;
    }

    private Interactive GetInteractiveFromParent(GameObject hitObject)
    {
        if (!hitObject.transform.parent) return null;

        GameObject parentGameObject = hitObject.transform.parent.gameObject;
        Interactive interactive = parentGameObject.GetComponent<Interactive>();

        if (!interactive) interactive = GetInteractiveFromParent(parentGameObject);

        return interactive;
    }

    private Interactive GetInteractiveFromChild(GameObject hitObject)
    {
        if (hitObject.transform.childCount <= 0) return null;

        Interactive interactive = null;
        for (int i = 0; i < hitObject.transform.childCount; i++)
        {
            GameObject childGameObject = hitObject.transform.GetChild(i).gameObject;
            Interactive childInteractive = childGameObject.GetComponent<Interactive>();

            if (!childInteractive) interactive = GetInteractiveFromChild(childGameObject);

            if (interactive && childInteractive)
                throw new ArgumentException($"{hitObject.name} has multiple Interactive children");

            interactive = childInteractive;
        }

        return interactive;
    }

    private Interactive FilterFirstInteractive(List<RaycastResult> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Interactive interactive = GetInteractive(list[0].gameObject);
            if (!interactive) continue;
            if (interactive.canInteract) return interactive;
        }

        return null;
    }
}
