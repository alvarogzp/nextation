public class MenuFlowTransitionActionPerformerFactory
{
	public static MenuFlowTransitionActionPerformer For(MenuFlowTransitionActionType action)
	{
		switch (action) {
		case MenuFlowTransitionActionType.ChangeCamera:
			return new ChangeCameraMenuFlowTransitionActionPerformer();
		case MenuFlowTransitionActionType.ChangeScene:
			return new ChangeSceneMenuFlowTransitionActionPerformer();
		case MenuFlowTransitionActionType.LoadSelectedMap:
			return new LoadSelectedMapMenuFlowTransitionActionPerformer();
		case MenuFlowTransitionActionType.EnableScript:
			return new EnableScriptMenuFlowTransitionActionPerformer();
		case MenuFlowTransitionActionType.DisableScript:
			return new DisableScriptMenuFlowTransitionActionPerformer();
		default:
			throw new UnknownMenuFlowTransitionActionTypeException(action);
		}
	}
}
