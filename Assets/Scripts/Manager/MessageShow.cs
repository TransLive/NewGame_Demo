using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public interface IMessageShow{}
public static class MessageShow
{
    public static void START_METHOD<T>(this T t, string methodName) where T : IMessageShow
    {
#if NEEDMETHODLOG
        Debug.Log(string.Format("=====Start method{0}.Method:{1}=====" ,t.GetType().Name, methodName));
#endif
    }

	public static void PRINT<T>(this T t,string msg) where T:IMessageShow
	{
#if NEEDMETHODLOG
        Debug.Log(string.Format("=====End method{0}.Message:{1}=====", t.GetType().Name, msg));
#endif
    }

    public static void END_METHOD<T>(this T t, string methodName) where T : IMessageShow
    {
#if NEEDMETHODLOG
        Debug.Log(string.Format("=====End method{0}.Method:{1}=====" ,t.GetType().Name, methodName));
#endif
    }
}