using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.Notifications.Android;

public class NotificationsManager : MonoBehaviour
{

    public static NotificationsManager Instance { get; private set; }

    AndroidNotificationChannel notiChannel;

    private void Awake()
    {
        if(Instance != this || Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        notiChannel = new AndroidNotificationChannel()
        {
            Id = "recordatorio_jugar",
            Name = "recordatorio_notificacion",
            Description = "Recordatorio_Entra",
            Importance = Importance.High
        };

        AndroidNotificationCenter.RegisterNotificationChannel(notiChannel);

        DisplayNotification("FICHAS RECARGADAS!!", "Vuelve a derrotar a tus enemigos", IconSelect.icon_reminder, DateTime.Now.AddHours(12));
    }

    public int DisplayNotification(string title, string text, IconSelect iconsmall,DateTime firetime)
    {
        var notification = new AndroidNotification();
        notification.Title = title;
        notification.Text = text;
        notification.SmallIcon = iconsmall.ToString();
        notification.FireTime = firetime;

        return AndroidNotificationCenter.SendNotification(notification, notiChannel.Id);
    }
    public void CancelNotification(int id)
    {
        AndroidNotificationCenter.CancelScheduledNotification(id);
    }

    public enum IconSelect
    {
        icon_reminder,
    }
}
