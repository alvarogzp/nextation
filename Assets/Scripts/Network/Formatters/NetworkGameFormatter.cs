using UnityEngine;
using System.Collections;

public class NetworkGameFormatter
{
	private const char COMMENT_SEPARATOR = '\n';

	public static string GetGameName()
	{
		return GameStorageKeys.SelectedMap.Get() + "-" + (System.DateTime.Now.Ticks/10000000);
	}

	public static string GetGameComment(NetworkPlayer player)
	{
		return getPortComment(player) + COMMENT_SEPARATOR + getDisplayComment();
	}

	private static string getPortComment(NetworkPlayer player)
	{
		return player.port.ToString();
	}

	private static string getDisplayComment()
	{
		return GameStorageKeys.SelectedMap.Get() + " (" + System.DateTime.Now.ToString() + ")";
	}

	public static int ParseCommentPort(string comment)
	{
		return int.Parse(comment.Split(COMMENT_SEPARATOR)[0]);
	}

	public static string ParseCommentToDisplay(string comment)
	{
		return comment.Split(COMMENT_SEPARATOR)[1];
	}
}
