using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject buildingIcon = null;
    [SerializeField] private GameObject storeIcon = null;
    private bool isTheMenuOpen = false;

    /// <summary>
    /// Public method that checks if the menu is already
    /// open, and creates a "dropdown"-type menu.
    /// </summary>
    public void Controller()
    {
        if (isTheMenuOpen)
        {
            isTheMenuOpen = false;
            CloseMenu();
        }
        else
        {
            isTheMenuOpen = true;
            OpenMenu();
        }
    }

    private void OpenMenu()
    {
        buildingIcon.SetActive(true);
        storeIcon.SetActive(true);
    }

    private void CloseMenu()
    {
        buildingIcon.SetActive(false);
        storeIcon.SetActive(false);
    }
}