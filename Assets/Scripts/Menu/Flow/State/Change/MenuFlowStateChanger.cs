using System.Collections.Generic;

public class MenuFlowStateChanger
{
	private MenuState currentState;
	private MenuFlowStateChangeDirection changeDirection;

	private MenuFlowStateChanger(MenuState currentState)
	{
		this.currentState = currentState;
	}

	public static MenuFlowStateChanger From(MenuState currentState)
	{
		return new MenuFlowStateChanger(currentState);
	}

	public void Direction(MenuFlowStateChangeDirectionType direction)
	{
		List<MenuFlowStateChangeOption> options = getStateChangeOptions(direction);
		applyFirstValidOption(options);
	}

	private List<MenuFlowStateChangeOption> getStateChangeOptions(MenuFlowStateChangeDirectionType direction)
	{
		changeDirection = MenuFlowStateChangeDirectionBuilder.From(currentState).Direction(direction);
		return MenuFlowStateChanges.GetChangeOptions(changeDirection);
	}

	private void applyFirstValidOption(List<MenuFlowStateChangeOption> options)
	{
		foreach (MenuFlowStateChangeOption option in options) {
			if (option.Condition()) {
				transitionTo(option.To);
				return;
			}
		}

		throw new NoApplicableOptionFoundForMenuFlowStateChangeDirectionException(changeDirection);
	}

	private void transitionTo(MenuState newState)
	{
		MenuFlowTransition.From(currentState).To(newState);
	}
}
