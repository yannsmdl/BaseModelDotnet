using System.ComponentModel;

namespace BaseModel.Domain.Enums
{
    public enum TypeClientEnum
    {
        [Description("Pessoa Fisica")]
        PF = 1,
        [Description("Pessoa Juridica")]
        PJ = 2
    }
}