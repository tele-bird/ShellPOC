using System;
using ShellPOC.Events;

namespace ShellPOC.Services;

public interface IAppStateManager
{
    int? SelectedMarketId { get; set; }
    event SelectedMarketChangedEvent? SelectedMarketChanged;
}
