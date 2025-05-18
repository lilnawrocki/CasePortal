using UnityEngine;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CaseDetails : MonoBehaviour
{
    [SerializeField]
    TMP_Text PriorityTMP, IdTMP, TitleTMP, DateTMP;
    int caseId;
    bool resolved = false;
    void Awake()
    {
        GetComponent<Button>()?.onClick.AddListener(delegate
        {
            EnableDetailsPanel();
            FillDetailsPanel();
            if (CaseManager.CM) CaseManager.CM.previewedCaseId = caseId;
            if (CaseManager.CM) CaseManager.CM.siblingIndex = transform.GetSiblingIndex();
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

    public void SetDateTMP(string text)
    {
        if (DateTMP) DateTMP.text = text;
    }

    public void EnableDetailsPanel()
    {
        CaseManager.CM?.CaseDetailsPanel?.SetActive(true);
    }

    public void FillDetailsPanel()
    {
        if (resolved)
            CaseManager.CM?.FillCaseDetails(caseId, CaseManager.CM.ResolvedCasesList);
        else
            CaseManager.CM?.FillCaseDetails(caseId, CaseManager.CM.OpenCasesList);
    }
    public void SetCaseId(int caseId)
    {
        this.caseId = caseId;
    }
    public int GetCaseId()
    {
        return caseId;
    }
    public void SetResolved(bool resolved)
    {
        this.resolved = resolved;
    }
}


