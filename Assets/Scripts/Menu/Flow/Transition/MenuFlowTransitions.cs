using System.Collections.Generic;

public class MenuFlowTransitions
{
	public static Dictionary<MenuFlowTransitionStates, MenuFlowTransitionAction> Transitions =
		new Dictionary<MenuFlowTransitionStates, MenuFlowTransitionAction>(new MenuFlowTransitionStatesEqualityComparer())
		{
			// Start
			{
				MenuFlowTransitionStatesBuilder.From(MenuState.Start).To(MenuState.GameTypeSelection),
				MenuFlowTransitionActionBuilder.Do(MenuFlowTransitionActionType.ChangeCamera).On(MenuCameraNames.GAME_TYPE_SELECTION)
			},

			// GameTypeSelection
			{
				MenuFlowTransitionStatesBuilder.From(MenuState.GameTypeSelection).To(MenuState.Start),
				MenuFlowTransitionActionBuilder.Do(MenuFlowTransitionActionType.ChangeCamera).On(MenuCameraNames.START)
			},
			{
				MenuFlowTransitionStatesBuilder.From(MenuState.GameTypeSelection).To(MenuState.TrainSelection),
				MenuFlowTransitionActionBuilder.Do(MenuFlowTransitionActionType.ChangeScene).On(SceneNames.TRAIN_SELECTION)
			},

			// TrainSelection
			{
				MenuFlowTransitionStatesBuilder.From(MenuState.TrainSelection).To(MenuState.GameTypeSelection),
				MenuFlowTransitionActionBuilder.Do(MenuFlowTransitionActionType.ChangeScene).On(SceneNames.MENU) // FIXME
			},
			{
				MenuFlowTransitionStatesBuilder.From(MenuState.TrainSelection).To(MenuState.MultiplayerRoleSelection),
				MenuFlowTransitionActionBuilder.Do(MenuFlowTransitionActionType.ChangeCamera).On(MenuCameraNames.MULTIPLAYER_ROLE_SELECTION)
			},
			{
				MenuFlowTransitionStatesBuilder.From(MenuState.TrainSelection).To(MenuState.MapSelection),
				MenuFlowTransitionActionBuilder.Do(MenuFlowTransitionActionType.ChangeScene).On(SceneNames.MAP_SELECTION)
			},

			// MultiplayerRoleSelection
			{
				MenuFlowTransitionStatesBuilder.From(MenuState.MultiplayerRoleSelection).To(MenuState.TrainSelection),
				MenuFlowTransitionActionBuilder.Do(MenuFlowTransitionActionType.ChangeCamera).On(MenuCameraNames.TRAIN_SELECTION)
			},
			{
				MenuFlowTransitionStatesBuilder.From(MenuState.MultiplayerRoleSelection).To(MenuState.MapSelection),
				MenuFlowTransitionActionBuilder.Do(MenuFlowTransitionActionType.ChangeScene).On(SceneNames.MAP_SELECTION)
			},
			{
				MenuFlowTransitionStatesBuilder.From(MenuState.MultiplayerRoleSelection).To(MenuState.ClientWaiting),
				MenuFlowTransitionActionGroupBuilder
					.Add(MenuFlowTransitionActionBuilder.Do(MenuFlowTransitionActionType.ChangeCamera).On(MenuCameraNames.CLIENT_WAITING))
					.Add(MenuFlowTransitionActionBuilder.Do(MenuFlowTransitionActionType.EnableScript).On(GameObjectNames.NETWORK_CLIENT))
			},

			// MapSelection
			{
				MenuFlowTransitionStatesBuilder.From(MenuState.MapSelection).To(MenuState.TrainSelection),
				MenuFlowTransitionActionBuilder.Do(MenuFlowTransitionActionType.ChangeScene).On(SceneNames.TRAIN_SELECTION)
			},
			{
				MenuFlowTransitionStatesBuilder.From(MenuState.MapSelection).To(MenuState.MultiplayerRoleSelection),
				MenuFlowTransitionActionBuilder.Do(MenuFlowTransitionActionType.ChangeScene).On(SceneNames.TRAIN_SELECTION) // FIXME
			},
			{
				MenuFlowTransitionStatesBuilder.From(MenuState.MapSelection).To(MenuState.Play),
				MenuFlowTransitionActionBuilder.Do(MenuFlowTransitionActionType.LoadSelectedMap).On(string.Empty)
			},
			{
				MenuFlowTransitionStatesBuilder.From(MenuState.MapSelection).To(MenuState.ServerWaiting),
				MenuFlowTransitionActionGroupBuilder
					.Add(MenuFlowTransitionActionBuilder.Do(MenuFlowTransitionActionType.ChangeCamera).On(MenuCameraNames.SERVER_WAITING))
					.Add(MenuFlowTransitionActionBuilder.Do(MenuFlowTransitionActionType.EnableScript).On(GameObjectNames.NETWORK_SERVER))
			},

			// ClientWaiting
			{
				MenuFlowTransitionStatesBuilder.From(MenuState.ClientWaiting).To(MenuState.MultiplayerRoleSelection),
				MenuFlowTransitionActionGroupBuilder
					.Add(MenuFlowTransitionActionBuilder.Do(MenuFlowTransitionActionType.DisableScript).On(GameObjectNames.NETWORK_CLIENT))
					.Add(MenuFlowTransitionActionBuilder.Do(MenuFlowTransitionActionType.ChangeCamera).On(MenuCameraNames.MULTIPLAYER_ROLE_SELECTION))
			},
			{
				MenuFlowTransitionStatesBuilder.From(MenuState.ClientWaiting).To(MenuState.Play),
				MenuFlowTransitionActionBuilder.Do(MenuFlowTransitionActionType.LoadSelectedMap).On(string.Empty)
			},

			// ServerWaiting
			{
				MenuFlowTransitionStatesBuilder.From(MenuState.ServerWaiting).To(MenuState.MapSelection),
				MenuFlowTransitionActionGroupBuilder
					.Add(MenuFlowTransitionActionBuilder.Do(MenuFlowTransitionActionType.DisableScript).On(GameObjectNames.NETWORK_SERVER))
					.Add(MenuFlowTransitionActionBuilder.Do(MenuFlowTransitionActionType.ChangeCamera).On(MenuCameraNames.MAP_SELECTION))
			},
			{
				MenuFlowTransitionStatesBuilder.From(MenuState.ServerWaiting).To(MenuState.Play),
				MenuFlowTransitionActionBuilder.Do(MenuFlowTransitionActionType.LoadSelectedMap).On(string.Empty)
			},
		};

	public static MenuFlowTransitionAction GetAction(MenuFlowTransitionStates transitionStates)
	{
		try {
			return Transitions[transitionStates];
		} catch (KeyNotFoundException) {
			throw new MenuFlowTransitionNotFoundException(transitionStates);
		}
	}
}
