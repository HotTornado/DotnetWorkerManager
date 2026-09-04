using System.ComponentModel;
using System.ServiceProcess;

namespace DotnetWorkerManager;

public class ServiceItem : INotifyPropertyChanged
{
    private string _serviceName = string.Empty;
    private string _displayName = string.Empty;
    private string _fullPath = string.Empty;
    private ServiceControllerStatus? _status;
    private bool _isBusy;
    private string _statusMessage = string.Empty;

    public string ServiceName
    {
        get => _serviceName;
        set { _serviceName = value; OnPropertyChanged(nameof(ServiceName)); }
    }

    public string DisplayName
    {
        get => _displayName;
        set { _displayName = value; OnPropertyChanged(nameof(DisplayName)); }
    }

    public string FullPath
    {
        get => _fullPath;
        set { _fullPath = value; OnPropertyChanged(nameof(FullPath)); }
    }

    public ServiceControllerStatus? Status
    {
        get => _status;
        set
        {
            _status = value;
            OnPropertyChanged(nameof(Status));
            OnPropertyChanged(nameof(StatusText));
            OnPropertyChanged(nameof(CanStart));
            OnPropertyChanged(nameof(CanStop));
            OnPropertyChanged(nameof(CanRestart));
        }
    }

    public bool IsBusy
    {
        get => _isBusy;
        set
        {
            _isBusy = value;
            OnPropertyChanged(nameof(IsBusy));
            OnPropertyChanged(nameof(StatusText));
            OnPropertyChanged(nameof(CanStart));
            OnPropertyChanged(nameof(CanStop));
            OnPropertyChanged(nameof(CanRestart));
        }
    }

    public string StatusMessage
    {
        get => _statusMessage;
        set
        {
            _statusMessage = value;
            OnPropertyChanged(nameof(StatusMessage));
            OnPropertyChanged(nameof(StatusText));
        }
    }

    public string StatusText
    {
        get
        {
            if (IsBusy && !string.IsNullOrEmpty(_statusMessage))
                return _statusMessage;

            if (_status == null)
                return "Not Installed / Unknown";

            return _status switch
            {
                ServiceControllerStatus.Running => "Running",
                ServiceControllerStatus.Stopped => "Stopped",
                ServiceControllerStatus.Paused => "Paused",
                ServiceControllerStatus.StartPending => "Starting...",
                ServiceControllerStatus.StopPending => "Stopping...",
                ServiceControllerStatus.PausePending => "Pausing...",
                ServiceControllerStatus.ContinuePending => "Resuming...",
                _ => _status.ToString() ?? "Unknown"
            };
        }
    }

    public bool CanStart => !IsBusy && (_status == ServiceControllerStatus.Stopped || _status == ServiceControllerStatus.Paused);
    public bool CanStop => !IsBusy && _status == ServiceControllerStatus.Running;
    public bool CanRestart => !IsBusy && _status == ServiceControllerStatus.Running;

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
