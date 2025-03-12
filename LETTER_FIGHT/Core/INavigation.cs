namespace LETTER_FIGHT.Core
{
    /// <summary>
    /// Interface for the navigation service
    /// </summary>
    public interface INavigation
    {   
        void NavigateTo(string viewName);
        void GoBack();
    }
}
