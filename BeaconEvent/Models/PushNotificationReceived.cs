using System;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace BeaconEvent.Models
{
	public class PushNotificationReceived : ValueChangedMessage<string>
    {
        public PushNotificationReceived(string message) : base(message) { }
    }
}