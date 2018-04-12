//
//  Created by wanglidong on 11/23/2016.
//

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

/// 单例接口
public interface ISingletonTeamplate {
	/// 初始化
	void Initialize();
	/// 销毁
	void Terminate();
}

/// 简单的单例模板
public abstract class SingletonTeamplate<T> where T : class, ISingletonTeamplate, new() {

	// 单例
	private static T m_instance;

	/// 当单例不存在时创建单例
	public static T CreateInstance() {
		if(m_instance == null) {
			m_instance = new T();
			//			Debug.LogWarning("+++++++++++++++++++++ CreateInstance:" + typeof(T) + " = " + m_instance.GetHashCode());
			m_instance.Initialize();
		}
		return m_instance;
	}

	/// 销毁实例
	public static void DestroyInstance() {
		if(m_instance != null) {
			//			Debug.LogWarning("--------------------- DestroyInstance:" + typeof(T) + " = " + m_instance.GetHashCode());
			m_instance.Terminate();
			m_instance = null;
		}
	}

	/// 获取单例引用, 不会创建单例
	public static T GetInstance() {
		return m_instance;
	}

	public static bool IsExistInstance() {
		return GetInstance() != null;
	}

	/// 初始化
	virtual public void Initialize(){
//		Debug.LogWarning("+++++++++++++++++++++ Initialize:" + typeof(T));
	}

	/// 销毁
	virtual public void Terminate(){
//		Debug.LogWarning("--------------------- Terminate:" + typeof(T));
	}
}

#if false
/// 单例管理器
/// 希望继承自其他class时，可以用这种方式代替SingletonTeamplate<T>
public static class SingletonManager<T> where T : class, ISingletonTeamplate, new() {

	// 单例
	private static T m_instance;

	/// 当单例不存在时创建单例
	public static T CreateInstance() {
		if(m_instance == null) {
			m_instance = new T();
//			Debug.LogWarning("+++++++++++++++++++++ CreateInstance:" + typeof(T) + " = " + m_instance.GetHashCode());
			m_instance.Initialize();
		}
		return m_instance;
	}

	/// 销毁实例
	public static void DestroyInstance() {
		if(m_instance != null) {
//			Debug.LogWarning("--------------------- DestroyInstance:" + typeof(T) + " = " + m_instance.GetHashCode());
			m_instance.Terminate();
			m_instance = null;
		}
	}

	/// 获取单例引用, 不会创建单例
	public static T GetInstance() {
		return m_instance;
	}
}
#endif
