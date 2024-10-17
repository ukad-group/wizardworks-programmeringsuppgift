namespace Wizardworks.Demo.Core.Config;

public class AppSetting
{
    public StorageModel Storage { get; set; }
    public class StorageModel
    {
        public string ContainerName { get;set; }
    }
}