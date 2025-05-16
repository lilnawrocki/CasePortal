using UnityEngine;
using System;
using System.Collections.Generic;
using TMPro;
using System.Linq;
using System.Data.Common;
public class CaseManager : MonoBehaviour
{
    public static CaseManager CM;
    [Header("Create Case")]
    public TMP_InputField CaseFirstNameTMP;
    public TMP_InputField CaseLastNameTMP;
    public TMP_InputField CaseEmailTMP;
    public TMP_InputField CaseTitleTMP;
    public TMP_InputField CaseDescriptionTMP;
    public TMP_Dropdown CasePriorityDropdown;
    public GameObject CaseDetailsPanel;
    public GameObject CaseDetailsPanelPrefab;
    public GameObject OpenCasesListContent;
    [Header("Case Details")]
    public TMP_InputField DCaseFirstNameTMP;
    public TMP_InputField DCaseLastNameTMP;
    public TMP_InputField DCaseEmailTMP;
    public TMP_InputField DCaseTitleTMP;
    public TMP_InputField DCaseDescriptionTMP;
    public TMP_Dropdown DCasePriorityDropdown;
    public int previewedCaseId = -1;

    string caseFirstName = "";
    string caseLastName = "";
    string caseEmail = "";
    string caseTitle = "";
    string caseDescription = "";
    string createdTime = "";
    int caseId = 0;
    int casePriority = 0;

    public List<Case> OpenCasesList;
    public List<Case> ResolvedCasesList;

    void Awake()
    {
        OpenCasesList = new List<Case>();
        ResolvedCasesList = new List<Case>();
        CM = GetComponent<CaseManager>();
    }
    public void CreateCase()
    {
        createdTime = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
        if (CaseFirstNameTMP) caseFirstName = CaseFirstNameTMP.text;
        if (CaseLastNameTMP) caseLastName = CaseLastNameTMP.text;
        if (CaseEmailTMP) caseEmail = CaseEmailTMP.text;
        if (CaseTitleTMP) caseTitle = CaseTitleTMP.text;
        if (CaseDescriptionTMP) caseDescription = CaseDescriptionTMP.text;
        if (CasePriorityDropdown) casePriority = CasePriorityDropdown.value;

        Case supportCase = new Case(caseFirstName, caseLastName, caseEmail, caseTitle, caseDescription, createdTime, caseId, casePriority);
        OpenCasesList.Add(supportCase);
        caseId = OpenCasesList.Count;
    }

    public void ResolveCase()
    {
        if (previewedCaseId < 0) return;
        Case resolvedSupportCase = OpenCasesList.ElementAt(previewedCaseId);
        ResolvedCasesList.Add(resolvedSupportCase);
        OpenCasesList.RemoveAt(previewedCaseId);
    }
    public void RemoveCaseFromViewportContent()
    {
        if (previewedCaseId < 0) return;
        Transform viewPortContentTransform = OpenCasesListContent?.transform;
        if (viewPortContentTransform?.childCount > 0)
        {
            Destroy(viewPortContentTransform.GetChild(previewedCaseId).gameObject);
        }
    }
    public void AddCaseToViewportContent()
    {
        GameObject caseDetailsObject = null;
        if (CaseDetailsPanelPrefab && OpenCasesListContent) caseDetailsObject = Instantiate(CaseDetailsPanelPrefab, OpenCasesListContent.transform);
        if (caseDetailsObject)
        {
            CaseDetails caseDetails = caseDetailsObject.GetComponent<CaseDetails>();
            Case supportCase = OpenCasesList.ElementAt(OpenCasesList.Count - 1);
            caseDetails.SetTitleTMP(supportCase.GetTitle());
            caseDetails.SetIdTMP(supportCase.GetCaseId().ToString("#0000"));
            caseDetails.SetPriorityTMP(supportCase.GetCasePriority());
            caseDetails.SetCaseId(supportCase.GetCaseId());
        }
    }
    public void FillCaseDetails(int caseId)
    {
        Case supportCase = OpenCasesList.ElementAt(caseId);
        if (DCaseFirstNameTMP) DCaseFirstNameTMP.text = supportCase.GetFirstName();
        if (DCaseLastNameTMP) DCaseLastNameTMP.text = supportCase.GetLastName();
        if (DCaseEmailTMP) DCaseEmailTMP.text = supportCase.GetEmail();
        if (DCaseTitleTMP) DCaseTitleTMP.text = supportCase.GetTitle();
        if (DCaseDescriptionTMP) DCaseDescriptionTMP.text = supportCase.GetDescription();
        if (DCasePriorityDropdown) DCasePriorityDropdown.value = supportCase.GetCasePriorityInt();
    }
    public void ClearFields()
    {
        if (CaseFirstNameTMP) CaseFirstNameTMP.text = "";
        if (CaseLastNameTMP) CaseLastNameTMP.text = "";
        if (CaseEmailTMP) CaseEmailTMP.text = "";
        if (CaseTitleTMP) CaseTitleTMP.text = "";
        if (CaseDescriptionTMP) CaseDescriptionTMP.text = "";
        if (CasePriorityDropdown) CasePriorityDropdown.value = 0;
    }
}
