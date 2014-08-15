using System.Runtime.Serialization;

namespace RedDog.Search.Model
{
    [DataContract]
    public enum InterpolationType
    {
        [EnumMember(Value = "linear")]
        Linear = 0,

        [EnumMember(Value = "constant")]
        Constant = 1,

        [EnumMember(Value = "quadratic")]
        Quadratic = 2,

        [EnumMember(Value = "logarithmic")]
        Logarithmic = 3
    }
}