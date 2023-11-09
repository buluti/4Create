using System.Runtime.Serialization;

namespace _4Create.Domain.Enums
{
    public enum Title
    {
        [EnumMember(Value = "developer")]
        Developer,

        [EnumMember(Value = "manager")]
        Manager,

        [EnumMember(Value = "tester")]
        Tester
    }

    public enum Event
    {
        [EnumMember(Value = "create")]
        Create,

        [EnumMember(Value = "update")]
        Update
    }
}
