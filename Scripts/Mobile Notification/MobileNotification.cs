using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;

public class MobileNotification : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AndroidNotificationCenter.CancelAllDisplayedNotifications();

        var channel = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Notification  Channel",
            Importance = Importance.Default,
            Description = "Reminder Notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);

        var notification = new AndroidNotification();
        notification.Title = "Unlock Sprite Ninja";
        notification.Text = "You are Progressing and you can unlock the ninja after 5000 coins ";
        notification.FireTime = System.DateTime.Now.AddSeconds(5);

     var id =   AndroidNotificationCenter.SendNotification(notification, "channel_id");

        if(AndroidNotificationCenter.CheckScheduledNotificationStatus(id) == NotificationStatus.Scheduled)
        {
            AndroidNotificationCenter.CancelAllDisplayedNotifications();
            AndroidNotificationCenter.SendNotification(notification, "channel_id");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
