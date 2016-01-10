using System.Collections.Generic;

public class MenuFlowStateChanges
{
	public static Dictionary<MenuFlowStateChangeDirection, List<MenuFlowStateChangeOption>> States =
		new Dictionary<MenuFlowStateChangeDirection, List<MenuFlowStateChangeOption>>(new MenuFlowStateChangeDirectionEqualityComparer())
		{
			// Start
			{
				MenuFlowStateChangeDirectionBuilder.From(MenuState.Start).Direction(MenuFlowStateChangeDirectionType.Forward),
				new List<MenuFlowStateChangeOption>()
				{
					MenuFlowStateChangeOptionBuilder.If(MenuFlowStateChangeOptionCondition.Always).To(MenuState.GameTypeSelection),
				}
			},

			// GameTypeSelection
			{
				MenuFlowStateChangeDirectionBuilder.From(MenuState.GameTypeSelection).Direction(MenuFlowStateChangeDirectionType.Backward),
				new List<MenuFlowStateChangeOption>()
				{
					MenuFlowStateChangeOptionBuilder.If(MenuFlowStateChangeOptionCondition.Always).To(MenuState.Start),
				}
			},
			{
				MenuFlowStateChangeDirectionBuilder.From(MenuState.GameTypeSelection).Direction(MenuFlowStateChangeDirectionType.Forward),
				new List<MenuFlowStateChangeOption>()
				{
					MenuFlowStateChangeOptionBuilder.If(MenuFlowStateChangeOptionCondition.Always).To(MenuState.TrainSelection),
				}
			},

			// TrainSelection
			{
				MenuFlowStateChangeDirectionBuilder.From(MenuState.TrainSelection).Direction(MenuFlowStateChangeDirectionType.Backward),
				new List<MenuFlowStateChangeOption>()
				{
					MenuFlowStateChangeOptionBuilder.If(MenuFlowStateChangeOptionCondition.Always).To(MenuState.GameTypeSelection),
				}
			},
			{
				MenuFlowStateChangeDirectionBuilder.From(MenuState.TrainSelection).Direction(MenuFlowStateChangeDirectionType.Forward),
				new List<MenuFlowStateChangeOption>()
				{
					MenuFlowStateChangeOptionBuilder.If(MenuFlowStateChangeOptionCondition.GameTypeIsOffline).To(MenuState.MapSelection),
					MenuFlowStateChangeOptionBuilder.If(MenuFlowStateChangeOptionCondition.GameTypeIsOnline).To(MenuState.MultiplayerRoleSelection),
				}
			},

			// MultiplayerRoleSelection
			{
				MenuFlowStateChangeDirectionBuilder.From(MenuState.MultiplayerRoleSelection).Direction(MenuFlowStateChangeDirectionType.Backward),
				new List<MenuFlowStateChangeOption>()
				{
					MenuFlowStateChangeOptionBuilder.If(MenuFlowStateChangeOptionCondition.Always).To(MenuState.TrainSelection),
				}
			},
			{
				MenuFlowStateChangeDirectionBuilder.From(MenuState.MultiplayerRoleSelection).Direction(MenuFlowStateChangeDirectionType.Forward),
				new List<MenuFlowStateChangeOption>()
				{
					MenuFlowStateChangeOptionBuilder.If(MenuFlowStateChangeOptionCondition.MultiplayerRoleIsServer).To(MenuState.MapSelection),
					MenuFlowStateChangeOptionBuilder.If(MenuFlowStateChangeOptionCondition.MultiplayerRoleIsClient).To(MenuState.ClientWaiting),
				}
			},

			// MapSelection
			{
				MenuFlowStateChangeDirectionBuilder.From(MenuState.MapSelection).Direction(MenuFlowStateChangeDirectionType.Backward),
				new List<MenuFlowStateChangeOption>()
				{
					MenuFlowStateChangeOptionBuilder.If(MenuFlowStateChangeOptionCondition.GameTypeIsOffline).To(MenuState.TrainSelection),
					MenuFlowStateChangeOptionBuilder.If(MenuFlowStateChangeOptionCondition.GameTypeIsOnline).To(MenuState.MultiplayerRoleSelection),
				}
			},
			{
				MenuFlowStateChangeDirectionBuilder.From(MenuState.MapSelection).Direction(MenuFlowStateChangeDirectionType.Forward),
				new List<MenuFlowStateChangeOption>()
				{
					MenuFlowStateChangeOptionBuilder.If(MenuFlowStateChangeOptionCondition.GameTypeIsOffline).To(MenuState.Play),
					MenuFlowStateChangeOptionBuilder.If(MenuFlowStateChangeOptionCondition.GameTypeIsOnline).To(MenuState.ServerWaiting),
				}
			},

			// ClientWaiting
			{
				MenuFlowStateChangeDirectionBuilder.From(MenuState.ClientWaiting).Direction(MenuFlowStateChangeDirectionType.Backward),
				new List<MenuFlowStateChangeOption>()
				{
					MenuFlowStateChangeOptionBuilder.If(MenuFlowStateChangeOptionCondition.Always).To(MenuState.MultiplayerRoleSelection),
				}
			},
			{
				MenuFlowStateChangeDirectionBuilder.From(MenuState.ClientWaiting).Direction(MenuFlowStateChangeDirectionType.Forward),
				new List<MenuFlowStateChangeOption>()
				{
					MenuFlowStateChangeOptionBuilder.If(MenuFlowStateChangeOptionCondition.Always).To(MenuState.Play),
				}
			},

			// ServerWaiting
			{
				MenuFlowStateChangeDirectionBuilder.From(MenuState.ServerWaiting).Direction(MenuFlowStateChangeDirectionType.Backward),
				new List<MenuFlowStateChangeOption>()
				{
					MenuFlowStateChangeOptionBuilder.If(MenuFlowStateChangeOptionCondition.Always).To(MenuState.MapSelection),
				}
			},
			{
				MenuFlowStateChangeDirectionBuilder.From(MenuState.ServerWaiting).Direction(MenuFlowStateChangeDirectionType.Forward),
				new List<MenuFlowStateChangeOption>()
				{
					MenuFlowStateChangeOptionBuilder.If(MenuFlowStateChangeOptionCondition.Always).To(MenuState.Play),
				}
			},
		};

	public static List<MenuFlowStateChangeOption> GetChangeOptions(MenuFlowStateChangeDirection changeDirection)
	{
		try {
			return States[changeDirection];
		} catch (KeyNotFoundException) {
			throw new MenuFlowStateChangeNotFoundException(changeDirection);
		}
	}
}
