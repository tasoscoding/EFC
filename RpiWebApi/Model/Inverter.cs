using RpiWebApi.DTO.Inverter;

public class Inverter
{
    public Inverter(string model, ConnectionParams connectionParams)
    {
        Model = model;
        this.connectionParams = connectionParams;
    }

    public string Model { get; set; }
    public ConnectionParams connectionParams { get; set; }
}
