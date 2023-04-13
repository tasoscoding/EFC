package Efc.SensorWatcher;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class ValuesI {
    @SerializedName(value = "Value") @Expose public int value;
    @SerializedName(value = "TimeStamp") @Expose public String timestamp;
    @SerializedName(value = "SensoriID") @Expose public int sensoriId;
}
