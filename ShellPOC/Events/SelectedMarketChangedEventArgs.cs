using System;

namespace ShellPOC.Events;

public class SelectedMarketChangedEventArgs : EventArgs
{
	public int? MarketId { get; private set; }

	public SelectedMarketChangedEventArgs(int? marketId)
	{
		MarketId = marketId;
	}
}

public delegate void SelectedMarketChangedEvent(SelectedMarketChangedEventArgs args);
