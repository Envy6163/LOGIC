using UnityEngine;
using UnityEngine.UI;

public class QualitySettingsController : MonoBehaviour
{
    // Dropdown or buttons to select quality levels
    public Dropdown qualityDropdown; // Optional: Attach a UI Dropdown in the Inspector

    void Start()
    {
        // Load the saved quality level or default to the current level
        int savedQualityLevel = PlayerPrefs.GetInt("QualityLevel", QualitySettings.GetQualityLevel());
        SetQualityLevel(savedQualityLevel);

        // Initialize dropdown if attached
        if (qualityDropdown != null)
        {
            qualityDropdown.ClearOptions();
            qualityDropdown.AddOptions(new System.Collections.Generic.List<string>(QualitySettings.names));
            qualityDropdown.value = savedQualityLevel;
            qualityDropdown.onValueChanged.AddListener(delegate { OnQualityDropdownChanged(); });
        }
    }

    // Function to set quality level
    public void SetQualityLevel(int level)
    {
        QualitySettings.SetQualityLevel(level);
        PlayerPrefs.SetInt("QualityLevel", level); // Save the quality setting
        PlayerPrefs.Save();
        Debug.Log("Quality Level set to: " + QualitySettings.names[level]);
    }

    // Called when dropdown value changes
    private void OnQualityDropdownChanged()
    {
        if (qualityDropdown != null)
        {
            SetQualityLevel(qualityDropdown.value);
        }
    }

    // Optional: Functions to bind to buttons for specific quality levels
    public void SetLowQuality()
    {
        SetQualityLevel(0); // Typically, the first index is "Low"
    }

    public void SetMediumQuality()
    {
        SetQualityLevel(1); // Typically, the second index is "Medium"
    }

    public void SetHighQuality()
    {
        SetQualityLevel(2); // Typically, the third index is "High"
    }

    public void SetUltraQuality()
    {
        SetQualityLevel(QualitySettings.names.Length - 1); // Last index for "Ultra" or highest quality
    }
}
