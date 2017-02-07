using System;
using System.Web.UI;
using EFC;

using VegaDrive = EFC.Engines.VegaDrive_15P0087B5;

public partial class EFCInterface: Page
{
    private IEngine engine;
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        engine = new VegaDrive("/dev/ttyUSB0", 1);
    } 

    protected void StartEngine(object sender, EventArgs e)
    {
        engine.Start();
    }

    protected void StopEngine(object sender, EventArgs e)
    {
        engine.Stop();
    }

    protected void ReverseEngine(object sender, EventArgs e)
    {
        engine.Reverse();
    }

    protected void ResetEngine(object sender, EventArgs e)
    {
        engine.Reset();
    }

    protected void EmergencyStopEngine(object sender, EventArgs e)
    {
        engine.EmergencyStop();
    }

    protected void GetEngineStatus(object sender, EventArgs e)
    {
        EngineStatus s = engine.Status();
        writeLine("Engine Status: " + s.ToString());
    }


    /// Debug function for directly accessing vega drive's registers. 
    protected void send_click(object sender, EventArgs e)
    {
        string input = inputbox.Text;
        string[] values = input.Split(' ');
        ushort addr = Convert.ToUInt16(values[0]);
        VegaDrive vegaeng = (VegaDrive) engine;  // may throw
        try
        {
            if (values.Length > 1)
            {
                vegaeng.WriteRegister(addr, Convert.ToInt16(values[1]));
                write("Successfully wrote " + values[1] + " to address " + values[0]);
            }
            else
            {
                short val = vegaeng.ReadRegister(addr);
                writeLine("Read from " + values[0] + ": 0x" + val.ToString("x"));
            }
        }
        catch (EFC.EngineMessageException exc)
        {
            writeLine(exc.Message);
        }
    }

    void write(string s)
    {
        outputbox.Text += s;
    }

    void writeLine(string s)
    {
        outputbox.Text += s + "<br />";
    }
}
