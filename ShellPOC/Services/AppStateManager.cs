using System;
using ShellPOC.Events;

namespace ShellPOC.Services;

public class AppStateManager : IAppStateManager
{
    private int? selectedMarketId;
    public int? SelectedMarketId
    {
        get
        {
            return selectedMarketId;
        }
        set
        {
            if(value != selectedMarketId)
            {
                selectedMarketId = value;
                SelectedMarketChanged?.Invoke(new SelectedMarketChangedEventArgs(selectedMarketId));
            }
        }
    }

    public event SelectedMarketChangedEvent? SelectedMarketChanged;
}
