using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BeaconEvent.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotScanning))]
        bool isScanning;

        [ObservableProperty]
        string title;

        public bool IsNotBusy => !IsBusy;
        public bool IsNotScanning => !IsScanning;
    }
}