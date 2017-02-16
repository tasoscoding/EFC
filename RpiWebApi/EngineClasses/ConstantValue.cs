

namespace RpiWebApi.EngineClasses {
    public class ConstantValue<T> : EngineOutput where T : EngineConstant {
        public T constant { get; set; }
    }
}