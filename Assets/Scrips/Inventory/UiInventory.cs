using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class UiInventory : MonoBehaviour
{
    public readonly string[] SortingOptionName =
    {
        "SORT_DATE_ASC",
        "SORT_DATE_DESC",
        "SORT_NAME_ASC",
        "SORT_NAME_DESC",
    };

    public readonly string[] FilteringOptionName =
    {
        "FILTER_ALL",
        "FILTER_WEAPON",
        "FILTER_EQUIP",
        "FILTER_CONSUMABLE",
    };

    public TMP_Dropdown sorting;
    public TMP_Dropdown filtering;
    public UiItemSlotList uiItemSlotList;

    private void OnEnable()
    {
        UpdateDropDownOptions();
        
        OnLoad();
        OnChangeSorting(sorting.value);
        OnChangefiltering(filtering.value);

        Variables.OnLanguageChanged += UpdateDropDownOptions;
    }

    public void UpdateDropDownOptions()
    {
        var stringTable = DataTableManager.StringTable;
        sorting.ClearOptions();
        var options = new List<string>();
        
        foreach (var id in SortingOptionName)
        {
            options.Add(stringTable.Get(id));
        }
        sorting.AddOptions(options);

        filtering.ClearOptions();
        options.Clear();

        foreach (var id in FilteringOptionName)
        {
            options.Add(stringTable.Get(id));
        }
        filtering.AddOptions(options);
    }

    private void OnDisable()
    {
        Variables.OnLanguageChanged -= UpdateDropDownOptions;
        OnSave();
    }

    public void OnChangeSorting(int index)
    {
        uiItemSlotList.Sorting = (UiItemSlotList.SortingOptions)index;
    }

    public void OnChangefiltering(int index)
    {
        uiItemSlotList.Filtering = (UiItemSlotList.FilteringOptions)index;

    }

    public void OnSave()
    {
        SaveLoadManager.Data.ItemList = uiItemSlotList.GetSaveItemDataList();
        SaveLoadManager.Save();
    }

    public void OnLoad()
    {
        SaveLoadManager.Load();
        uiItemSlotList.SetSaveItemDataList(SaveLoadManager.Data.ItemList);
    }

    public void OnCreateItem()
    {
        uiItemSlotList.AddRandomItem();
    }

    public void OnRemoveItem()
    {
        uiItemSlotList.RemoveItem();
    }

}
