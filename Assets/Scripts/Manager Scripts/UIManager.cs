public class UIManager : Singleton<UIManager>
{
    private TransitionPanel _transitionPanel;

    public override void Awake()
    {
        base.Awake();

        _transitionPanel = GetComponentInChildren<TransitionPanel>(true);
    }

    public void ShowTransitionPanel()
    {
        if (_transitionPanel != null)
        {
            _transitionPanel.ShowPanel();
        }
    }
    public void HideTransitionPanel()
    {
        if (_transitionPanel != null)
        {
            _transitionPanel.HidePanel();
        }
    }
}
