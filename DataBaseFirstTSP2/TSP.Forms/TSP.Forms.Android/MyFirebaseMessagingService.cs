using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Messaging;

namespace TSP.Forms.Droid
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class MyFirebaseMessagingService : FirebaseMessagingService
    {
        const string TAG = "MyFirebaseMsgService";
        public override void OnMessageReceived(RemoteMessage message)
        {
            base.OnMessageReceived(message);
            SendNotification(message.GetNotification().Body);
        }

        void SendNotification(string messageBody)
        {
            try
            {
                var intent = new Intent(this, typeof(MainActivity));
                intent.AddFlags(
                    ActivityFlags.NewTask | ActivityFlags.SingleTop
                );
                var pendingIntent = PendingIntent.GetActivity(this, 0, intent, PendingIntentFlags.OneShot);
                var defaultSoundUri = RingtoneManager.GetDefaultUri(RingtoneType.Notification);
                using (var notificationBuilder = new Notification.Builder(this)
                    .SetContentTitle("Título")
                    .SetContentText(messageBody)
                    .SetSound(defaultSoundUri)
                    .SetVibrate(new long[] { 100, 200, 300 })
                    .SetAutoCancel(true)
                    .SetContentIntent(pendingIntent))
                {
                    var notificationManager = NotificationManager.FromContext(this);
                    notificationManager.Notify(1, notificationBuilder.Build());
                }
            }
            catch { }
        }
    }
}