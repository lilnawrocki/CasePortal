using UnityEngine;
using System;
using System.Collections.Generic;
using TMPro;
using System.Linq;

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
    public GameObject ClosedCasesListContent;
    [Header("Case Details")]
    public TMP_InputField DCaseFirstNameTMP;
    public TMP_InputField DCaseLastNameTMP;
    public TMP_InputField DCaseEmailTMP;
    public TMP_InputField DCaseTitleTMP;
    public TMP_InputField DCaseDescriptionTMP;
    public TMP_Dropdown DCasePriorityDropdown;
    public int previewedCaseId = -1;
    public int siblingIndex = -1;

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
        //CM = GetComponent<CaseManager>();
        CM = this;
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
        resolvedSupportCase.SetResolved(true);
        ResolvedCasesList.Add(resolvedSupportCase);
        //OpenCasesList.RemoveAt(previewedCaseId); This is causing issues

    }
    public void RemoveCaseFromViewportContent()
    {
        if (previewedCaseId < 0) return;
        Transform viewPortContentTransform = OpenCasesListContent?.transform;
        if (viewPortContentTransform?.childCount > 0)
        {
            Destroy(viewPortContentTransform.GetChild(siblingIndex).gameObject);
        }
    }
    public void AddCaseToViewportContent(Transform contentTransform)
    {
        GameObject caseDetailsPanel = CreateCaseDetailsPanel(CaseDetailsPanelPrefab, contentTransform);
        if (caseDetailsPanel)
        {
            CaseDetails caseDetails = caseDetailsPanel.GetComponent<CaseDetails>();
            Case supportCase = OpenCasesList.ElementAt(OpenCasesList.Count - 1);
            SetCaseDetails(caseDetails, supportCase);
        }
    }
    public void SetCaseDetails(CaseDetails caseDetails, Case supportCase)
    {
        caseDetails.SetTitleTMP(supportCase.GetTitle());
        caseDetails.SetIdTMP(supportCase.GetCaseId().ToString("#0000"));
        caseDetails.SetPriorityTMP(supportCase.GetCasePriority());
        caseDetails.SetCaseId(supportCase.GetCaseId());
        caseDetails.SetResolved(supportCase.GetResolved());

    }
    public GameObject CreateCaseDetailsPanel(GameObject prefab, Transform contentTransform)
    {
        GameObject detailsPanel = null;
        if (prefab && contentTransform)
            detailsPanel = Instantiate(prefab, contentTransform);
        return detailsPanel;
    }
    public void FillCaseDetails(int caseId, List<Case> casesList)
    {
        Case supportCase = casesList.ElementAt(caseId);
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
    public void Autofill()
    {
        string[] caseTitle = {
            "SwaggerHub on-premise 2.10 installation issue",
            "Questions about SwaggerHub on-premise",
            "Is it possible to enable HA mode on embedded cluster?",
            "Please schedule a live support session during our upgrade process"
        };
        string[] caseDescription = {
            "We are facing na issue with the installation",
            "1. What are available installation types?\n2. Will license from 1.x work on 2.x?\n3. How to collect a support bundle when Admin Console is down?",
            "We have an embedded cluster and would like to have multiple replicas running on different nodes. How to achieve this?",
            "We will be performing upgrade from version 2.7.1 to 2.11 and need live support during this process. Please schedule a call where we can document any issues that arise during the installation and possibly, resolve them."
        };
        string firstName = "Marcin";
        string lastName = "Nawrocki";
        string email = "marcin.nawrocki@smartbear.com";

        int randomIndex = UnityEngine.Random.Range(0, 4);
        int randomPriority = UnityEngine.Random.Range(0, 3);

        if (CaseFirstNameTMP) CaseFirstNameTMP.text = firstName;
        if (CaseLastNameTMP) CaseLastNameTMP.text = lastName;
        if (CaseEmailTMP) CaseEmailTMP.text = email;
        if (CaseTitleTMP) CaseTitleTMP.text = caseTitle[randomIndex];
        if (CaseDescriptionTMP) CaseDescriptionTMP.text = caseDescription[randomIndex];
        if (CasePriorityDropdown) CasePriorityDropdown.value = randomPriority;

    }
}
