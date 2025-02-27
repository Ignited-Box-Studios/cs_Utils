﻿namespace Utils.EventSystem
{
	public interface IEventHandler 
	{
		void CleanInstace(object target);
	}

	public interface IEventHandler<TKey> : IEventHandler
	{
		T GetContainer<T>(TKey key, bool create)
			where T : IEventContainer, new();
	}
}
