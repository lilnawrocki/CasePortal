using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CaseDetails : MonoBehaviour
{
    public static CaseDetails CD;

    [SerializeField]
    TMP_Text PriorityTMP, IdTMP, TitleTMP;
    int caseId;
    void Awake()
    {
        CD = GetComponent<CaseDetails>();
        GetComponent<Button>()?.onClick.AddListener(delegate
        {
            EnableDetailsPanel();
            FillDetailsPanel();
            if (CaseManager.CM) CaseManager.CM.previewedCaseId = caseId;
        });
        
    }
    public void SetPriorityTMP(string text)
    {
        if (PriorityTMP) PriorityTMP.text = text;
    }
    public void SetIdTMP(string text)
    {
        if (IdTMP) IdTMP.text = text;
    }

    public void SetTitleTMP(string text)
    {
        if (TitleTMP) TitleTMP.text = text;
    }

    public void EnableDetailsPanel()
    {
        CaseManager.CM?.CaseDetailsPanel?.SetActive(true);
    }

    public void FillDetailsPanel()
    {
        CaseManager.CM?.FillCaseDetails(caseId);
    }
    public void SetCaseId(int caseId)
    {
        this.caseId = caseId;
    }
    public int GetCaseId()
    {
        return caseId;
    }

}


