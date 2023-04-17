namespace RpiWebApi.DTO.Inverter
{
    [Flags]
    public enum OperationType {
        Start,
        Stop, 
        Reverse,
        EmergencyStop,
        ChangeFrequency,
        Unknown
    }
}
